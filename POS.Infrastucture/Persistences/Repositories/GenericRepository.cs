using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using POS.Infrastucture.Commons.Bases.Request;
using POS.Infrastucture.Helpers;
using POS.Infrastucture.Persistences.Context;
using POS.Infrastucture.Persistences.Interfaces;
using POS.Utilities.Static;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace POS.Infrastucture.Persistences.Repositories
{
    public class GenericRepository<T>: IGenericRepository<T> where T : BaseEntity
    {
        private readonly PosContext _context;
        private readonly DbSet<T> _entity;

        public GenericRepository(PosContext context, DbSet<T> entity)
        {
            _context = context;
            _entity = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            // Give an entity and receive registers where state equals 1 and the audit data delete be nulls
            var getAll =  await _entity.Where(x => x.State.Equals((int)StateTypes.Active) && x.AuditDeleteUser == null && x.AuditDeleteDate == null)
                .AsNoTracking().ToListAsync();

            return getAll;        
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var getById = await _entity!.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));

            return getById!;
        }

        public async Task<bool> RegisterAsync(T entity)
        {
            entity.AuditCreateUser = 1;
            entity.AuditCreateDate = DateTime.Now;

            await _context.AddAsync(entity);

            var recordAffected = await _context.SaveChangesAsync();
            return recordAffected > 0;
        }

        public async Task<bool> EditAsync(T entity)
        {
            entity.AuditUpdateUser = 1;
            entity.AuditUpdateDate = DateTime.Now;

            _context.Update(entity);
            _context.Entry(entity).Property(x => x.AuditCreateUser).IsModified = false; // No modificar el campo de auditoria de creacion
            _context.Entry(entity).Property(x => x.AuditCreateDate).IsModified = false; // No modificar el campo de auditoria de creacion

            var recordAffected = await _context.SaveChangesAsync();
            return recordAffected > 0;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            T entity = await GetByIdAsync(id);

            entity!.AuditDeleteUser = 1;
            entity.AuditDeleteDate = DateTime.Now;

            _context.Update(entity);

            var recordAffected = await _context.SaveChangesAsync();
            return recordAffected > 0;
        }

        public IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null)
        {
            // Receive an entity of IQueryable type
            IQueryable<T> query = _entity;

            if (filter != null) query = query.Where(filter);

            return query;
        }

        public IQueryable<TDTO> Ordering<TDTO>(BasePaginationRequest request, IQueryable<TDTO> queryable, bool pagination = false) where TDTO : class
        {
            // Ordering data
            IQueryable<TDTO> queryDto = request.Order == "desc" ? queryable.OrderBy($"{request.Sort} descending") : queryable.OrderBy($"{request.Sort} ascending");

            if(pagination) queryDto = queryDto.Paginate(request);

            return queryDto;
        }
    }
}

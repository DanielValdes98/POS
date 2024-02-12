using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using POS.Infrastucture.Commons.Bases.Request;
using POS.Infrastucture.Commons.Bases.Response;
using POS.Infrastucture.Persistences.Context;
using POS.Infrastucture.Persistences.Interfaces;

namespace POS.Infrastucture.Persistences.Repositories
{
    public class ProviderRepository : GenericRepository<Provider>, IProviderRepository
    {
        public ProviderRepository(PosContext context) :base(context) { }

        public async Task<BaseEntityResponse<Provider>> ListProviders(BaseFiltersRequest filters)
        {
            var response = new BaseEntityResponse<Provider>();

            var providers = GetEntityQuery(x => x.AuditDeleteUser == null && x.AuditDeleteDate == null)
                .Include(x => x.DocumentType)
                .AsNoTracking();

            if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
            {
                switch (filters.NumFilter)
                {
                    case 1:
                        providers = providers.Where(x => x.Name.Contains(filters.TextFilter));
                        break;
                    case 2:
                        providers = providers.Where(x => x.Email.Contains(filters.TextFilter));
                        break;
                    case 3:
                        providers = providers.Where(x => x.DocumentNumber.Contains(filters.TextFilter));
                        break;
                }
            }

            if (filters.StateFilter is not null)
            {
                providers = providers.Where(x => x.State.Equals(filters.StateFilter));
            }

            if (filters.StartDate is not null && filters.EndDate is not null)
            {
                providers = providers.Where(x => x.AuditCreateDate >= Convert.ToDateTime(filters.StartDate) && 
                                            x.AuditCreateDate <= Convert.ToDateTime(filters.EndDate).AddDays(1));
            }

            if (filters.Sort is null) filters.Sort = "Id";

            response.TotalRecords = await providers.CountAsync();
            response.Items = await Ordering(filters, providers, !(bool)filters.Download!).ToListAsync();

            return response;
        }
    }
}

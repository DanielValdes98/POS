using POS.Infrastucture.FileStorage;

namespace POS.Infrastucture.Persistences.Interfaces
{
    // Maneja trasnacciones durante la manipulación de los datos
    public interface IUnitOfWork : IDisposable
    {
        // Declaración o matrícula de nuestras interfaces a nivel de repositorio
        ICategoryRepository Category { get; }
        IUserRepository User { get; }
        IAzureStorage Storage { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}

namespace POS.Infrastucture.Persistences.Interfaces
{
    // Maneja trasnacciones durante la manipulación delos datos
    public interface IUnitOfWork : IDisposable
    {
        // Declaración o matrícula de nuestras interfaces a nivel de repositorio
        ICategoryRepository Category { get; }
        IUserRepository User { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infrastucture.Persistences.Interfaces
{
    // Maneja trasnacciones durante la manipulación delos datos
    public interface IUnitOfWork : IDisposable
    {
        // Declaración o matrícula de nuestras interfaces a nivel de repositorio
        ICategoryRepository Category { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}

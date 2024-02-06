using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace POS.Infrastucture.FileStorage
{
    public class AzureStorage : IAzureStorage
    {
        private readonly string _connectionString;

        public AzureStorage(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AzureStorage");
        }
        public async Task<string> SaveFile(string container, IFormFile file)
        {
            // Ayuda a manipular los contenedores de Azure Storage y los blobs dentro de ellos
            var client = new BlobContainerClient(_connectionString, container); 

            await client.CreateIfNotExistsAsync(); // Crea el contenedor si no existe

            await client.SetAccessPolicyAsync(PublicAccessType.Blob); // Permite que los archivos sean públicos

            var extension = Path.GetExtension(file.FileName); // Obtiene la extensión del archivo

            var fileName = $"{Guid.NewGuid()}{extension}"; // Genera un nombre único para el archivo

            var blob = client.GetBlobClient(fileName); // Obtiene el blob

            await blob.UploadAsync(file.OpenReadStream()); // Sube el archivo al blob

            return blob.Uri.ToString(); // Retorna la URL del archivo

        }

        public  async Task<string> EditFile(string container, IFormFile file, string route)
        {
            RemoveFile(route, container); // Elimina el archivo existente
            return await SaveFile(container, file); // Guarda el nuevo archivo
        }

        public async Task RemoveFile(string route, string container)
        {
            if (string.IsNullOrEmpty(route))
            {
                return;
            }

            var client = new BlobContainerClient(_connectionString, container); 

            await client.CreateIfNotExistsAsync(); 

            var file = Path.GetFileName(route); // Obtiene el nombre del archivo
            var blob = client.GetBlobClient(file); // Obtiene el blob

            await blob.DeleteIfExistsAsync(); // Elimina el archivo
        }
    }
}

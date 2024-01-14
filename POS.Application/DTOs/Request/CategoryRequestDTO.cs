namespace POS.Application.DTOs.Request
{
    // Datos que el cliente me va a enviar en el request desde el frontend (Angular)
    public class CategoryRequestDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int State { get; set; }
    }
}

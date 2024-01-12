namespace POS.Application.DTOs.Response
{
    // Qué datos voy a mostrar em mi endpoint resultante como response (Swagger)
    public class CategoryResponseDTO
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime AuditCreateDate { get; set; }
        public int State { get; set; }
        public string? StateCegory { get; set; }
    }
}

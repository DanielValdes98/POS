namespace POS.Infrastucture.Commons.Bases.Response
{
    // Devuelve los registros desde la base de datos
    public class BaseEntityResponse<T>
    {
        public int? TotalRecords { get; set; }
        public List<T>? Items { get; set; }
    }
}

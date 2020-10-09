namespace GrupoBoticario.Product.Business.Models
{
    public class Warehouse : Entity
    {
        public int Sku { get; set; }
        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
    }
}

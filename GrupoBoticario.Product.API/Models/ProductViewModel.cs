namespace GrupoBoticario.Product.API.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public int Sku { get; set; }
        public string Name { get; set; }
        public bool IsMarketable { get; set; }
        public InventoryViewModel Inventory { get; set; }
    }
}

using System.Collections.Generic;

namespace GrupoBoticario.Product.API.Models
{
    public class InventoryViewModel
    {
        public int Quantity { get; set; }
        public List<WarehouseViewModel> Warehouses { get; set; }
    }
}

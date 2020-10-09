using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GrupoBoticario.Product.Business.Models
{
    [NotMapped]
    public class Inventory
    {
        public int Quantity { get; set; }
        public List<Warehouse> Warehouses { get; set; }
    }
}

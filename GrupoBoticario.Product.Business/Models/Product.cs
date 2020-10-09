using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoBoticario.Product.Business.Models
{
    public class Product : Entity
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public bool IsMarketable { get; set; }

        public virtual Inventory Inventory { get; set; }
    }
}

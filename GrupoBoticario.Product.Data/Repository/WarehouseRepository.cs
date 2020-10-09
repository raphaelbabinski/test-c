using GrupoBoticario.Product.Business.Interfaces;
using GrupoBoticario.Product.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBoticario.Product.Data.Repository
{
    public class WarehouseRepository : Repository<Business.Models.Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(DataContext context) : base(context) { }

        public async Task<List<Business.Models.Warehouse>> GetBySku(int Sku)
        {
            return await Db.Warehouses.Where(p => p.Sku == Sku).ToListAsync();
        }
    }
}

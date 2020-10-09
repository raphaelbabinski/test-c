using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrupoBoticario.Product.Business.Interfaces
{
    public interface IWarehouseRepository : IRepository<Models.Warehouse>
    {
        Task<List<Models.Warehouse>> GetBySku(int Sku);
    }
}

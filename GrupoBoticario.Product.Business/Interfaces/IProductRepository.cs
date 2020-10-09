using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrupoBoticario.Product.Business.Interfaces
{
    public interface IProductRepository : IRepository<Models.Product>
    {
        Task<Models.Product> GetBySku(int Sku);
    }
}
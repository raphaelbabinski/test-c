using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoBoticario.Product.Business.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Models.Product>> GetAll();
        Task<Models.Product> GetBySku(int Sku);
        Task Insert(Models.Product model);
        Task Update(Models.Product model);
        Task Delete(int Sku);
    }
}

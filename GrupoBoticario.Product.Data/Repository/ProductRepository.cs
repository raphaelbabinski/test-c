using GrupoBoticario.Product.Business.Interfaces;
using GrupoBoticario.Product.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBoticario.Product.Data.Repository
{
    public class ProductRepository : Repository<Business.Models.Product>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context) { }

        public async Task<Business.Models.Product> GetBySku(int Sku)
        {
            return await Db.Products.Where(p => p.Sku == Sku).FirstOrDefaultAsync();
        }
    }
}

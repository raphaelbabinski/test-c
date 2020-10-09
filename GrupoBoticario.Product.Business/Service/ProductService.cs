using GrupoBoticario.Product.Business.Interfaces;
using GrupoBoticario.Product.Business.Models._Validations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBoticario.Product.Business.Service
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IWarehouseRepository _warehouseRepository;

        public ProductService(IProductRepository productRepository, IWarehouseRepository warehouseRepository, INotifier notifier) : base(notifier)
        {
            _productRepository = productRepository;
            _warehouseRepository = warehouseRepository;
        }

        public async Task<IEnumerable<Models.Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }

        public async Task<Models.Product> GetBySku(int Sku)
        {
            var product = await _productRepository.GetBySku(Sku);
            if (product != null)
            {
                product.Inventory = new Models.Inventory();
                product.Inventory.Warehouses = await _warehouseRepository.GetBySku(Sku);
                product.Inventory.Quantity = product.Inventory.Warehouses == null ? 0 : product.Inventory.Warehouses.Sum(i => i.Quantity);
                product.IsMarketable = product.Inventory.Quantity > 0 ? true : false;
            }

            return product;
        }

        public async Task Insert(Models.Product model)
        {
            if (ExecuteValidate(new ProductValidation(), model))
            {
                if (_productRepository.Search(f => f.Sku == model.Sku).Result.Any())
                    Notifier("Já existe um produto cadastrado com esse SKU");
                else
                {
                    await _productRepository.Insert(model);

                    if (model.Inventory != null)
                    {
                        foreach (var item in model.Inventory.Warehouses)
                        {
                            item.Sku = model.Sku;
                            await _warehouseRepository.Insert(item);
                        }
                    }
                }
            }
        }

        public async Task Update(Models.Product model)
        {
            if (ExecuteValidate(new ProductValidation(), model))
            {
                var product = await _productRepository.GetBySku(model.Sku);
                if (product == null)
                    Notifier("Produto não encontrado");
                else
                {
                    model.Id = product.Id;
                    _productRepository.DetachLocal(i => i.Id == model.Id);
                    await _productRepository.Update(model);
                }
            }
        }

        public async Task Delete(int Sku)
        {
            var product = await _productRepository.GetBySku(Sku);
            if (product == null)
                Notifier("Produto não encontrado");
            else
            {
                _productRepository.DetachLocal(i => i.Id == product.Id);
                await _productRepository.Delete(product.Id);
            }
        }
    }
}

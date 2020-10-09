using AutoMapper;
using GrupoBoticario.Product.API.Models;

namespace GrupoBoticario.Product.API.Controllers
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Business.Models.Product, ProductViewModel>().ReverseMap();
            CreateMap<Business.Models.Inventory, InventoryViewModel>().ReverseMap();
            CreateMap<Business.Models.Warehouse, WarehouseViewModel>().ReverseMap();
        }
    }
}

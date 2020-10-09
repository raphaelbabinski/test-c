using AutoMapper;
using GrupoBoticario.Product.API.Models;
using GrupoBoticario.Product.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoBoticario.Product.API.Controllers
{
    public class ProductController : BaseController
    {
        #region Construtor

        protected readonly IProductService _productService;
        protected readonly IMapper _mapper;
        protected readonly INotifier _notifier;

        public ProductController(IProductService productService, IMapper mapper, INotifier notifier) : base(notifier)
        {
            _productService = productService;
            _mapper = mapper;
            _notifier = notifier;
        }

        #endregion

        [HttpGet("product")]
        public async Task<IActionResult> GetAll()
        {
            var products = _mapper.Map<IEnumerable<ProductViewModel>>(await _productService.GetAll());

            return Ok(products);
        }

        [HttpGet("product/{sku}")]
        public async Task<IActionResult> GetBySku(int Sku)
        {
            var products = _mapper.Map<ProductViewModel>(await _productService.GetBySku(Sku));

            return Ok(products);
        }

        [HttpPost("product")]
        public async Task<IActionResult> Insert([FromBody] ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _productService.Insert(_mapper.Map<Business.Models.Product>(model));
                if (ValidOperation())
                    return Ok();
                else
                    return BadRequest(_notifier.GetNotification());
            }

            return BadRequest(ModelState);
        }

        [HttpPut("product")]
        public async Task<IActionResult> Update([FromBody] ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _productService.Update(_mapper.Map<Business.Models.Product>(model));
                if (ValidOperation())
                    return Ok();
                else
                    return BadRequest(_notifier.GetNotification());
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("product/{sku}")]
        public async Task<IActionResult> Delete(int Sku)
        {
            if (ModelState.IsValid)
            {
                await _productService.Delete(Sku);
                if (ValidOperation())
                    return Ok();
                else
                    return BadRequest(_notifier.GetNotification());
            }

            return BadRequest(ModelState);
        }
    }
}

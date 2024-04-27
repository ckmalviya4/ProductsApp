using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Data;
using ProductsApi.Models;
using ProductsApi.Services;

namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            if (products == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<ProductModel>>(products));
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetProductById(int id)
        { 
           var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductModel>(product));
        }


        [HttpPost]
        public async Task<IActionResult> AddProductAsync([FromBody]ProductRequestModel productRequestModel)
        {
            var product = _mapper.Map<Product>(productRequestModel);

            if (await _productService.AddProductAsync(product))
            {
                return CreatedAtRoute(Url.ActionLink(nameof(GetProductById), nameof(ProductController), product.Id), _mapper.Map<ProductModel>(product));
            }

            return BadRequest();
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateProductAsync(int id, [FromBody]ProductRequestModel productRequestModel)
        {
            var product = await _productService.FindProductByIdAsync(id);
            if (product == null)
            { 
                return NotFound();
            }

            _mapper.Map<ProductRequestModel, Product>(productRequestModel, product);
           
            if (await _productService.UpdateProductAsync(product))
            {
                return Ok(_mapper.Map<ProductModel>(product));
            }

            return BadRequest();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            var product = await _productService.FindProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }           

            if (await _productService.DeleteProductAsync(product))
            {
                return Ok(true);
            }

            return BadRequest();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Repository;
using Services.ProductService;

namespace ToysAndGames.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet()]
        public IActionResult Index()
        {
            try
            {
                List<ProductDTO> result = _productService.GetProducts();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct([FromQuery]int id)
        {
            try
            {
                ProductDTO result = _productService.GetProduct(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductDTOCreate product) 
        {
            try
            {
                ProductDTO result = _productService.CreateProduct(product);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [RequestSizeLimit(5 * 1024 * 1024)]
        public IActionResult Update([FromQuery] int id, [FromForm] ProductDTOUpdate productDTO)
        {
            try
            {
                ProductDTO result = _productService.UpdateProduct(productDTO, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int id)
        {
            try
            {
                _productService.DeleteProduct(id);
                return Ok($"Product id {id} successfully deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

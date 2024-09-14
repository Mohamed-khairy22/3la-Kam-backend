using _3la_Kam_backend.Models;
using _3la_Kam_backend.Repositoris;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _3la_Kam_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductRepo productRepo;

        public ProductController(IProductRepo productRepo)
        {
            this.productRepo = productRepo;
        }

        [HttpGet]
        public IActionResult GetProduct()
        {
            List<Product> products = productRepo.GetAll();
            return Ok(products);
        }
        
        [HttpGet("category/{categoryId:int}")]
        public IActionResult GetByCatId(int categoryId)
        {
            List<Product> products = productRepo.GetByCatId(categoryId);
            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "ProductDetails")]
        //[Route("{id}")]// /api/product/{id} or {id}
        public IActionResult GetById(int id)
        {
            Product product = productRepo.GetById(id);
            return Ok(product);
        }
        [HttpGet("search")]
        public IActionResult GetByCatId([FromQuery]int categoryId, [FromQuery] string name) 
        {
            List<Product> products = productRepo.GetByName(name,categoryId);
            return Ok(products);
        }

        [HttpPost]
        public IActionResult PostProduct([FromBody]Product newproduct)
        {
            
            if (ModelState.IsValid)
            {
                productRepo.Insert(newproduct);
                string url = Url.Link("ProductDetails", new { id = newproduct.Id });
                return Created(url, newproduct);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id:int}")]
        public IActionResult PutProduct(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                productRepo.Update(id, product);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                productRepo.Delete(id);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

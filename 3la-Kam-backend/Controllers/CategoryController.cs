using _3la_Kam_backend.Models;
using _3la_Kam_backend.Repositoris;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _3la_Kam_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryRipo CategoryRipo;

        public CategoryController(ICategoryRipo CategoryRipo)
        {
            this.CategoryRipo = CategoryRipo;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            List<Category> Categorys = CategoryRipo.GetAll();
            return Ok(Categorys);
        }
        [HttpGet("{id:int}", Name = "CategoryDetails")]
        //[Route("{id}")]// /api/Category/{id} or {id}
        public IActionResult GetById(int id)
        {
            Category Category = CategoryRipo.GetById(id);
            return Ok(Category);
        }
        [HttpPost]
        public IActionResult PostCategory(Category newCategory)
        {
            if (ModelState.IsValid)
            {
                CategoryRipo.Insert(newCategory);
                string url = Url.Link("CategoryDetails", new { id = newCategory.Id });
                return Created(url, newCategory);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id:int}")]
        public IActionResult PutCategory(int id, Category Category)
        {
            if (ModelState.IsValid)
            {
                CategoryRipo.Update(id, Category);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                CategoryRipo.Delete(id);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

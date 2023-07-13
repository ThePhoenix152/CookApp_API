using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cookapp_API.Data;
using Cookapp_API.DataAccess.BLL;
using Cookapp_API.DataAccess.DTO;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.CategoryDTO;

namespace Cookapp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CookingRecipeDbContext _context;
        private IConfiguration _configuration;

        public CategoriesController(CookingRecipeDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/Categoriess
        [HttpGet("getallcategories")]
        public async Task<ActionResult<List<CategoryDTO>>> GetCategories()
        {
           
            //return await _context.Accounts.ToListAsync();
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            List<CategoryDTO> accounts = bll.GetCategory();
            return accounts;
            //return await _context.Categories.ToListAsync();
        }


        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("updatecategorybyid")]
        public async Task<IActionResult> UpdateCate(string id, AddCategory category)
        {
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            bll.UpdateCate( id,  category);
            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("createnewcategory")]
        public async Task<ActionResult<AddCategory>> CreateCate(AddCategory category)
        {
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            bll.CreateCate(category);
            return category;
        }

        // DELETE: api/Categories/5
        [HttpDelete("deletecategorybyid")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            bll.DeleteCate(id);
            return NoContent();
        }

        private bool CategoryExists(string id)
        {
            return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

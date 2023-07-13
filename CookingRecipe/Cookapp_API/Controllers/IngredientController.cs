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
using Cookapp_API.DataAccess.DTO.AllInOneDTO.NutriDTO;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.IngredientDTO;

namespace Cookapp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly CookingRecipeDbContext _context;
        private IConfiguration _configuration;

        public IngredientController(CookingRecipeDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/Categoriess
        [HttpGet("getallingredient")]
        public async Task<ActionResult<List<IngredientDTO>>> GetIngre()
        {
           
            //return await _context.Accounts.ToListAsync();
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            List<IngredientDTO> accounts = bll.GetIngre();
            return accounts;
            //return await _context.Categories.ToListAsync();
        }


        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("updateingredientbyid")]
        public async Task<IActionResult> UpdateIngre(string id, HandleIngre ingre)
        {
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            bll.UpdateIngre( id,  ingre);
            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("createnewingre")]
        public async Task<ActionResult<HandleIngre>> CreateNutri(HandleIngre ingre)
        {
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            bll.CreateIngre(ingre);
            return ingre;
        }

        // DELETE: api/Categories/5
        [HttpDelete("deleteingredientbyid")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            bll.DeleteIngre(id);
            return NoContent();
        }

        private bool CategoryExists(string id)
        {
            return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

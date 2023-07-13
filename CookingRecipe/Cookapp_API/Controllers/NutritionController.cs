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

namespace Cookapp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutritionController : ControllerBase
    {
        private readonly CookingRecipeDbContext _context;
        private IConfiguration _configuration;

        public NutritionController(CookingRecipeDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/Categoriess
        [HttpGet("getallnutrition")]
        public async Task<ActionResult<List<NutriDTO>>> GetNutri()
        {
           
            //return await _context.Accounts.ToListAsync();
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            List<NutriDTO> accounts = bll.GetNutri();
            return accounts;
            //return await _context.Categories.ToListAsync();
        }


        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("updatenutribyid")]
        public async Task<IActionResult> UpdateCate(string id, HandleNutri nutri)
        {
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            bll.UpdateNutri( id,  nutri);
            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("createnewcnutri")]
        public async Task<ActionResult<HandleNutri>> CreateNutri(HandleNutri nutri)
        {
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            bll.CreateNutri(nutri);
            return nutri;
        }

        // DELETE: api/Categories/5
        [HttpDelete("deletecategorybyid")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            bll.DeleteNutri(id);
            return NoContent();
        }

        private bool CategoryExists(string id)
        {
            return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

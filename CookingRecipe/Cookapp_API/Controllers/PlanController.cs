using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cookapp_API.Data;
using Cookapp_API.DataAccess.BLL;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.PostDTO;
using Microsoft.Extensions.Hosting;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.PlanDTO;
using Microsoft.Identity.Client;
using System.Numerics;

namespace Cookapp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly CookingRecipeDbContext _context;
        private IConfiguration _configuration;


        public PlanController(CookingRecipeDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/Recipeposts
        [HttpGet]
        public async Task<ActionResult<List<GetPlanDTO>>> GetRecipeposts()
        {
            if (_context.Recipeposts == null)
            {
                return NotFound();
            }
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            List<GetPlanDTO> post = bll.GetPlans(new List<string>());
            return post;
        }

        // GET: api/Recipeposts/5
        [HttpGet("getplanbyaccountid")]
        public async Task<ActionResult<List<GetPlanDTO>>> GetPlan(string id)
        {
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            List<GetPlanDTO> post = bll.GetPlanByAccountID(id);
            return post;
        }
        [HttpGet("getlistbyday")]
        public async Task<ActionResult<List<GetTimeByDay>>> Gettimebyday(string id, string day)
        {
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            List<GetTimeByDay> post = bll.GetlistByDay(id,day);
            return post;
        }

        // P: api/Recipeposts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("addPlanatexisttime")]
        public async Task<ActionResult<ConfirmAdd>> PostRecipepost(ConfirmAdd plan, string postid, string accountid, string day, string starttime, string endtime)
        {

            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            bll.CreatePlanAtExistTime(plan, postid, accountid, day, starttime, endtime);
            return plan;
        }
        [HttpPost("addPlanatnewtime")]
        public async Task<ActionResult<AddNewPlan>> PostRecipepost2(AddNewPlan plan, string postid, string accountid)
        {
            
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            bll.CreatePlanAtNewTime(plan, postid, accountid);
            return plan;
        }


        //// POST: api/Recipeposts
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<CreatePostDTO>> PostRecipepost(CreatePostDTO post)
        //{
        //  if (_context.Recipeposts == null)
        //  {
        //      return Problem("Entity set 'CookingRecipeDbContext.Recipeposts'  is null.");
        //  }
        //    AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
        //    bll.CreatePost(post);
        //    return post;

        //}

        // DELETE: api/Recipeposts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipepost(string id)
        {
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            bll.DeletePostFromPlan(id);
            return NoContent();
        }

        //private bool RecipepostExists(string id)
        //{
        //    return (_context.Recipeposts?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}

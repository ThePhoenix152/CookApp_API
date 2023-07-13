using Cookapp_API.Data;
using Cookapp_API.DataAccess.BLL;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.AccoountDTO;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.BlacklistDTO;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.PostDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cookapp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlacklistController : ControllerBase
    {
        private readonly CookingRecipeDbContext _context;
        private IConfiguration _configuration;
        public BlacklistController(CookingRecipeDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/blacklist
        [HttpGet]
        public async Task<ActionResult<List<BlacklistDTO>>> GetBlacklist()
        {
            
            //return await _context.Accounts.ToListAsync();
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            List<BlacklistDTO> blacklist = bll.GetBlackList(new List<string>());
            return blacklist;
        }
        [HttpPut("changeBan")]
        public async Task<ActionResult<banblacklist>> UpdateBanBlackList(string id, banblacklist set)
        {
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            bll.UpdateBanBlackList(id, set);
            return set;
        }
        [HttpPut("UpdateAccountStatus")]
        public async Task<IActionResult> UpdateAccountStatus()
        {
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            bll.UpdateAccountStatus();
            return NoContent();
        }
    }
}

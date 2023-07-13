using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cookapp_API.Data;
using Cookapp_API.DataAccess.BLL;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.AccoountDTO;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.CommentDTO;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.PostDTO;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.BlacklistDTO;

namespace Cookapp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CookingRecipeDbContext _context;
        private IConfiguration _configuration;
        public CommentsController(CookingRecipeDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/Comments
        [HttpGet]

        public async Task<ActionResult<List<CommentDTO>>> GetComments()
        {
            //return await _context.Accounts.ToListAsync();
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            List<CommentDTO> comments = bll.GetComments(new List<string>());
            return comments;
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<CommentDTO>>> GetCommentsByPostID(string id)
        {
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            List<CommentDTO> comments = bll.GetCommentsByPostID(id);
            return comments;

        }

     

        // POST: api/Comments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AddNewComment>> PostComment(AddNewComment comment, string accountid, string postid)
        {
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            bll.CreateComment(comment, accountid, postid);
            return comment;
        }
        // POST: api/Comments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("ReportComment")]
        public async Task<ActionResult<AddBlacklist>> ReportComment(AddBlacklist blacklist, string accountid, string id)
        {
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            bll.ReportComment(blacklist, accountid, id);
            return blacklist;
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(string id)
        {
            if (_context.Comments == null)
            {
                return NotFound();
            }
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommentExists(string id)
        {
            return (_context.Comments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

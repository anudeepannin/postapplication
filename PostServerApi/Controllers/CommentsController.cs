using Microsoft.AspNetCore.Mvc;
using PostServerApi.Model;
using PostServerApi.Services;
using System.Threading.Tasks;

namespace PostServerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsServices _CommentsServices;
        public CommentsController (ICommentsServices CommentsServices)
        {
            _CommentsServices = CommentsServices;
        }
        
        [Route("GetComments/{PostId}")]
        [HttpGet]
        public async Task<IActionResult> CommentsGet(int PostId)
        {
                var response = await _CommentsServices.GetComments(PostId);
                return Ok(response);
        }

        [Route("CreateComment")]
        [HttpPost]
        public async Task<IActionResult> CreateComment(Comment c1)
        {
            if (c1 !=null &&  c1.CommentText!=null && c1.CommentText!=" ")
            {
                await _CommentsServices.InsertComments(c1);
                return Ok("Comments Added Successfully");
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("UpdateComment")]
        [HttpPut]
        public async Task<IActionResult> UpdateComment(Comment c1)
        {
            if (c1 != null )
            {
                await _CommentsServices.UpdateCommentsdata(c1);
                return Ok("Comments  Updated Successfully");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}



   

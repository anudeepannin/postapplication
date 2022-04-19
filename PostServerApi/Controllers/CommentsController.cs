using Microsoft.AspNetCore.Mvc;
using PostServerApi.Constants;
using PostServerApi.Models;
using PostServerApi.Services;
using System;
using System.Threading.Tasks;

namespace PostServerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsServices _CommentsServices;
        public CommentsController(ICommentsServices CommentsServices)
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
            if (!String.IsNullOrEmpty(c1.CommentText))
            {
                await _CommentsServices.InsertComments(c1);
                return Ok(AppConstant.CommentSucces);
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("UpdateComment/{Id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateComment(int id, Comment c1)
        {
            if (c1 != null)
            {
                await _CommentsServices.UpdateCommentsData(id, c1);
                return Ok(AppConstant.CommentUpdate);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}





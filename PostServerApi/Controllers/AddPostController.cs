using Microsoft.AspNetCore.Mvc;
using PostServerApi.Services;
using PostServerApi.Model;
using System.Threading.Tasks;

namespace PostServerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AddPostController : ControllerBase
    {
        private readonly IAddPostServices _AddPostServices;
        public AddPostController( IAddPostServices addPostServices)
        {
            _AddPostServices = addPostServices;
        }
        [Route("GetPosts")]
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var response = await _AddPostServices.GetPostData();
            return Ok(response);
        }

        [Route("CreatePost")]
        [HttpPost]
        public async Task<IActionResult> CreatePost(Post p1)
        {
            if (p1 != null && p1.PostTittle!=null && p1.DescriptionOfPost !=null && p1.DescriptionOfPost!=" " && p1.PostTittle!=" ")
            {
                await _AddPostServices.InsertPostData(p1);
                return Ok("Posted Successfully");
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("UpdatePost")]
        [HttpPut]
        public async Task<IActionResult> UpdatePost(Post p1)
        {
            if (p1 != null )
            {
                await _AddPostServices.UpdatepostData(p1);
                return Ok("Post Updated Successfully");
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("POSTLIKE")]
        [HttpPut]
        public async Task<IActionResult> POSTLIKE(Post p1)
        {
            if (p1 != null )
            {
                await _AddPostServices.UpdateLike(p1);
                return Ok("LikesCount Updated Successfully");
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("POSTHEART")]
        [HttpPut]
        public async Task<IActionResult> POSTHEART(Post p1)
        {
            if (p1 != null )
            {
                await _AddPostServices.UpdateHeart(p1);
                return Ok(" HeartsCount Updated Successfully");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}






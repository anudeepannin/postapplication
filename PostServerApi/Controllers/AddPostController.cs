using Microsoft.AspNetCore.Mvc;
using PostServerApi.Services;
using System.Threading.Tasks;
using PostServerApi.Models;
using System;
using PostServerApi.Constants;

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
            if (!String.IsNullOrEmpty(p1.PostTittle)&& !String.IsNullOrEmpty(p1.DescriptionOfPost))
            {
                await _AddPostServices.InsertPostData(p1);
                return Ok(AppConstant.PostSucces);
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("UpdatePost/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdatePost(int id,Post p1)
        {
            if (p1 != null)
            {

                var updatedPost = await _AddPostServices.UpdatepostData(id,p1);
                if (updatedPost == null)
                    return NotFound();
                return Ok(AppConstant.PostUpdate);
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("PostLike/{id}")]
        [HttpPut]
        public async Task<IActionResult> PostLike(int id,Post p1)
        {
            if (p1 != null )
            {
               var updateLike= await _AddPostServices.UpdateLike(id,p1);
                if (updateLike == null)
                    return NotFound();
                return Ok(AppConstant.PostLike);
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("PostHeart/{id}")]
        [HttpPut]
        public async Task<IActionResult> PostHeart(int id,Post p1)
        {
            if (p1 != null )
            {
              var updateHeart=  await _AddPostServices.UpdateHeart(id, p1);
                if (updateHeart == null)
                    return NotFound();
                return Ok(AppConstant.PostHeart);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}






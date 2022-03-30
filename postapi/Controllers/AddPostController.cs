using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using postapi.Model;
using postapi.Repository;

namespace postapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AddPostController : ControllerBase
    {
        private readonly IAddPostRepository _AddPostRepository;
        public AddPostController( IAddPostRepository addPostRepository)
        {
            _AddPostRepository = addPostRepository;
        }
        [Route("GetPosts")]
        [HttpGet]   
        public IActionResult GetPosts()
        {
            try
            {
                var response = _AddPostRepository.GetPosts();
                return Ok(response);
            }
            catch(Exception )
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        [Route("CreatePost")]
        [HttpPost]
        public IActionResult CreatePost(Post p1)
        {

            try
            {
                 _AddPostRepository.CreatePost(p1);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            return Ok("Posted Successfully");

        }
        [Route("UpdatePost")]
        [HttpPut]
        public IActionResult UpdatePost(Post p1)
        {
            try
            {

                _AddPostRepository.UpdatePost(p1);
                
            }
            catch(Exception)
            {
                return BadRequest();
            }
            return Ok("Post Updated Successfully");
        }

        [Route("POSTLIKE")]
        [HttpPut]
        public IActionResult POSTLIKE(Post p1)
        {
            try
            {
                _AddPostRepository.POSTLIKE(p1);
            }
            catch(Exception)
            {
                return BadRequest();
            }
            return Ok("LikesCount Updated Successfully");
        }





        [Route("POSTHEART")]
        [HttpPut]
        public IActionResult POSTHEART(Post p1)
        {
            try
            {
                _AddPostRepository.POSTHEART(p1);
            }
            catch(Exception)
            {
                return BadRequest();
            }

            return Ok(" HeartsCount Updated Successfully");
        }


    }

}
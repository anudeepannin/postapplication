
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using postapi.Model;
using postapi.Repository;
using System;
using System.Data;
using System.Data.SqlClient;

namespace postapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {


        private readonly ICommentsRepository _CommentsRepository;
        public CommentsController (ICommentsRepository CommentsRepository)
        {
            _CommentsRepository =CommentsRepository;
        }
        

        [Route("GetComments/{PostId}")]
        [HttpGet]
        public IActionResult CommentsGet(int PostId)
        {
            try
            {
                var response = _CommentsRepository.CommentsGet( PostId);
                return Ok(response);

            }
            catch(Exception)
            {
                return BadRequest();
            }
           
        }

        [Route("CreateComment")]
        [HttpPost]
        public IActionResult CreateComment(Comment c1)
        {
            try
            {
                _CommentsRepository.CreateComment(c1);

            }
            catch(Exception)
            {
                return BadRequest();
            }

            return Ok("Comments Added Successfully");
        }

        [Route("UpdateComment")]
        [HttpPut]
        public IActionResult UpdateComment(Comment c1)
        {
            try
            {
                _CommentsRepository.UpdateComment(c1);
            }
            catch(Exception)
            {
                return BadRequest();
            }
            return Ok("Comments  Updated Successfully");
        }

       
    }
}



   

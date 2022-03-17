
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using postapi.Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace postapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {


        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public CommentsController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [Route("GetComments")]
        [HttpGet]
        public IActionResult CommentsGet()
        {
            DataTable table = new DataTable();
            try
            {

                string query = @"
                            select CommentID ,CommentText,PostID, CommentsCreatedDate, CommentsUpdatedDate
                            from
                            dbo.Comments
                            ";

                string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        myCon.Close();
                    }
                }
            }
            catch(Exception)
            {
                return BadRequest();
            }
            return Ok(table);
        }

        [Route("CreateComment")]
        [HttpPost]
        public IActionResult CreateComment(Comment c1)
        {
            try
            {

                string query = @"
                           insert into dbo.Comments
                           ( CommentText,PostID,CommentsCreatedDate,CommentsupdatedDate)
                           values (@CommentText,@PostID,@CommentsCreatedDate,@CommentsUpdatedDate)
                           ";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {

                        myCommand.Parameters.AddWithValue("@CommentText", c1.CommentText);
                        myCommand.Parameters.AddWithValue("@PostID", c1.PostID);
                        myCommand.Parameters.AddWithValue("@CommentsCreatedDate", DateTime.Now);
                        myCommand.Parameters.AddWithValue("@CommentsUpdatedDate", DateTime.Now);
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        myCon.Close();
                    }
                }
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
                string query = @"
                           update dbo.Comments
                           set CommentText=@CommentText 
                            where CommentID = @CommentID
                            ";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@CommentID", c1.CommentID);
                        myCommand.Parameters.AddWithValue("@CommentText", c1.CommentText);
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        myCon.Close();
                    }
                }
            }
            catch(Exception)
            {
                return BadRequest();
            }
            return Ok("Comments  Updated Successfully");
        }

       
    }
}



   

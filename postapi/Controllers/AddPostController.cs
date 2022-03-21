﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using postapi.Model;

namespace postapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AddPostController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public AddPostController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [Route("GetPosts")]
        [HttpGet]
        public IActionResult GetPosts()
        {
            DataTable table = new DataTable();
            try
            {
                string query = @"
             select  PostID,PostTittle,DescriptionOfPost, CreatedDate, UpdatedDate,LikesCount, HeartCount
            from
            dbo.Post
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
        [Route("CreatePost")]
        [HttpPost]
        public IActionResult CreatePost(Post p1)
        {
            try
            {


                string query = @"
                           insert into dbo.Post
                           values (@PostTittle,@DescriptionOfPost, @CreatedDate, @UpdatedDate,@LikesCount,@HeartCount)
                            ";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {

                        myCommand.Parameters.AddWithValue("@PostTittle", p1.PostTittle);
                        myCommand.Parameters.AddWithValue("@DescriptionOfPost", p1.DescriptionOfPost);
                        myCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                        myCommand.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
                        myCommand.Parameters.AddWithValue("@LikesCount", 0);
                        myCommand.Parameters.AddWithValue("@HeartCount", 0);
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
             return Ok("Posted Successfully");
        }
        [Route("UpdatePost")]
        [HttpPut]
        public IActionResult UpdatePost(Post p1)
        {
            try
            {
                string query = @"
                           update dbo.Post
                           set PostTittle= @PostTittle,
                              
                               DescriptionOfPost=@DescriptionOfPost
                            where PostID=@PostID
                            ";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@PostID", p1.PostID);
                        myCommand.Parameters.AddWithValue("@PostTittle", p1.PostTittle);
                        myCommand.Parameters.AddWithValue("@DescriptionofPost", p1.DescriptionOfPost);
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
            return Ok("Post Updated Successfully");
        }

        [Route("POSTLIKE")]
        [HttpPut]
        public IActionResult POSTLIKE(Post p1)
        {
            try
            {
                string query = @"
                           update dbo.Post
                           set LikesCount= @LikesCount
                            where PostID=@PostID
                            ";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@PostID", p1.PostID);
                        myCommand.Parameters.AddWithValue("@LikesCount", p1.LikesCount);
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
            return Ok("LikesCount Updated Successfully");
        }





        [Route("POSTHEART")]
        [HttpPut]
        public IActionResult POSTHEART(Post p1)
        {
            try
            {
                string query = @"
                           update dbo.Post
                           set HeartCount= @HeartCount
                            where PostID=@PostID
                            ";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@PostID", p1.PostID);
                        myCommand.Parameters.AddWithValue("@HeartCount", p1.HeartCount);
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

            return Ok(" HeartsCount Updated Successfully");
        }


    }

}
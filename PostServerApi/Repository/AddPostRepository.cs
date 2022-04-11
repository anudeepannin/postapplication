using Microsoft.Extensions.Configuration;
using PostServerApi.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PostServerApi.Repository
{
    public class AddPostRepository:IAddPostRepository
    {
        private readonly IConfiguration _configuration;
        public AddPostRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<Post>> GetPosts()
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"
             select  PostID,PostTittle,DescriptionOfPost, CreatedDate, UpdatedDate,LikesCount, HeartCount from dbo.Post";
                string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myReader = await myCommand.ExecuteReaderAsync();
                        table.Load(myReader);
                        myReader.Close();
                        myCon.Close();
                    }
                }
                List<Post> postList = new List<Post>();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Post post = new Post()
                    {
                        PostID = Convert.ToInt32(table.Rows[i]["PostID"]),
                        PostTittle = table.Rows[i]["PostTittle"].ToString(),
                        DescriptionOfPost = table.Rows[i]["DescriptionOfPost"].ToString(),
                        CreatedDate = Convert.ToDateTime(table.Rows[i]["CreatedDate"]),
                        UpdatedDate = Convert.ToDateTime(table.Rows[i]["UpdatedDate"]),
                        LikesCount = Convert.ToInt32(table.Rows[i]["LikesCount"]),
                        HeartCount = Convert.ToInt32(table.Rows[i]["HeartCount"])
                    };
                    postList.Add(post);
                }
                return postList;
            }
            catch (Exception)
            {
                throw new Exception(" This method is not implemented");
            }
        }

     public   async Task CreatePost(Post p1)
     {
            try
            { 
                string query = @"insert into dbo.Post values (@PostTittle,@DescriptionOfPost, @CreatedDate, @UpdatedDate,@LikesCount,@HeartCount)";
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
                        myReader = await myCommand.ExecuteReaderAsync();
                        table.Load(myReader);
                        myReader.Close();
                        myCon.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception(" This method is not implemented");
            }
        }

        public async Task UpdatePost(Post p1)
        {
            try
            {
                string query = @"update dbo.Post set PostTittle= @PostTittle, DescriptionOfPost=@DescriptionOfPost where PostID=@PostID";
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
                        myReader = await myCommand.ExecuteReaderAsync();
                        table.Load(myReader);
                        myReader.Close();
                        myCon.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception(" This method is not implemented");
            }
        }

        public async Task POSTLIKE(Post p1)
        {
            try
            {
                string query = @"
                           update dbo.Post set LikesCount= @LikesCount where PostID=@PostID ";

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
                        myReader = await myCommand.ExecuteReaderAsync();
                        table.Load(myReader);
                        myReader.Close();
                        myCon.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception(" This method is not implemented");
            }
        }

        public async Task POSTHEART(Post p1)
        {
            try
            {
                string query = @"
                           update dbo.Post set HeartCount= @HeartCount where PostID=@PostID ";

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
                        myReader = await myCommand.ExecuteReaderAsync();
                        table.Load(myReader);
                        myReader.Close();
                        myCon.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception(" This method is not implemented");
            }
        }
    }
}

using Microsoft.Extensions.Configuration;
using postapi.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace postapi.Repository
{
    public class CommentsRepository:ICommentsRepository
    {
        private readonly IConfiguration _configuration;
        public CommentsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Comment> CommentsGet(int PostId)
        {

            DataTable table = new DataTable();
            string query = @"
                            select CommentID ,CommentText,PostID, CommentsCreatedDate, CommentsUpdatedDate
                            from
                            dbo.Comments
                               where PostID=@PostID
                            ";

            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@PostID", PostId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            List<Comment> CommentList = new List<Comment>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Comment comment = new Comment()
                {
                    PostID = Convert.ToInt32(table.Rows[i]["PostID"]),
                    CommentID = Convert.ToInt32(table.Rows[i]["CommentID"]),
                    CommentText = table.Rows[i]["CommentText"].ToString(),
                    CommentsCreatedDate = Convert.ToDateTime(table.Rows[i]["CommentsCreatedDate"]),
                    CommentsUpdatedDate = Convert.ToDateTime(table.Rows[i]["CommentsUpdatedDate"]),

                };
                CommentList.Add(comment);
            }
            return CommentList;
        }

       

        public void CreateComment(Comment c1)
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


        public void UpdateComment(Comment c1)
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

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using postapi.Controllers;
using postapi.Model;
using postapi.Repository;
using System;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace XunitTestingForApi
{
    public class CommentsUnitTest
    {
        [Fact]
        public void GetComments_Returns_All_Comments()
        {
            var id = 1;
            var mockRepo = new Mock<ICommentsRepository>();
            mockRepo.Setup(repo => repo.CommentsGet(id))
            .Returns(GetTestComments());
            var controller = new CommentsController(mockRepo.Object);
            var result = controller.CommentsGet(id);
            var objectResult = (ObjectResult)result;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)objectResult.StatusCode);
            Assert.Collection((List<Comment>)objectResult.Value,
                item =>
                {
                    Assert.Equal(1, item.CommentID);
                    Assert.Equal(1, item.PostID);
                    Assert.Equal("Test Comment", item.CommentText);
                    Assert.Equal(Convert.ToDateTime("22-01-2021"), item.CommentsCreatedDate);
                    Assert.Equal(Convert.ToDateTime("23-01-2021"), item.CommentsUpdatedDate);
                });
        }

        [Fact]
        public void CreateComments_Returns_Comments()
        {
            var mockRepo = new Mock<ICommentsRepository>();
            var Comment = new Comment()
            {
                CommentText = "Testcomments"
            };
            mockRepo.Setup(repo => repo.CreateComment(Comment));
            var controller = new CommentsController(mockRepo.Object);
            var result = controller.CreateComment(Comment);
            var objectResult = (ObjectResult)result;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)objectResult.StatusCode);
        }

        [Fact]
        public void UpdateComments_Returns_P()
        {
            var mockRepo = new Mock<ICommentsRepository>();
            var Comment = new Comment()
            {
                CommentText = "Testcomments"
            };
            mockRepo.Setup(repo => repo.UpdateComment(Comment));
            var controller = new CommentsController(mockRepo.Object);
            var result = controller.UpdateComment(Comment);
            var objectResult = (ObjectResult)result;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)objectResult.StatusCode);
        }
        private List<Comment> GetTestComments()
        {
            List<Comment> Comments = new List<Comment>();
            Comments.Add(new Comment()
            {
                PostID = 1,
                CommentID = 1,
                CommentText = "Test Comment",
                CommentsCreatedDate = Convert.ToDateTime("22-01-2021"),
                CommentsUpdatedDate = Convert.ToDateTime("23-01-2021")

            });
            return Comments;
        }
    }
}

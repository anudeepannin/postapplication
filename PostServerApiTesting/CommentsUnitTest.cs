using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PostServerApi.Controllers;
using PostServerApi.Models;
using PostServerApi.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace XunitTestingForApi
{
    public class CommentsUnitTest
    {
        [Fact]
        public async void GetComments_Returns_All_Comments()
        {
            var id = 1;
            var mockRepo = new Mock<ICommentsServices>();
            mockRepo.Setup(repo => repo.GetComments(id))
            .Returns(GetTestComments());
            var controller = new CommentsController(mockRepo.Object);
            var result = await controller.CommentsGet(id);
            var objectResult = (ObjectResult)result;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)objectResult.StatusCode);
            Assert.Collection((List<Comment>)objectResult.Value,
                item =>
                {
                    Assert.Equal(1, item.CommentId);
                    Assert.Equal(1, item.PostId);
                    Assert.Equal("Test Comment", item.CommentText);
                    Assert.Equal(Convert.ToDateTime("22-01-2021"), item.CommentsCreatedDate);
                    Assert.Equal(Convert.ToDateTime("23-01-2021"), item.CommentsUpdatedDate);
                });
        }

        [Fact]
        public async void CreateComments_Returns_Comments()
        {
            var mockRepo = new Mock<ICommentsServices>();
            var Comment = new Comment()
            {
                CommentText = "Testcomments"
            };
            mockRepo.Setup(repo => repo.InsertComments(Comment));
            var controller = new CommentsController(mockRepo.Object);
            var result = await controller.CreateComment(Comment);
            var objectResult = (ObjectResult)result;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)objectResult.StatusCode);
        }

        [Fact]
        public async void UpdateComments_Returns_P()
        {
            var mockRepo = new Mock<ICommentsServices>();
            var Comment = new Comment()
            {
                CommentText = "Testcomments"
            };
            mockRepo.Setup(repo => repo.UpdateCommentsData(1,Comment));
            var controller = new CommentsController(mockRepo.Object);
            var result = await controller.UpdateComment(1,Comment);
            var objectResult = (ObjectResult)result;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)objectResult.StatusCode);
        }
        private Task<List<Comment>> GetTestComments()
        {
            List<Comment> Comments = new List<Comment>();
            Comments.Add(new Comment()
            {
                PostId = 1,
                CommentId = 1,
                CommentText = "Test Comment",
                CommentsCreatedDate = Convert.ToDateTime("22-01-2021"),
                CommentsUpdatedDate = Convert.ToDateTime("23-01-2021")
            });
            return Task.FromResult(Comments);
        }
    }
}

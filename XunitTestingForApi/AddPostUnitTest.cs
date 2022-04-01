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
    public class AddPostUnitTest1
    {
        [Fact]
        public void GetPosts_Returns_All_posts()
        {
            var mockRepo = new Mock<IAddPostRepository>();
            mockRepo.Setup(repo => repo.GetPosts())
            .Returns(GetTestPost());
            var controller = new AddPostController(mockRepo.Object);
            var result = controller.GetPosts();
            var objectResult = (ObjectResult)result;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)objectResult.StatusCode);
            Assert.Collection((List<Post>)objectResult.Value,
                item =>
                {
                    Assert.Equal(1, item.PostID);
                    Assert.Equal("Test post", item.PostTittle);
                    Assert.Equal("Test desc", item.DescriptionOfPost);
                    Assert.Equal("Test desc", item.DescriptionOfPost);
                    Assert.Equal(Convert.ToDateTime("22-01-2021"), item.CreatedDate);
                    Assert.Equal(Convert.ToDateTime("23-01-2021"), item.UpdatedDate);
                    Assert.Equal(1, item.LikesCount);
                    Assert.Equal(1, item.HeartCount);
                });
        }

        [Fact]
        public void CreatePost_Returns_Post()
        {
            var mockRepo = new Mock<IAddPostRepository>();
            var post = new Post()
            {
                PostTittle = "Test post",
                DescriptionOfPost = "description"
            };
            mockRepo.Setup(repo => repo.CreatePost(post));
            var controller = new AddPostController(mockRepo.Object);
            var result = controller.CreatePost(post);
            var objectResult = (ObjectResult)result;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)objectResult.StatusCode);
        }

        [Fact]
        public void UpdatePost_Returns_Post()
        {
            var mockRepo = new Mock<IAddPostRepository>();
            var post = new Post()
            {
                PostTittle = "Test post",
                DescriptionOfPost = "description"
            };
            mockRepo.Setup(repo => repo.UpdatePost(post));
            var controller = new AddPostController(mockRepo.Object);

            var result = controller.UpdatePost(post);
            var objectResult = (ObjectResult)result;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)objectResult.StatusCode);
        }

        [Fact]
        public void UpdatePostLikes_Returns_PostLikes()
        {
            var mockRepo = new Mock<IAddPostRepository>();
            var post = new Post()
            {
                LikesCount = 1
            };
            mockRepo.Setup(repo => repo.POSTLIKE(post));
            var controller = new AddPostController(mockRepo.Object);
            var result = controller.POSTLIKE(post);
            var objectResult = (ObjectResult)result;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)objectResult.StatusCode);
        }

        [Fact]
        public void UpdatePostHearts_Returns_PostHearts()
        {
            var mockRepo = new Mock<IAddPostRepository>();
            var post = new Post()
            {
                HeartCount = 1
            };
            mockRepo.Setup(repo => repo.POSTHEART(post));
            var controller = new AddPostController(mockRepo.Object);
            var result = controller.POSTHEART(post);
            var objectResult = (ObjectResult)result;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)objectResult.StatusCode);
        }


        private List<Post> GetTestPost()
        {
            List<Post> posts = new List<Post>();
            posts.Add(new Post()
            {
                PostID = 1,
                PostTittle = "Test post",
                DescriptionOfPost = "Test desc",
                CreatedDate = Convert.ToDateTime("22-01-2021"),
                UpdatedDate = Convert.ToDateTime("23-01-2021"),
                LikesCount = 1,
                HeartCount = 1
            });
            return posts;
        }
    }
}

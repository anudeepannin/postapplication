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
    public class AddPostUnitTest
    {
        [Fact]
        public async void GetPosts_Returns_All_posts()
        {
            var mockRepo = new Mock<IAddPostServices>();
            mockRepo.Setup(repo => repo.GetPostData())
            .Returns(GetTestPost());
            var controller = new AddPostController(mockRepo.Object);
            var result = await controller.GetPosts();
            var objectResult = result as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)objectResult.StatusCode);
            Assert.Collection((List<Post>)objectResult.Value,
                item =>
                {
                    Assert.Equal(1, item.PostId);
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
        public async void CreatePost_Returns_Post()
        {
            var mockRepo = new Mock<IAddPostServices>();
            var post = new Post()
            {
                PostTittle = "Test post",
                DescriptionOfPost = "description"
            };
            mockRepo.Setup(repo => repo.InsertPostData(post));
            var controller = new AddPostController(mockRepo.Object);
            var result = await controller.CreatePost(post);
            var objectResult = result as ObjectResult;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)objectResult.StatusCode);
        }

        [Fact]
        public async void UpdatePost_Returns_Post()
        {
            var mockRepo = new Mock<IAddPostServices>();
            var post = new Post()
            {
                PostTittle = "Test post",
                DescriptionOfPost = "description"
            };
            mockRepo.Setup(repo => repo.UpdatepostData(1, post));
            var controller = new AddPostController(mockRepo.Object);
            var result = await controller.UpdatePost(1,post);
            var objectResult = (ObjectResult)result;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)objectResult.StatusCode);
        }

        [Fact]
        public async void UpdatePostLikes_Returns_PostLikes()
        {
            var mockRepo = new Mock<IAddPostServices>();
            var post = new Post()
            {
                LikesCount = 1
            };
            mockRepo.Setup(repo => repo.UpdateLike(1,post));
            var controller = new AddPostController(mockRepo.Object);
            var result = await controller.PostLike(1,post);
            var objectResult = (ObjectResult)result;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)objectResult.StatusCode);
        }

        [Fact]
        public async void UpdatePostHearts_Returns_PostHearts()
        {
            var mockRepo = new Mock<IAddPostServices>();
            var post = new Post()
            {
                HeartCount = 1
            };
            mockRepo.Setup(repo => repo.UpdateHeart(1,post));
            var controller = new AddPostController(mockRepo.Object);
            var result = await controller.PostHeart(1,post);
            var objectResult = (ObjectResult)result;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)objectResult.StatusCode);
        }


        private Task<List<Post>> GetTestPost()
        {
            List<Post> posts = new List<Post>();
            posts.Add(new Post()
            {
                PostId = 1,
                PostTittle = "Test post",
                DescriptionOfPost = "Test desc",
                CreatedDate = Convert.ToDateTime("22-01-2021"),
                UpdatedDate = Convert.ToDateTime("23-01-2021"),
                LikesCount = 1,
                HeartCount = 1
            });
            return Task.FromResult(posts);
        }
    }
}

using Xunit;
using SocialNetwork.Domain.Tags;
using System.Collections.Generic;
using SocialNetwork.Domain.Shared;
using Moq;
using System;

namespace Test.Domain.Tags
{
    public class TagServiceUnitTeste
    {
        [Fact]
        public async void GetAllAsyncTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRepoTag = new Mock<ITagRepository>();

            List<Tag> l = new List<Tag>();
            var e1 = new Tag("engenharia");
            var e2 = new Tag("medicina");
            var e3 = new Tag("ford");

            l.Add(e1);
            l.Add(e2);
            l.Add(e3);

            List<TagDto> exp = new List<TagDto>();
            exp.Add(TagMapper.toDto(e1));
            exp.Add(TagMapper.toDto(e2));
            exp.Add(TagMapper.toDto(e3));

            mockRepoTag.Setup(repo => repo.GetAllAsync()).ReturnsAsync(l);

            var service = new TagService(mockUnitOfWork.Object, mockRepoTag.Object);

            List<TagDto> act = await service.GetAllAsync();

           // Assert.Equal(exp, act);
        }

        [Fact]
        public async void GetByIdAsyncTest()
        {
            var mockRepoTag = new Mock<ITagRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var tag = new Tag("engenharia");
            var exp = TagMapper.toDto(tag);

            mockRepoTag.Setup(repo => repo.GetByIdAsync(It.IsAny<TagId>())).ReturnsAsync(tag);

            var service = new TagService(mockUnitOfWork.Object, mockRepoTag.Object);
            var act = await service.GetByIdAsync(tag.Id);
            Assert.Equal(exp.Id, act.Id);
        }

        [Fact]
        public async void AddAsyncTest()
        {
            var mockRepoTag = new Mock<ITagRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var tag = new Tag("engenharia");
            var exp = TagMapper.toDto(tag);

            mockRepoTag.Setup(repo => repo.AddAsync(tag)).ReturnsAsync(tag);

            var service = new TagService(mockUnitOfWork.Object, mockRepoTag.Object);
            var act = await service.AddAsync(exp);

            Assert.IsType<String>(act.Id);
        }
    }
}
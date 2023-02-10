using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using SocialNetwork.Controllers;
using SocialNetwork.Domain.Tags;
using SocialNetwork.Domain.Shared;
using Xunit;
using Assert = Xunit.Assert;


namespace Test.Controller
{
    public class TagsControllerTest
    {
        

       [Fact]
        public async Task GetAllAsyncTest()
        {
            var repository = new Mock<ITagRepository>();
            repository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(new List<Tag>()));
            
            var unitOfWork = new Mock<IUnitOfWork>();

            TagService service = new TagService(unitOfWork.Object, repository.Object);
            TagsController controller = new  TagsController(service);

            var result = await controller.GetAll();
            repository.Verify(repo => repo.GetAllAsync(), Times.AtLeastOnce);
        }
         
        [Fact]
        public async Task GetGetGetByIdTest()
        {
            Guid id = new Guid();
            
            var repo = new Mock<ITagRepository>();
            repo.Setup(repository => repository.GetByIdAsync(It.IsAny<TagId>()));
            
            var unitOfWork = new Mock<IUnitOfWork>();
            
            TagService service = new TagService(unitOfWork.Object, repo.Object);
            TagsController controller = new TagsController(service);

            var result = await controller.GetGetById(id.ToString());

            repo.Verify(repository => repository.GetByIdAsync(It.IsAny<TagId>()), Times.AtLeastOnce());
        }
        
      [Fact]
        public async Task CreateTest()
        {
            Tag es = new Tag("carro");

            TagDto tagDto = TagMapper.toDto(es);
            var repo = new Mock<ITagRepository>();
            repo.Setup(repository => repository.AddAsync(It.IsAny<Tag>())).Returns(Task.FromResult(es));
            
            var unitOfWork = new Mock<IUnitOfWork>();
            
            TagService service = new TagService(unitOfWork.Object, repo.Object);
            TagsController controller = new TagsController(service);

            var result = await controller.Create(tagDto);

            repo.Verify(repository => repository.AddAsync(It.IsAny<Tag>()), Times.AtLeastOnce());
            unitOfWork.Verify(unit => unit.CommitAsync(), Times.AtLeastOnce);
        }
        
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemsControllerTests.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Tests.Crafting.Controllers
{
    using System.Threading.Tasks;

    using AutoMapper;

    using Moq;

    using NUnit.Framework;

    using ParkSquare.Testing.Helpers;

    using Roboworld.Recipes.WebApi.Controllers;
    using Roboworld.Recipes.WebApi.Dto;
    using Roboworld.Recipes.WebApi.Orm;
    using Roboworld.Recipes.WebApi.Persistance;

    [TestFixture]
    public class ItemsControllerTests
    {
        private Mock<IItemsRepository> mockRepository;

        private Mock<IMapper> mockMapper;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new Mock<IItemsRepository>();
            this.mockMapper = new Mock<IMapper> { DefaultValue = DefaultValue.Mock };
        }

        [Test]
        public async Task PutItem_WhenCalled_ShouldCheckForExistingItem()
        {
            var mod = StringGenerator.AnyNonNullString();
            var name = StringGenerator.AnyNonNullString();
            var item = new PutItemRequest();

            var sut = this.BuildDefaultSubjectUnderTest();
            await sut.PutByModAndName(mod, name, item);

            this.mockRepository.Verify(o => o.GetByModAndNameAsync(mod, name), Times.Once);
        }

        [Test]
        public async Task PutItem_WhenItemExists_ShouldSaveTheSameItem()
        {
            var existing = new Item();
            var item = new PutItemRequest();

            this.mockRepository
                .Setup(o => o.GetByModAndNameAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(existing);

            var sut = this.BuildDefaultSubjectUnderTest();
            await sut.PutByModAndName(StringGenerator.AnyNonNullString(), StringGenerator.AnyNonNullString(), item);

            this.mockRepository.Verify(o => o.SaveAsync(existing), Times.Once);
        }

        [Test]
        public async Task PutItem_WhenItemExists_ShouldMapToUpdateItem()
        {
            var existing = new Item();
            var item = new PutItemRequest();

            this.mockRepository
                .Setup(o => o.GetByModAndNameAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(existing);

            var sut = this.BuildDefaultSubjectUnderTest();
            await sut.PutByModAndName(StringGenerator.AnyNonNullString(), StringGenerator.AnyNonNullString(), item);

            this.mockMapper.Verify(o => o.Map(item, existing), Times.Once);
        }

        [Test]
        public async Task PutItem_WhenItemDoesNotExist_ShouldTryToFindMod()
        {
            var mod = StringGenerator.AnyNonNullString();
            var item = new PutItemRequest();

            this.mockRepository
                .Setup(o => o.GetByModAndNameAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(null);

            var sut = this.BuildDefaultSubjectUnderTest();
            await sut.PutByModAndName(mod, StringGenerator.AnyNonNullString(), item);

            this.mockRepository.Verify(o => o.GetModAsync(mod), Times.Once);
        }

        [Test]
        public async Task PutItem_WhenItemAndModDoesNotExist_ShouldCreateMod()
        {
            var mod = StringGenerator.AnyNonNullString();
            var item = new PutItemRequest();

            this.mockRepository
                .Setup(o => o.GetByModAndNameAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(null);

            this.mockRepository.Setup(o => o.GetModAsync(It.IsAny<string>())).ReturnsAsync(null);


            var sut = this.BuildDefaultSubjectUnderTest();
            await sut.PutByModAndName(mod, StringGenerator.AnyNonNullString(), item);

            this.mockRepository.Verify(o => o.SaveAsync(It.IsAny<Mod>()), Times.Once);
        }

        [Test]
        public async Task PutItem_WhenItemDoesNotExist_ShouldMapToCreateNew()
        {
            var item = new PutItemRequest();

            this.mockRepository
                .Setup(o => o.GetByModAndNameAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(null);

            var sut = this.BuildDefaultSubjectUnderTest();
            await sut.PutByModAndName(StringGenerator.AnyNonNullString(), StringGenerator.AnyNonNullString(), item);

            this.mockMapper.Verify(o => o.Map<Item>(item), Times.Once);
        }

        [Test]
        public async Task PutItem_WhenItemDoesNotExist_ShouldSaveNewlyMappedItem()
        {
            var item = new PutItemRequest();
            var newItem = new Item();

            this.mockRepository
                .Setup(o => o.GetByModAndNameAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(null);

            this.mockMapper
                .Setup(o => o.Map<Item>(It.IsAny<PutItemRequest>()))
                .Returns(newItem);

            var sut = this.BuildDefaultSubjectUnderTest();
            await sut.PutByModAndName(StringGenerator.AnyNonNullString(), StringGenerator.AnyNonNullString(), item);

            this.mockRepository.Verify(o => o.SaveAsync(newItem), Times.Once);
        }

        private ItemsController BuildDefaultSubjectUnderTest()
        {
            return new ItemsController(
                this.mockRepository.Object,
                this.mockMapper.Object);
        }
    }
}
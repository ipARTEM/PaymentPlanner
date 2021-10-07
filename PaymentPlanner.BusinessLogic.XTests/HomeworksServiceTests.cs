using AutoFixture;
using Moq;
using PaymentPlanner.Core;
using PaymentPlanner.Core.Exceptions;
using PaymentPlanner.Core.Repositories;
using FluentAssertions;
using System;
using Xunit;

namespace PaymentPlanner.BusinessLogic.XTests
{
    public class HomeworksServiceTests
    {
        private readonly Mock<IHomeworksRepository> _homeworksRespositoryMock;
        private readonly HomeworksService _service;

        public HomeworksServiceTests()
        {
            _homeworksRespositoryMock = new Mock<IHomeworksRepository>();
            _service = new HomeworksService(_homeworksRespositoryMock.Object);
        }



        [Fact]
        public void Create_HomeworkIsValid_ShouldCreateNewHomework()
        {
            //arrange

            //var homeworkRespositoryMock = new HomeworksRepositoryMock();

            var fixture = new Fixture();
            var homework = fixture.Build<Homework>()
                .Without(x => x.MentorId)
                .Create();

            _homeworksRespositoryMock.Setup(x => x.Get()).Returns(new Homework());



            var homework1 = new Homework();

            //act
            var result = _service.Create(homework);

            //assert
            result.Should().BeTrue();



            _homeworksRespositoryMock.Verify(x => x.Add(homework), Times.Once);

        }

        [Fact]
        public void Create_HomeworkIsInvalid_Should_ShouldThrowBusinessException()
        {
            //arrange

            //var result = _service.Create(homework);
            var homework = new Homework();


            //act
            bool result = false;
            var exception = Assert.Throws<BusinessException>(() => result = _service.Create(homework));


            //assert

            result.Should().BeTrue();

            _homeworksRespositoryMock.Verify(x => x.Add(homework), Times.Never);
        }


        [Fact]
        public void Create_HomeworkIsNull_ShouldThrowArgumentNullException()
        {
            //arrange

            //var homeworkRespositoryMock = new HomeworksRepositoryMock();
            //var homeworksRespositoryMock = new Mock<IHomeworksRepository>();
            //var service = new HomeworksService(homeworksRespositoryMock.Object);

            Homework homework = null;


            //act
            bool result = false;
            var exception = Assert.Throws<ArgumentNullException>(() => result = _service.Create(homework));

            //assert
            //Assert.IsFalse(result);

            exception.Should().NotBeNull().And.Match<ArgumentException>(x => x.ParamName == "homework");

            result.Should().BeTrue();

            _homeworksRespositoryMock.Verify(x => x.Add(homework), Times.Never);

        }

        [Fact]
        public void Delete_ShouldDeleteHomework()
        {
            //arrange
            var homeworkId = 1;



            //act
            var result = _service.Delete(homeworkId);


            //assert
            result.Should().BeTrue();

            _homeworksRespositoryMock.Verify(x => x.Delete(homeworkId), Times.Once);
        }

    }
}

using AutoFixture;
using Moq;
using NUnit.Framework;
using PaymentPlanner.Core;
using PaymentPlanner.Core.Exceptions;
using PaymentPlanner.Core.Repositories;
using System;

namespace PaymentPlanner.BusinessLogic.NTests
{
    
    public class HomeworksServiceTests
    {
        private  Mock<IHomeworksRepository> _homeworksRespositoryMock;
        private  HomeworksService _service;

        [SetUp]
        public void SetUp()
        {
            _homeworksRespositoryMock = new Mock<IHomeworksRepository>();
            _service = new HomeworksService(_homeworksRespositoryMock.Object);
        }

        [Test]
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
            Assert.IsTrue(result);



            _homeworksRespositoryMock.Verify(x => x.Add(homework), Times.Once);

        }

        [Test]
        public void Create_HomeworkIsInvalid_Should_ShouldThrowBusinessException()
        {
            //arrange

            //var result = _service.Create(homework);
            var homework = new Homework();


            //act
            bool result = false;
            var exception = Assert.Throws<BusinessException>(() => result = _service.Create(homework));


            //assert

            Assert.IsNotNull(exception);
            Assert.AreEqual(HomeworksService.HOMEWORK_IS_INVALID, exception.Message);
            Assert.IsFalse(result);

            _homeworksRespositoryMock.Verify(x => x.Add(homework), Times.Never);
        }


        [Test]
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

            //exception.Should().NotBeNull().And.Match<ArgumentException>(x => x.ParamName == "homework");

            Assert.IsNotNull(exception);
            Assert.AreEqual("homework", exception.ParamName);
            Assert.IsFalse(result);

            _homeworksRespositoryMock.Verify(x => x.Add(homework), Times.Never);

        }

        [Test]
        public void Delete_ShouldDeleteHomework()
        {
            //arrange
            var homeworkId = 1;



            //act
            var result = _service.Delete(homeworkId);


            //assert
            Assert.IsTrue(result);

            _homeworksRespositoryMock.Verify(x => x.Delete(homeworkId), Times.Once);
        }

    }
}
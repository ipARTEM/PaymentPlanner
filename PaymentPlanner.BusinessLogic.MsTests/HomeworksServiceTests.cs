using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PaymentPlanner.Core;
using PaymentPlanner.Core.Exceptions;
using PaymentPlanner.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentPlanner.BusinessLogic.MsTests
{
    [TestClass]
    public class HomeworksServiceTests
    {
        private readonly Mock<IHomeworksRepository> _homeworksRespositoryMock;
        private readonly HomeworksService _service;

        public HomeworksServiceTests()
        {
            _homeworksRespositoryMock = new Mock<IHomeworksRepository>();
            _service = new HomeworksService(_homeworksRespositoryMock.Object);
        }

        [TestMethod]
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

        [DataTestMethod]
        [DataRow(10)]
        [DataRow(0)]
        [DataRow(1015)]
        [DataRow(-10)]
        public void Create_HomeworkIsInvalid_ShouldThrowBusinessException(int memberId)
        {
            //arrange

            //var result = _service.Create(homework);
            var homework = new Homework();
            homework.MemberId = memberId;


            //act
            bool result = false;
            var exception = Assert.ThrowsException<BusinessException>(() => result = _service.Create(homework));


            //assert

            Assert.IsNotNull(exception);
            Assert.AreEqual(HomeworksService.HOMEWORK_IS_INVALID, exception.Message);
            Assert.IsFalse(result);

            _homeworksRespositoryMock.Verify(x => x.Add(homework), Times.Never);
        }


        [TestMethod]
        public void Create_HomeworkIsNull_ShouldThrowArgumentNullException()
        {
            //arrange

            //var homeworkRespositoryMock = new HomeworksRepositoryMock();
            //var homeworksRespositoryMock = new Mock<IHomeworksRepository>();
            //var service = new HomeworksService(homeworksRespositoryMock.Object);

            Homework homework = null;


            //act
            bool result = false;
            var exception= Assert.ThrowsException<ArgumentNullException>(()=> result = _service.Create(homework));

            //assert
            //Assert.IsFalse(result);

            exception.Should().NotBeNull().And.Match<ArgumentException>(x => x.ParamName == "homework");

            Assert.IsNotNull(exception);
            Assert.AreEqual("homework", exception.ParamName);
            Assert.IsFalse(result);

            _homeworksRespositoryMock.Verify(x => x.Add(homework), Times.Never);

        }

        [TestMethod]
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

    public class HomeworksRepositoryMock : IHomeworksRepository
    {
        public void Add(Homework homework)
        {
            
        }

        public void Delete(int homeworkId)
        {
            
        }

        public Homework Get()
        {
            return null;
        }

        public void Update(Homework homework)
        {
           
        }
    }
}

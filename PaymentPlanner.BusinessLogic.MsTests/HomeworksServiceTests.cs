using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PaymentPlanner.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentPlanner.BusinessLogic.MsTests
{
    [TestClass]
    class HomeworksServiceTests
    {
        [TestMethod]
        public void Create_ShouldCreateNewHomework()
        {
            //arrange

            //var homeworkRespositoryMock = new HomeworksRepositoryMock();

            var homeworksRespositoryMock = new Mock<IHomeworksRepository>();

            var service = new HomeworksService(homeworksRespositoryMock.Object);

            var homework = new Homework();

            //act
            var result = service.Create(homework);

            //assert

            homeworksRespositoryMock.Verify(x => x.Add(homework),Times.Once);

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

using PaymentPlanner.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentPlanner.BusinessLogic
{
    public class HomeworksService
    {
        private readonly IHomeworksRepository _homeworksRepository;


        public HomeworksService(IHomeworksRepository homeworksRepository)
        {
            _homeworksRepository = homeworksRepository;

        }
        public  bool  Create(Homework  homework)
        {
            return true;
        }
    }
}

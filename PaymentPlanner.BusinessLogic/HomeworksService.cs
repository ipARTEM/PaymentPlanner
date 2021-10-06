using PaymentPlanner.Core;
using PaymentPlanner.Core.Exceptions;
using PaymentPlanner.Core.Repositories;
using PaymentPlanner.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentPlanner.BusinessLogic
{
    public class HomeworksService    : IHomeworksService
    {
        public const string HOMEWORK_IS_INVALID = "Homework is invalid!";

        private readonly IHomeworksRepository _homeworksRepository;


        public HomeworksService(IHomeworksRepository homeworksRepository)
        {
            _homeworksRepository = homeworksRepository;

        }
        public  bool  Create(Homework  homework)
        {
            //валидация
            if(homework is null)
            {
                throw new ArgumentNullException(nameof(homework));
            }

            if (string.IsNullOrWhiteSpace(homework.Link))
            {
                throw new BusinessException("Homework link should not be  null or whitespace!");
            }

            var isInvalid = string.IsNullOrWhiteSpace(homework.Title)
                || string.IsNullOrWhiteSpace(homework.Title)
                || homework.MentorId <= 0;

            if (isInvalid)
            {
                throw new BusinessException(HOMEWORK_IS_INVALID);
            }

            //сохранение в базе
            _homeworksRepository.Add(homework);

            return true;
        }

        public bool Delete(int homeworkId)
        {
            _homeworksRepository.Delete(homeworkId);
            return true;
        }
    }
}

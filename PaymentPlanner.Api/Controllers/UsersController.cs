using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentPlanner.BusinessLogic;
using PaymentPlanner.Core;
using PaymentPlanner.Core.Repositories;
using PaymentPlanner.Core.Services;
using PaymentPlanner.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentPlanner.Api.Controllers
{


	[ApiController]
	[Route("[controller]")]
	public class HomeworksController : ControllerBase
    {
        private readonly IHomeworksService _homeworksService;

        public HomeworksController(IHomeworksService homeworksService)
        {
			_homeworksService = homeworksService;
        }
    }



	[ApiController]
	[Route("[controller]")]
	public class UsersController : ControllerBase
	{
		private readonly  IUsersService _userService;

		public UsersController()
		{
			//IUsersRepository usersRepository = new UsersRepository();
			//UsersService _userService = new UsersService(usersRepository,null);

			//_userService.GithubClient = new GithubClient();			
		}

		[HttpGet]
		public User[] Get(string userName)
		{
			var user = _userService.Get();

			var result = new User();

			return new[] { result };
		}

		[HttpPost]
		public User Create(User newUser)
		{
			var user = new Core.User
			{
				Age = newUser.Age,
				Name = newUser.Name
			};

			_userService.Create(user);

			return newUser;
		}

		[HttpGet("model")]
		public void GetModel([FromQuery] User user)
		{
			var model = user.GetType();

			foreach (var propetry in model.GetProperties())
			{
				foreach (var customAttribute in propetry.CustomAttributes)
				{
					if (customAttribute.AttributeType.Name == "RequiredAttribute")
					{
						var value = propetry.GetValue(user);
						var specifiedValue = Convert.ChangeType(value, propetry.PropertyType);

						if (value is DateTime dateValue && dateValue == default(DateTime))
						{
							throw new Exception($"{propetry.Name}: {value}");
						}

						if (value is int intValue && intValue == default(int))
						{
							throw new Exception($"{propetry.Name}: {value}");
						}

						if (value == null)
						{
							throw new Exception($"{propetry.Name}: {value}");
						}
					}
				}
			}
		}
	}
}
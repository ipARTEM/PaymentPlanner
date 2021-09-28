﻿using PaymentPlanner.Core;
using System;

namespace PaymentPlanner.DataAccess
{
	public class UsersRepository : IUsersRepository
	{
		public UsersRepository()
		{

		}

		public Core.User[] Get()
		{
			var user = new User
			{
				Id = 1,
				Age = 43,
				Name = "Test"
			};

			return new[] {
				new Core.User
				{
					Name = user.Name,
					Age = user.Age
				}
			};
		}

		public void Create(Core.User user)
		{

		}
	}
}

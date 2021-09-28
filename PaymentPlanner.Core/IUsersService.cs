using System;

namespace PaymentPlanner.Core
{
	public interface IUsersService
	{
		void Create(User user);
		User[] Get();
	}
}
using PaymentPlanner.Core;
using PaymentPlanner.DataAccess;
using System;

namespace PaymentPlanner.BusinessLogic
{
	public class UsersService : IUsersService
	{
		private IUsersRepository _usersRepository;

		public UsersService(IUsersRepository usersRepository)
		{
			_usersRepository = usersRepository;
		}



        public void Create(Core.User user)
        {
            throw new NotImplementedException();
        }

        Core.User[] IUsersService.Get()
        {
            
			var users = _usersRepository.Get();

			return users;
        }
    }


}

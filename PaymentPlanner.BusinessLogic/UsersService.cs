using PaymentPlanner.Core;
using PaymentPlanner.Core.Repositories;
using PaymentPlanner.Core.Services;
using PaymentPlanner.DataAccess;
using System;

namespace PaymentPlanner.BusinessLogic
{
	public class UsersService : IUsersService
	{
		private readonly IUsersRepository _usersRepository;

        //public GithubClient GithubClient { get; set; }

        private readonly GithubClient _githubClient;
		public UsersService(IUsersRepository usersRepository, GithubClient githubClient)
		{
			_usersRepository = usersRepository;
            _githubClient = githubClient;
		}



        public void Create(Core.User user)
        {
            throw new NotImplementedException();
        }

        Core.User[] IUsersService.Get()
        {
            
			var users = _usersRepository.Get();

            var client = new GithubClient();
            var githubUser= _githubClient.Get("nickname");

			return users;
        }
    }

    public class GithubClient
    {
        public GithubUser Get(string nuckname)
        {
            return new GithubUser();

        }
    }

    public class GithubUser
    {

    }


}

using Microsoft.Extensions.DependencyInjection;
using System;

namespace DITests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var collection = new ServiceCollection();

            collection.AddSingleton<UsersService>();
            collection.AddSingleton<GithubClient>();

            var provider = collection.BuildServiceProvider();

            using (var scope = provider.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<UsersService>();
                var controller = new UsersController(service);
                controller.Print();

            }

            using (var scope = provider.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<UsersService>();
                var controller = new UsersController(service);
                controller.Print();

            }
        }


        private static void SingletonMultipleRequests()
        {
            var client = new GithubClient();
            var service = new UsersService(client);

            // requests-scope
            {

                var controller = new UsersController(service);

                controller.Print();


            }

            // requests-scope
            {

                var controller = new UsersController(service);

                controller.Print();


            }
        }

        private static void MultipleRequests()
        {
            // requests-scope
            {
                var client = new GithubClient();
                var service = new UsersService(client);
                var controller = new UsersController(service);

                controller.Print();
                controller.Print();
                controller.Print();

            }

            // requests-scope
            {
                var client = new GithubClient();
                var service = new UsersService(client);
                var controller = new UsersController(service);

                controller.Print();
                controller.Print();
                controller.Print();

            }

        }
    }

    public class UsersController
    {
        private readonly UsersService _usersService;
        private readonly Guid _guid;
        public UsersController(UsersService usersService )
        {
            _guid = Guid.NewGuid();
            _usersService = usersService;

        }

        public void Print()
        {
            Console.WriteLine(nameof(UsersController) + " - " + _guid);
            _usersService.Print();
        }

    }

    public class UsersService
    {
        private readonly GithubClient _githubClient;
        private readonly Guid _guid;
        public UsersService(GithubClient githubClient)
        {
            _guid = Guid.NewGuid();
            _githubClient = githubClient;
        }

        public void Print()
        {
            Console.WriteLine(nameof(UsersService) + " - " + _guid);
            _githubClient.Print();
        }

    }

    public class GithubClient
    {
        private Guid _guid;
        public GithubClient()
        {
            _guid = Guid.NewGuid();
        }

        public void Print() => Console.WriteLine(nameof(GithubClient) + " - " + _guid);
    } 
}

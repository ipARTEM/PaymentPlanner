namespace PaymentPlanner.Core
{
	public interface IUsersRepository
	{
		void Create(User user);
		User[] Get();
	}
}

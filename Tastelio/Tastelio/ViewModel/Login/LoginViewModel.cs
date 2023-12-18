using DAL.Services.SqlService;
using Dapper;
using Models.Models;

namespace Tastelio.ViewModel.Login
{
	public class LoginViewModel : BaseViewModel, ILoginViewModel
	{
		public LoginModel LoginModel { get; set; } = new();
		public User? User { get; set; } = null;
		public bool LoggedIn { get; set; } = false;
		public int Attempts { get; set; } = 0;

		public LoginViewModel(ISqlService database) : base(database)
		{
		}

		public async Task Login()
		{
			string sql = "SELECT * FROM Users WHERE Email = @Email AND Password = @Password";

			DynamicParameters dynamicParams = new();
			dynamicParams.Add("@Email", LoginModel.Email);
			dynamicParams.Add("@Password", LoginModel.Password);

			User = await database.GetSingle<User>(sql, dynamicParams);

			LoggedIn = User is not null;
			Attempts++;
		}
	}
}

using Models.Models;

namespace Tastelio.ViewModel.Login
{
	public interface ILoginViewModel
	{
		LoginModel LoginModel { get; set; }
		User? User { get; set; }
		bool LoggedIn { get; set; }
		int Attempts { get; set; }

		Task Login();
	}
}
using Models.Models;

namespace Tastelio.ViewModel.Home
{
	public interface IHomeViewModel
	{
		Task<User?> GetRecord(string? search);
	}
}
using DAL.Services.SqlService;
using Dapper;
using Models.Models;

namespace Tastelio.ViewModel.Home
{
	public class HomeViewModel : BaseViewModel, IHomeViewModel
	{
		public HomeViewModel(ISqlService database) : base(database)
		{
		}

		public async Task<User?> GetRecord(string? search)
		{
			string sql = "SELECT * FROM Users WHERE Firstname = @Search OR @Search IS NULL";

			DynamicParameters dynamicParams = new();
			dynamicParams.Add("@Search", search);

			return await database.GetSingle<User>(sql, dynamicParams);
		}
	}
}

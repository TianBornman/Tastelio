using DAL.Services.SqlService;

namespace Tastelio.ViewModel
{
	public class BaseViewModel
	{
		protected readonly ISqlService database;

		public BaseViewModel(ISqlService database)
		{
			this.database = database;
		}
	}
}

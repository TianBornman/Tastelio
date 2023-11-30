using Dapper;

namespace DAL.Services.SqlService
{
	public interface ISqlService
	{
		Task<T?> GetSingle<T>(string sql, DynamicParameters? dynamicParameters = null);
	}
}
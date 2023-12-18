using Dapper;
using System.Data;

namespace DAL.Services.SqlService
{
	public class SqlService : ISqlService
	{
		private readonly IDbConnection dbConnection;

		public SqlService(IDbConnection dbConnection)
		{
			this.dbConnection = dbConnection;
		}

		public async Task<T?> GetSingle<T>(string sql, DynamicParameters? dynamicParameters = null)
		{
			return (await dbConnection.QueryAsync<T?>(sql, param: dynamicParameters, commandType: CommandType.Text)).FirstOrDefault();
		}

		// GetList

		public async Task Execute(string sql, DynamicParameters? dynamicParameters = null)
		{
			await dbConnection.QueryAsync(sql, param: dynamicParameters, commandType: CommandType.StoredProcedure);
		}

		public async Task<List<T>?> Execute<T>(string sql, DynamicParameters? dynamicParameters = null)
		{
			return (await dbConnection.QueryAsync<T>(sql, param: dynamicParameters, commandType: CommandType.StoredProcedure)).ToList();
		}

		public async Task Delete(string sql, DynamicParameters? dynamicParameters = null)
		{
			await dbConnection.QueryAsync(sql, param: dynamicParameters, commandType: CommandType.Text);
		}
        public async Task<List<T>?> GetList<T>(string sql, DynamicParameters? dynamicParameters = null)
        {
            return (await dbConnection.QueryAsync<T>(sql, param: dynamicParameters, commandType: CommandType.Text)).ToList();
        }
    }
}

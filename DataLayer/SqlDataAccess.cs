using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace DataLayer {

    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;
        public string ConnectionStringName { get; set; } = "Default";
        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            try {
                string? connectionString = _config.GetConnectionString(ConnectionStringName);
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    var data = await connection.QueryAsync<T>(sql, parameters);
                    return data.ToList();
                }
            } catch (Exception ex) {
                Console.WriteLine($"Error in LoadData: {ex.Message}");
                throw;
            }
        }

        public async Task SaveData<T>(string sql, T parameters)
        {
            string? connectionString = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }

		public async Task<int> ExecuteScalar<T>(string sql, T parameters)
        {
            string? connectionString = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return await connection.ExecuteScalarAsync<int>(sql, parameters);
            }
        }

        public async Task<List<T>> ExecuteProcedure<T, U>(string procedureName, U parameters) 
        {
            try {
                string? connectionString = _config.GetConnectionString(ConnectionStringName);

                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    var data = await connection.QueryAsync<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                    return data.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ExecuteProcedure: {ex.Message}");
                throw;
            }
        }

		public async Task<List<T>> ExecuteFunction<T, U>(string functionName, U parameters) {
			try {
                string? connectionString = _config.GetConnectionString(ConnectionStringName);

                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    var data = await connection.QueryAsync<T>(functionName, parameters, commandType: CommandType.StoredProcedure);
                    return data.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ExecuteProcedure: {ex.Message}");
                throw;
            }
		}

    }
}

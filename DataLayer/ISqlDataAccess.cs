namespace DataLayer {
    public interface ISqlDataAccess
    {
        string ConnectionStringName { get; set; }
        Task<List<T>> LoadData<T, U>(string sql, U parameters);
        Task SaveData<T>(string sql, T parameters);
		Task<int> ExecuteScalar<T>(string sql, T parameters);
        Task<decimal> ExecuteScalar2<T>(string sql, T parameters);
        Task<U> ExecuteScalar3<T,U>(string sql, T parameters);
        Task<List<T>> ExecuteProcedure<T, U>(string procedureName, U parameters);
		Task<List<T>> ExecuteFunction<T, U>(string functionName, U parameters);
    }
}

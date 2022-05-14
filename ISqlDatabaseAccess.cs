namespace Consumption_Meter
{
    public interface ISqlDatabaseAccess
    {
        Task<List<T>> Execute<T>(string sql);
        Task<T> ExecuteSingle<T, U>(string sql, U model);
        Task<List<T>> Execute<T, U>(string sql, U model);
    }
}
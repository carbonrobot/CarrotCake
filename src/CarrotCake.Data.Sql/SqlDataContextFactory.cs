namespace CarrotCake.Data.Sql
{
    public class SqlDataContextFactory : IDataContextFactory
    {
        public IDataContext Create()
        {
            return new SqlDataContext();
        }
    }
}

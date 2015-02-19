namespace CarrotCake.Data.Dapper
{
    public class DapperDataContextFactory : IDataContextFactory
    {
        public IDataContext Create()
        {
            return new DapperDataContext();
        }
    }
}

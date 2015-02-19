namespace CarrotCake.Data.Ef
{
    public class EFDataContextFactory : IDataContextFactory
    {
        public IDataContext Create()
        {
            return new EFDataContext();
        }
    }
}

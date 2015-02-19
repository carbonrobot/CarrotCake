namespace CarrotCake.Data
{
    public interface IDataContextFactory
    {
        IDataContext Create();
    }
}
namespace StrategyConsoleApplication.Interfaces
{
    public interface ISalesEngine
    {
        Product Recommend(SalesMode salesMode, Customer customer);
    }
}
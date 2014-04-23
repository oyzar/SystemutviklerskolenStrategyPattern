using StrategyConsoleApplication.Interfaces;

namespace StrategyConsoleApplication.Strategies
{
    public class DefaultProductRecomender : IProductRecommender
    {
        public Product Recommend(Customer customer)
        {
            return new Product("SomeProduct", "Use some default recommendation??");
        }
    }
}
using StrategyConsoleApplication.Interfaces;

namespace StrategyConsoleApplication.Strategies
{
    public class LowPriceProductRecommender : IProductRecommender
    {
        public Product Recommend()
        {
            return new Product("Shave-fast super shaver", this.GetType().ToString());
        }
    }
}

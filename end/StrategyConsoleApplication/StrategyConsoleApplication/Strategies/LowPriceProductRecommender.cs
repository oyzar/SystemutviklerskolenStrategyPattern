using StrategyConsoleApplication.Interfaces;

namespace StrategyConsoleApplication.Strategies
{
    public class LowCostProductRecommender : IProductRecommender
    {
        public Product Recommend()
        {
            return new Product("Shave-fast super shaver", this.GetType().ToString());
        }
    }
}

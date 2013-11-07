using StrategyConsoleApplication.Interfaces;

namespace StrategyConsoleApplication.Strategies
{
    public class SeasonalProductRecommender : IProductRecommender
    {
        public Product Recommend()
        {
            return new Product("Snowmower", this.GetType().ToString());
        }
    }
}

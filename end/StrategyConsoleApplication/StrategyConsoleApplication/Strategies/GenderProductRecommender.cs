using StrategyConsoleApplication.Interfaces;

namespace StrategyConsoleApplication.Strategies
{
    public class GenderProductRecommender : IProductRecommender
    {
        public Product Recommend()
        {
            return new Product("Shower-soap", this.GetType().ToString());
        }
    }
}

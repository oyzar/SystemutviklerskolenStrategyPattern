using StrategyConsoleApplication.Interfaces;

namespace StrategyConsoleApplication.Strategies
{
    public class LowCostProductRecommender : IProductRecommender
    {
        public Product Recommend(Customer customer)
        {
            if (customer.Gender == Gender.Male)
                return new Product("Pokal øl", this.GetType().ToString());
            else
                return new Product("Økonomi sko", this.GetType().ToString());
        }
    }
}

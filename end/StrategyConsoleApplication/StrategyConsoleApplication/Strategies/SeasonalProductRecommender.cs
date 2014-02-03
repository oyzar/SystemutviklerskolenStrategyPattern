using StrategyConsoleApplication.Interfaces;

namespace StrategyConsoleApplication.Strategies
{
    public class SeasonalProductRecommender : IProductRecommender
    {
        public Product Recommend(Customer customer)
        {
            if (customer.Gender == Gender.Male)
                return new Product("Snømåker", this.GetType().ToString());
            else
                return new Product("Vinterkjole", this.GetType().ToString());
        }
    }
}

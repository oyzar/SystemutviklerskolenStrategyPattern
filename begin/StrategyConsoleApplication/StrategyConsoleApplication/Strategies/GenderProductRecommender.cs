using StrategyConsoleApplication.Interfaces;

namespace StrategyConsoleApplication.Strategies
{
    public class GenderProductRecommender : IProductRecommender
    {
        public Product Recommend(Customer customer)
        {

            if (customer.Gender == Gender.Female)
            {
                return new Product("SomeProduct", "For females");
            }
            else
                return new Product("SomeProduct", "For males");
        }
    }
}
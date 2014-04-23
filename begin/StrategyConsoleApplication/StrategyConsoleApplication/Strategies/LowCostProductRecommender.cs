using System;
using StrategyConsoleApplication.Interfaces;

namespace StrategyConsoleApplication.Strategies
{
    public class LowCostProductRecommender : IProductRecommender
    {
        public Product Recommend(Customer customer)
        {
            return customer.Gender == Gender.Female ? new Product("SomeProduct", "For females and low-cost") 
                : new Product("SomeProduct", "For males and low-cost");
        }
    }
}

using System;
using StrategyConsoleApplication.Interfaces;

namespace StrategyConsoleApplication.Strategies
{
    public class SeasonalProductRecommender : IProductRecommender
    {
        public Product Recommend(Customer customer)
        {
            return customer.Gender == Gender.Female ? new Product("SomeProduct", "For females and seasonal") 
                : new Product("SomeProduct", "For males and seasonal");
        }
    }
}

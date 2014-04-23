using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StrategyConsoleApplication;

namespace StrategyTests
{
    [TestClass]
    public class SalesEngineTest
    {
        [TestMethod]
        public void Recommend_Should_recomend_For_females_when_mode_is_gender_and_gender_is_female()
        {
            
            var salesMode = SalesMode.Gender;
            var productRecomender = 
                new SalesEngine(ProductRecomenderFactory.GetProductRecomender(salesMode));
            var recommendedProduct=productRecomender.Recommend(salesMode, new Customer() { Gender = Gender.Female});
            recommendedProduct.RecommendedBy.Should().Be("For females");
        }

        [TestMethod]
        public void Recommend_Should_recomend_For_males_when_mode_is_gender_and_gender_is_male()
        {
            var salesMode = SalesMode.Gender;
            var productRecomender = new SalesEngine(ProductRecomenderFactory.GetProductRecomender(salesMode));
            var recommendedProduct = productRecomender.Recommend(salesMode, new Customer() { Gender = Gender.Male });
            recommendedProduct.RecommendedBy.Should().Be("For males");
        }

        [TestMethod]
        public void Recommend_Should_recomend_For_males_and_low_cost_when_mode_is_low_cost_and_gender_is_male()
        {
            var salesMode = SalesMode.LowCost;
            var productRecomender = new SalesEngine(ProductRecomenderFactory.GetProductRecomender(salesMode));
            var recommendedProduct = productRecomender.Recommend(salesMode, new Customer() { Gender = Gender.Male });
            recommendedProduct.RecommendedBy.Should().Be("For males and low-cost");
        }

        [TestMethod]
        public void Recommend_Should_recomend_For_males_and_seasonal_when_mode_is_seasonal_and_gender_is_male()
        {
            
            var salesMode = SalesMode.Seasonal;
            var productRecomender = new SalesEngine(ProductRecomenderFactory.GetProductRecomender(salesMode));
            var recommendedProduct = productRecomender.Recommend(salesMode, new Customer() { Gender = Gender.Male });
            recommendedProduct.RecommendedBy.Should().Be("For males and seasonal");
        }

        [TestMethod]
        public void Recommend_Should_recomend_For_females_and_low_cost_when_mode_is_low_cost_and_gender_is_female()
        {
            
            var salesMode = SalesMode.LowCost;
            var productRecomender = new SalesEngine(ProductRecomenderFactory.GetProductRecomender(salesMode));
            var recommendedProduct = productRecomender.Recommend(salesMode, new Customer() { Gender = Gender.Female });
            recommendedProduct.RecommendedBy.Should().Be("For females and low-cost");
        }

        [TestMethod]
        public void Recommend_Should_recomend_For_females_and_seasonal_when_mode_is_seasonal_and_gender_is_female()
        {
            
            var salesMode = SalesMode.Seasonal;
            var productRecomender = new SalesEngine(ProductRecomenderFactory.GetProductRecomender(salesMode));
            var recommendedProduct = productRecomender.Recommend(salesMode, new Customer() { Gender = Gender.Female });
            recommendedProduct.RecommendedBy.Should().Be("For females and seasonal");
        }

        [TestMethod]
        public void Recommend_Default()
        {
    
            var salesMode = (SalesMode) 10;
            var productRecomender = new SalesEngine(ProductRecomenderFactory.GetProductRecomender(salesMode));
            var recommendedProduct = productRecomender.Recommend(salesMode, new Customer() { Gender = Gender.Male });
            recommendedProduct.RecommendedBy.Should().Be("Use some default recommendation??");
        }
    }
}

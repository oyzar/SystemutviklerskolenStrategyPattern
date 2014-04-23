using System;
using System.Collections.Generic;
using System.Reflection;
using StrategyConsoleApplication.Interfaces;
using StrategyConsoleApplication.Strategies;

namespace StrategyConsoleApplication
{
    public class ProductRecomenderFactory
    {
        public static IEnumerable<Lazy<IProductRecommender, ProductRecommenderMetadata>> GetProductRecomender(SalesMode salesMode)
        {
            yield return new Lazy<IProductRecommender, ProductRecommenderMetadata>(() =>
            {
                var typename = "StrategyConsoleApplication.Strategies." + salesMode.ToString() + "ProductRecommender";
                try
                {
                    return (IProductRecommender)Activator.CreateInstance(Assembly.GetExecutingAssembly().FullName, typename).Unwrap();
                }
                catch (TypeLoadException)
                {
                    return new DefaultProductRecomender();
                }
                
            }, new ProductRecommenderMetadata() { SalesMode = salesMode });
        }
    }
}
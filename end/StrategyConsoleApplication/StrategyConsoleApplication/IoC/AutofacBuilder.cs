using Autofac;
using StrategyConsoleApplication.Strategies;

namespace StrategyConsoleApplication.IoC
{
    internal class AutofacBuilder : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GenderProductRecommender>()
                   .AsImplementedInterfaces()
                   .WithMetadata<ProductRecommenderMetadata>(m => m.For(x => x.SalesMode, SalesMode.Gender));

            builder.RegisterType<LowPriceProductRecommender>()
                   .AsImplementedInterfaces()
                   .WithMetadata<ProductRecommenderMetadata>(m => m.For(x => x.SalesMode, SalesMode.LowPrice));

            builder.RegisterType<SeasonalProductRecommender>()
                   .AsImplementedInterfaces()
                   .WithMetadata<ProductRecommenderMetadata>(m => m.For(x => x.SalesMode, SalesMode.Seasonal));

            builder.RegisterType<SalesEngine>().AsImplementedInterfaces();
        }
    }
}
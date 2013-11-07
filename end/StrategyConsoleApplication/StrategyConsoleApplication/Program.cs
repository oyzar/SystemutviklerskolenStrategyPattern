using System;
using Autofac;
using StrategyConsoleApplication.Interfaces;
using StrategyConsoleApplication.IoC;

namespace StrategyConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var salesMode = (SalesMode)(int.Parse(Console.ReadLine()));

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<AutofacBuilder>();

            using (var container = containerBuilder.Build())
            {
                var salesEngine = container.Resolve<ISalesEngine>();
                var recommendedProduct = salesEngine.Recommend(salesMode);
                
                Console.WriteLine(recommendedProduct);
                Console.ReadLine();
            }
        }
    }
}


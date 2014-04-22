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
            Console.WriteLine("Salesmode (0=Gender, 1=LowCost, 2=Seasonal):");
            var salesMode = (SalesMode)(int.Parse(Console.ReadLine()));

            Console.WriteLine("Gender (0=Male, 1=Female):");
            var gender = (Gender)(int.Parse(Console.ReadLine()));

            var customer = new Customer("Henrik", gender);

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<AutofacBuilder>();

            using (var container = containerBuilder.Build())
            {
                var salesEngine = container.Resolve<ISalesEngine>();
                var recommendedProduct = salesEngine.Recommend(salesMode, customer);
                
                Console.WriteLine(recommendedProduct);
                Console.ReadLine();
            }
        }
    }
}


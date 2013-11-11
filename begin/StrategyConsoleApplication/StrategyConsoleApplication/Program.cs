using System;
using StrategyConsoleApplication.Interfaces;

namespace StrategyConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var salesMode = SalesMode.Gender;
            var customer = new Customer()
                               {
                                   Gender = Gender.Male,
                                   Name = "Pål Gordon Nilsen"
                               };

            Product recommendedProduct = null;

            if (salesMode == SalesMode.Gender)
            {
                if (customer.Gender == Gender.Female)
                {
                    recommendedProduct = new Product("SomeProduct", "For females");
                }
                else
                    recommendedProduct = new Product("SomeProduct", "For males");
            }
            else if (salesMode == SalesMode.LowPrice)
            {
                if (customer.Gender == Gender.Female)
                {
                    recommendedProduct = new Product("SomeProduct", "For females  and low-cost");
                }
                else
                    recommendedProduct = new Product("SomeProduct", "For males and low-cost");
            }
            else if (salesMode == SalesMode.Seasonal)
            {
                if (customer.Gender == Gender.Female)
                {
                    recommendedProduct = new Product("SomeProduct", "For females and seasonal");
                }
                else
                    recommendedProduct = new Product("SomeProduct", "For males and seasonal");
            }
            else
            {
                recommendedProduct = new Product("SomeProduct", "Use some default recommendation??");
            }

            Console.WriteLine(recommendedProduct);
            Console.ReadLine();
        }
    }
}


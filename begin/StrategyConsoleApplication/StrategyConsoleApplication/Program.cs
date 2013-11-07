using System;

namespace StrategyConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var salesMode = SalesMode.Gender;
            Product recommendedProduct = null;

            if (salesMode == SalesMode.Gender)
            {
                if (salesMode == SalesMode.LowPrice)
                {
                    if (salesMode == SalesMode.Seasonal)
                        recommendedProduct = new Product("SomeProduct", "For males and with low-cost and with seasonal focus");
                }
                else
                    recommendedProduct = new Product("SomeProduct", "For males in general not interested in low-cost");
            }
            else if (salesMode == SalesMode.LowPrice)
            {
                if (salesMode == SalesMode.Seasonal)
                {
                    recommendedProduct = new Product("SomeProduct", "Low-cost and with seasonal focus");
                }
                else
                    recommendedProduct = new Product("SomeProduct", "Low-cost in general");
            }
            else if (salesMode == SalesMode.Seasonal)
            {
                if (salesMode == SalesMode.LowPrice)
                {
                    if (salesMode == SalesMode.Gender)
                        recommendedProduct = new Product("SomeProduct", "For women and with low-cost and with seasonal focus");
                }
                else
                    recommendedProduct = new Product("SomeProduct", "Seasonal focus in general");
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


using System;
using System.Collections.Generic;
using System.Reflection;
using StrategyConsoleApplication.Interfaces;

namespace StrategyConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var salesMode = GetSalesModeFromArgs(args);

            var gender = GetGenderFromArgs(args);
            var engine = new SalesEngine(ProductRecomenderFactory.GetProductRecomender(salesMode));
            var customer = new Customer()
            {
                Gender = gender,
                Name = "Pål Gordon Nilsen"
            };

            var recommendedProduct = engine.Recommend(salesMode, customer);

            Console.WriteLine(recommendedProduct);
            Console.ReadLine();
        }



        private static Gender GetGenderFromArgs(string[] args)
        {
            if (args.Length < 1)
            {
                return (Gender)0;
            }
            var gender = args[1];
            var salesMode = (Gender) int.Parse(gender);
            return salesMode;
        }

        private static SalesMode GetSalesModeFromArgs(string[] args)
        {
            if (args.Length == 0)
            {
                return (SalesMode) 0;
            }
            var mode = args[0];
            var salesMode = (SalesMode) int.Parse(mode);
            return salesMode;
        }

        //public static TEnum GetEnumFromArgs<TEnum>(string arg) where TEnum : struct, IConvertible
        //{
        //    var value = int.Parse(arg);
        //    return (TEnum)value;
        //}//det fungerer ikke å caste her, så bruker metodene over i stedet...
    }
}


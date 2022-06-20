using S = System;
using PS.Domain;
using PS.Service;
using System.Collections.Generic;
using PS.Data;
using System.Linq;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using PS.Data.Infrastructure;

namespace PS.Console
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //PSContext context = new PSContext();
            ////persistance de données
            ////context.Products.Add(DataTest.Products[2]);
            //// context.SaveChanges();

            //foreach (var item in context.Products.ToList())
            //{
            //    S.Console.WriteLine(item.Name + " " + 
            //        item.Category.Name );
            //}
            //

            var serviceProvider = new ServiceCollection()
                .AddScoped<IProductService, ProductServices>()
                .AddTransient<IUnitOfWork, UnitOfWork>()
                .AddSingleton<IDataBaseFactory, DataBaseFactory>()
                .BuildServiceProvider();

            var serviceProduct = serviceProvider.GetService<IProductService>();

            serviceProduct.Add(DataTest.Products[3]);
            serviceProduct.Commit();
        }

        public static void ChangeValue(out int myParam, params int[] t)
        {
            S.Random rd = new S.Random();
            myParam = rd.Next(50, 100);
            S.Console.WriteLine("MyParam=" + myParam);
        }
    }
}

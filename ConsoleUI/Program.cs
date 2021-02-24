﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Data Transformation Object DTO
            ProductTest();
            //CategoryTest();


            Console.ReadKey();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EFProductDal(),new CategoryManager(new EFCategoryDal()));
            var result = productManager.GetAll();
            if (result.Success == true)
            {
                foreach (var product in result.Data )
                {
                    Console.WriteLine(product.ProductName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
    }
   
}

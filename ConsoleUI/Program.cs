using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program 
    {
        static void Main(string[] args)
        {
            // DTO Data Transformation Object

            ProduckTest();
            //IoC
            //CategoryTest();

        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetById(2))
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProduckTest()
        {
            ProduckManager produckManager = new ProduckManager(new EfProduckDal());

            foreach (var product in produckManager.GetProduckDetailDtos())
            {


                Console.WriteLine("Ürünler : " + product.ProduckName + "  / CategoryName:  " + product.CategoryName);
               
            }
        }
    }
}

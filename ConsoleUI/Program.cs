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
            ProduckManager produckManager = new ProduckManager(new EfProduckDal());

            foreach (var product in produckManager.GetAll())
            {
              
                
                Console.Write(product.ProduckName);
               
            }
            Console.WriteLine("         ");
            Console.WriteLine("SMTcoder");
        }
    }
}

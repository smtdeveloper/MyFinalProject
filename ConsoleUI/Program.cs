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

            foreach (var product in produckManager.GetByUnitPrice(50,100))
            { 
              
                
                Console.Write("Ürünler : " + product.ProductName + " ********* ");
                Console.Write("Fiyatları : " + product.UnitPrice + " ********* ");
                Console.Write("Stoklar : " + product.UnitsInStock + " SMTcoder ");
                Console.WriteLine(" ");

            }
            Console.WriteLine("         ");
            Console.WriteLine("SMTcoder");
            Console.WriteLine( "Samet Akca" ); 
        }
    }
}

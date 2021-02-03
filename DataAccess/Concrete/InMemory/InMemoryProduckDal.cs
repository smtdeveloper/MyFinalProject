using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProduckDal : IProductDal
    {
        List<Product> _products; //global isimlendirme _ ile baslar.
        public InMemoryProduckDal()
        {
            _products = new List<Product> {

                new Product{  ProductId=1, CategoryId=1, ProduckName="Bardak", UnitPrice=25, UnitInStok=100 },
                new Product{  ProductId=2, CategoryId=2, ProduckName="Monster",UnitPrice=5000, UnitInStok=10 },
                new Product{  ProductId=3, CategoryId=2, ProduckName="Telefon", UnitPrice=2000, UnitInStok=50 },
                new Product{  ProductId=4, CategoryId=2, ProduckName="Ekran", UnitPrice=500, UnitInStok=250 },
                new Product{  ProductId=5, CategoryId=2, ProduckName="Klavye", UnitPrice=100, UnitInStok=500 }


            };

        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ bu kodu  LINQ yazılısı
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            _products.Remove(productToDelete);

            //    = null;
            ////foreach (var P in _products)
            ////{
            ////    if (product.ProductId == P.ProductId)
            ////    {
            ////        productToDelete = P;
            ////    }
            ////}

            ////LINQ bu kodu  LINQ yazılısı
            //productToDelete = 

            // => Lambda // SingleOrDefault tek tek dolasır listeyi



        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            // Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProduckName = product.ProduckName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitInStok = product.UnitInStok;
        }

    }
}

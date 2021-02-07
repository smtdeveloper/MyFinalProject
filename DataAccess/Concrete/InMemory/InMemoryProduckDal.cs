using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

                new Product{  ProductId=1, CategoryId=1, ProductName="Bardak", UnitPrice=25, UnitsInStock=100 },
                new Product{  ProductId=2, CategoryId=2, ProductName="Monster",UnitPrice=5000, UnitsInStock=10 },
                new Product{  ProductId=3, CategoryId=2, ProductName="Telefon", UnitPrice=2000, UnitsInStock=50 },
                new Product{  ProductId=4, CategoryId=2, ProductName="Ekran", UnitPrice=500, UnitsInStock=250 },
                new Product{  ProductId=5, CategoryId=2, ProductName="Klavye", UnitPrice=100, UnitsInStock=500 }


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

        public List<ProduckDetailDto> GetProduckDetailDtos()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            // Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

    }
}

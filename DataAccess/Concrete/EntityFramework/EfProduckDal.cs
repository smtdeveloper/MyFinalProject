﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet
    public class EfProduckDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProduckDetailDto> GetProduckDetailDtos()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId  // equals == dir
                             select new ProduckDetailDto 
                             {
                                 ProduckId = p.CategoryId, ProduckName = p.ProductName, 
                                 CategoryName = c.CategoryName , UnitsInStock = p.UnitsInStock 
                             };
                return result.ToList();

            }

           
            //
        }
    }
}

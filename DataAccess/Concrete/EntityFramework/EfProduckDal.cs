﻿using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet
    public class EfProduckDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDıspossable pattern imlementation of c# // using
            using (NorthwindContext context=new NorthwindContext())
            {
                var addendEntity = context.Entry(entity);
                addendEntity.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
           using(NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext contex=new NorthwindContext())
            {
                return filter == null
                  ? contex.Set<Product>().ToList()
                  : contex.Set<Product>().Where(filter).ToList();

            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}

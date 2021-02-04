using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProduckManager : IProduckService
    {
        IProductDal _produckDal;

        public ProduckManager (IProductDal prouckDal)
        {
        
            _produckDal = prouckDal;
        }

        public List<Product> GetAll()
        {
            // iş kodları - Business code
            // yetkisi var mı  = varsa ürünleri ver 

            return _produckDal.GetAll();

      
            
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _produckDal.GetAll(p => p.CategoryId == id);

        
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _produckDal.GetAll(p => p.UnitPrice >=min && p.UnitPrice <=max);

        }
    }
}

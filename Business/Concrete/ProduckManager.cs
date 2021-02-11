using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult Add(Product product)
        {
            // iş kodları  // business codes 

            if (product.ProductName.Length < 2)
            {
                //magic strings
                return new ErrorResult(Messages.ProductNameInvalid);
            }

            _produckDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);

        }


        public IDataResult<List<Product>> GetAll()
        {
           if(DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }



            return new SuccessDataResult<List<Product>>(_produckDal.GetAll(),Messages.ProductsListed);

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_produckDal.GetAll(p => p.CategoryId == id));

        
        }

        public IDataResult<Product> GetById(int produckId)
        {
            return new SuccessDataResult<Product>(_produckDal.Get(p => p.ProductId == produckId)); 
        }

        public IDataResult<List<Product>>  GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_produckDal.GetAll(p => p.UnitPrice >=min && p.UnitPrice <=max));

        }

        public IDataResult<List<ProduckDetailDto>> GetProductDetail()
        {
            return new SuccessDataResult<List<ProduckDetailDto>>(_produckDal.GetProductDetails()); 
            // bazen copy pasy yaparken hata alırsın, kendin yaz - SMTcoder

        }
    }
}

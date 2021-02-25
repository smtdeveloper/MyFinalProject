using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProduckService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
       
        
       IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);

       IDataResult<List<ProduckDetailDto>>  GetProduckDetailDtos();

        IDataResult<Product>  GetById(int produckId);
        IResult Add(Product product);

        
      
    }
}

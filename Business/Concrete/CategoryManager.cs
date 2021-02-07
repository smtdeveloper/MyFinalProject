using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        //
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            // iş kodları yazılır buraya
            return _categoryDal.GetAll();
        }

        // select * from Category where CategoryId = categoryId(Takma ad)
        public List<Category> GetById(int categoryId)
        {
            return _categoryDal.GetAll(c => c.CategoryId == categoryId);

        }
    }
}

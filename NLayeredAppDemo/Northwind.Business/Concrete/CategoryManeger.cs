﻿using Northwind.Business.Abstract;
using Northwind.DataAccess.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Concrete
{
    public class CategoryManeger : ICategoryService
    {
        private ICategoryDal categoryDal;

        public CategoryManeger(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
           return categoryDal.GetAll();
        }

            
    }

}

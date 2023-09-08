﻿using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Abstract
{
    public interface IProductService
    {
        void Add(Product product);
        void Update(Product product);
        List<Product> GetAll();
        List<Product> GetProductByCategory(int categoryId);
        List<Product> GetProductByProductName(string productName);
        void Delete(Product product);
    }
}

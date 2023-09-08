﻿using Northwind.DataAccess.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete.Nhibarnate
{
    public class NhProductDal : IProductDal
    {
        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            List<Product> products = new List<Product>
            {
                new Product{
                    ProductID = 1,
                    CategoryId = 1,
                    ProductName = "Laptop",
                    QuantityPerUnit ="5 in a box",
                    UnitPrice = 2000,
                    UnitsInStock = 5 }
            };
            return products;
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}

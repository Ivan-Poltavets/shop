﻿using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStore;

namespace DataStore.InMemory
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> products;
        public ProductRepository()
        {
            products = new List<Product>()
            {
                new Product{ProductId=1,CategoryId=1,Name="Apple",Quantity=100,Price=20},
                new Product{ProductId=2,CategoryId=1,Name="Banana",Quantity=50,Price=40},
                new Product{ProductId=3,CategoryId=2,Name="Potato",Quantity=70,Price=10}
            };

        }

        public void AddProduct(Product product)
        {
            if (products.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase))) return;
            if (products != null && products.Count > 0)
            {
                var maxId = products.Max(x => x.ProductId);
                product.ProductId = maxId + 1;
            }
            else
            {
                product.ProductId = 1;
            }
            products.Add(product);
        }

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }

        public void UpdateProduct(Product product)
        {
            var productUpdate = GetProductById(product.ProductId);
            if (productUpdate != null)
            {
                productUpdate.CategoryId = product.CategoryId;
                productUpdate.Name = product.Name;
                productUpdate.Quantity = product.Quantity;
                productUpdate.Price = product.Price;
            }
        }
        public Product GetProductById(int productId)
        {
            return products.FirstOrDefault(x=> x.ProductId == productId);
        }
        public void DeleteProduct(int productId)
        {
            products?.Remove(GetProductById(productId));
        }
        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return products.Where(x => x.CategoryId == categoryId);
        }
    }
}

﻿using BoltFood.Core.Enums;
using BoltFood.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Service.Services.Interfaces
{
    public interface IProductService
    {
        public Task<string> CreateAsync(string name, double price, int restaurantid, ProductCategory productCategory);
        public Task<string> UpdateAsync(int id, string name, double price);
        public Task<string> RemoveAsync(int id);
        public Task<Product> GetAsync(int id);
        public Task<List<Product>> GetAllAsync();
    }
}


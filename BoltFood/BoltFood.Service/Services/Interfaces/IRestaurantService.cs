using BoltFood.Core.Enums;
using BoltFood.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Service.Services.Interfaces
{
    public interface IRestaurantService
    {
        public Task<string> CreateAsync( string name,RestaurantCategory restaurantCategory);
        public Task<string> UpdateAsync(int id);
        public Task<string> RemoveAsync(int id);
        public Task<Restaurant> GetAsync(int id);
        public Task<List<Restaurant>> GetAllAsync();
       


        
    }
}

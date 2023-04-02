using BoltFood.Core.Enums;
using BoltFood.Core.Models;
using BoltFood.Core.Repositories.IRestaurantRepository;
using BoltFood.Data.Repositories.RestaurantRepository;
using BoltFood.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BoltFood.Service.Services.Implementations
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository = new RestaurantRepository();

        public async Task<string> CreateAsync(string name,RestaurantCategory restaurantCategory)
        {

            Restaurant restaurant = new Restaurant(name,restaurantCategory);
            await _restaurantRepository.AddAsync(restaurant);
           
            Console.ForegroundColor = ConsoleColor.Green;
            return "Restaurant created successfully!";
        }
            

        public async Task<List<Restaurant>> GetAllAsync()
         => await _restaurantRepository.GetAllAsync();

        async Task<Restaurant> IRestaurantService.GetAsync(int id)
        {
            Restaurant restaurant = await _restaurantRepository.GetAsync(r => r.Id == id);

            if (restaurant == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"No restaurant found with Id {id}.");
            }
            return restaurant;
        }

        public async Task<string> RemoveAsync(int id)
        {
            Restaurant restaurant = await _restaurantRepository.GetAsync(r => r.Id == id);
            if (restaurant == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "No restaurant found with this Id";
            }

            await _restaurantRepository.RemoveAsync(restaurant);

            return "Restaurant removed successfully!";
        }


        public async Task<string> UpdateAsync(int id)
        {
            Restaurant restaurant = await _restaurantRepository.GetAsync(r => r.Id == id);
            if (restaurant == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "No restaurant found with this Id ";
            }
            else
            {
                Console.WriteLine("Please enter new Restaurant name:");
                string name = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(name)|| name.Length>3 || name.Length<10)
                {
                    restaurant.Name = name;
                }
            }
            await _restaurantRepository.UpdateAsync(restaurant);
            Console.ForegroundColor = ConsoleColor.Green;
            return "Succesfuly updated";
        }

       
    }
}


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
    public class ProductService : IProductService
    {
        private readonly IRestaurantRepository _restaurantRepository = new RestaurantRepository();
        public async Task<string> CreateAsync(string name, double price, int restaurantid, ProductCategory productCategory)
        {

            List<Restaurant> restaurants = await _restaurantRepository.GetAllAsync();
            
            foreach (var restaurant in restaurants)
            {
                Product product = new Product(name, price, productCategory,restaurant);
                if (restaurant.Id == restaurantid)
                {
                    restaurant.Products.Add(product);
                    Console.ForegroundColor= ConsoleColor.Green;  
                    return "Product is added Successfully!";
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            return "No restaurant found with this ID ";
            
        }

        public async Task<List<Product>> GetAllAsync()
        {
            List<Restaurant> restaurants = await _restaurantRepository.GetAllAsync();
            List<Product> products = new List<Product>();
            
            foreach (Restaurant restaurant in restaurants)
            {
                products.AddRange(restaurant.Products);
            }
            return products;
        }
        public async Task<Product> GetAsync(int id)
        {
            List<Restaurant> restaurants = await _restaurantRepository.GetAllAsync();

            foreach (var item in restaurants)
            {
                Product product = item.Products.FirstOrDefault(p => p.Id == id);
                if (product != null)
                {
                    return product;
                }
            }
            return null;
        }

        public async Task<string> RemoveAsync(int id)
        {
            List<Restaurant> restaurants = await _restaurantRepository.GetAllAsync();

            foreach(var item in restaurants)
            {
                Product product=item.Products.FirstOrDefault(p => p.Id == id);
                if (product != null)
                {
                    item.Products.Remove(product);
                    Console.ForegroundColor = ConsoleColor.Green;
                    return "Product is Succesfully removed";
                }

            }
            Console.ForegroundColor = ConsoleColor.Red;
            return "Product with this Id this not found";
        }

        public async Task<string> UpdateAsync(int id, string name, double price)
        {
            List<Restaurant> restaurants= await _restaurantRepository.GetAllAsync();    
            foreach(var item in restaurants)
            {
              Product Product = item.Products.FirstOrDefault(p => p.Id == id);

                if(Product != null && !string.IsNullOrWhiteSpace(name))
                {
                    Product.Name = name;
                    Product.Price = price;  

                    Console.ForegroundColor= ConsoleColor.Green;
                    return "Product Successfully created";

                }

                
            }
            Console.ForegroundColor = ConsoleColor.Red;
            return "Product is not found!!";

        }

    }
}    


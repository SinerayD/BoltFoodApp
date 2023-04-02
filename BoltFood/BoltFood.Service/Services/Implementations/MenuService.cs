using BoltFood.Core.Enums;
using BoltFood.Core.Models;
using BoltFood.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BoltFood.Service.Services.Implementations
{
    public class MenuService:IMenuService
    {
        private readonly IRestaurantService _restaurantService= new RestaurantService();
        private readonly IProductService _productService= new ProductService();

        public async Task ShowMenuAsync()
        {
            Show();
            int.TryParse(Console.ReadLine(), out int request);
            while (request != 0)
            {
                switch (request)
                {
                    case 1:
                        Console.Clear();
                        await CreateRestaurant();
                        break;

                        case 2:
                        Console.Clear();
                        await ShowAllRestaurant();
                        break;

                    case 3:
                        Console.Clear();
                         await ShowRestaurant();
                        break;

                    case 4:
                        Console.Clear();
                        await UpdateRestaurant();
                        break;
                    case 5:
                        Console.Clear();
                        await RemoveRestaurant();
                        break;
                    case 6:
                        Console.Clear();
                        await CreateProduct();
                        break;
                    case 7:
                        Console.Clear();
                        await ShowAllProduct();
                        break; 
                    case 8:
                        Console.Clear();
                        await GetProductById();
                        break;
                    case 9:
                        Console.Clear();
                        await UpdateProduct();
                        break;
                    case 10:
                        Console.Clear();
                        await RemoveProduct();
                        break;
                    default:
                        Console.ForegroundColor= ConsoleColor.Red;  
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.ForegroundColor = ConsoleColor.White;

                Show();
                int.TryParse(Console.ReadLine(), out request);
            }
        }

        private void Show()
        {
            Console.WriteLine("1.Create Restaurant");
            Console.WriteLine("2.Show All Restaurant");
            Console.WriteLine("3.Get Restaurant By Id");
            Console.WriteLine("4.Update Restaurant");
            Console.WriteLine("5.Remove Restaurant");
            Console.WriteLine("6.Create Product");
            Console.WriteLine("7.Show All Product");
            Console.WriteLine("8.Get Product By Id");
            Console.WriteLine("9.Update Product");
            Console.WriteLine("10.Remove Product");
            Console.WriteLine("0. Quit");
        }
        public async Task CreateRestaurant()
         {
            Console.WriteLine("Please enter restaurant name ");
            string name=Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name) || name.Length < 3 || name.Length > 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Restaurant name should be between 3 and 10 characters.Restaurant not created.");
                return;
            }
            Console.ForegroundColor=ConsoleColor.White; 
            Console.WriteLine("Please choose restaurant Type below");

            var Enums = Enum.GetValues(typeof(RestaurantCategory));

                foreach (var item in Enums)
                {
                    Console.WriteLine((int)item + "." + item);
                }
                int.TryParse(Console.ReadLine(), out int restaurantCategory);

                try
                {
                    Enums.GetValue(restaurantCategory - 1);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Restaurant Category is not valid");
                    return;
                }

            string message = await _restaurantService.CreateAsync(name,(RestaurantCategory)restaurantCategory);
            Console.WriteLine(message);
            
         }

        public async Task ShowAllRestaurant()
        {
            List<Restaurant> restaurants = await _restaurantService.GetAllAsync();
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var item in restaurants)
            {
                Console.WriteLine(item);
            }
        }

        public async Task ShowRestaurant()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Please add Restaurant Id");
            int.TryParse(Console.ReadLine(), out int id);

            Restaurant restaurant = await _restaurantService.GetAsync(id);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(restaurant);
        }

        public async Task UpdateRestaurant()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Please Add Restaurant Id");
            int.TryParse(Console.ReadLine(), out int id);

            string message = await _restaurantService.UpdateAsync(id);
            Console.WriteLine(message);
        }

        public async Task RemoveRestaurant()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Add Restaurant Id");

            int.TryParse(Console.ReadLine(), out int id);

            string message = await _restaurantService.RemoveAsync(id);
            Console.WriteLine(message);

           
        }

        public async Task CreateProduct()
        { 
            Console.Write("Please add product name:");
            string name = Console.ReadLine();
            var Enums = Enum.GetValues(typeof(ProductCategory));

            foreach (var item in Enums)
            {
                Console.WriteLine((int)item + "." + item);
            }
            int.TryParse(Console.ReadLine(), out int productCategory);

            try
            {
                Enums.GetValue(productCategory - 1);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Product Category is not valid");
                return;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please enter Product Price");
            double.TryParse(Console.ReadLine(), out double price);
            if(price < 0 || price>200)
            {
                Console.WriteLine("Product Price updated");
                return;

            }
            Console.Write("Restaurant Id :");
            int.TryParse(Console.ReadLine(), out int restaurantId);

            string message = await _productService.CreateAsync(name, price, restaurantId, (ProductCategory)productCategory);

        }

        public async Task ShowAllProduct()
        {
            List<Product> products = await _productService.GetAllAsync();

            Console.ForegroundColor = ConsoleColor.Cyan;

            foreach (var item in products)
            {
                Console.WriteLine(item);
            }
        }
        public async Task GetProductById()
        {
            Console.ForegroundColor = ConsoleColor.White;   

            Console.WriteLine("Please add Product Id");

            int.TryParse(Console.ReadLine(), out int id);

            Product product = await _productService.GetAsync(id);

            Console.WriteLine(product);
        }

        public async Task UpdateProduct()
        {
            Console.WriteLine("Please enter Id of the product that will be updated: ");
            int.TryParse(Console.ReadLine(), out int id);


            Console.WriteLine("Please enter Product price : ");
            double.TryParse(Console.ReadLine(), out double price);

            Console.WriteLine("Please enter the Product category \n=>Appetizers\n=>Soup\n=>Salad\n=>Main_Course\n=>Desserts\n=>Beverages ");
            Enum.TryParse(Console.ReadLine(), out ProductCategory category);

        }

        public async Task RemoveProduct()
        {
            Console.WriteLine("Please add Product Id");

            int.TryParse(Console.ReadLine(), out int id);

            string message = await _productService.RemoveAsync(id);

            Console.WriteLine(message);
        }
    }
}


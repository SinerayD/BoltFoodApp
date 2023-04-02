using BoltFood.Core.Enums;
using BoltFood.Core.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Core.Models
{
    public class Product:BaseEntity
    {
        private static int _id;
        public string Name { get; set; }
        public double Price { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public Restaurant restaurant { get; set; }
        
        public Product(string name, double price, ProductCategory productCategory,Restaurant restaurant )
        {
            _id++;
            Id = _id;
            Name = name;    
            Price = price;  
            ProductCategory = productCategory;
            this.restaurant = restaurant;

        }
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Price: {Price}, Category: {ProductCategory}, Restaurant Name: {restaurant.Name}";
        }
    }
}

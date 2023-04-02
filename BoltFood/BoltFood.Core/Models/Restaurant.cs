using BoltFood.Core.Enums;
using BoltFood.Core.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BoltFood.Core.Models
{
    public class Restaurant : BaseEntity
    {
        private int _id;
        public string RestaurantNo { get; set; }
        public string Name { get; set; }
        public RestaurantCategory Category { get; set; }

        public List<Product> Products;

        public Restaurant(string name,RestaurantCategory RestaurantCategory)
        {
            _id++;
            Id = _id;
            Name = name;
            Category = RestaurantCategory;
            Products = new List<Product>();


        }
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Category: {Category}";
        }

    }

}    
        

    

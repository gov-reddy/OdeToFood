
using System;
using System.Collections.Generic;
using OdeToFood.Core;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurantById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Add(Restaurant newRestaurant);
        int Commit();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{ Id = 1, Name = "Gov's Pizza", Location = "Hershey", Cuisine =Restaurant.CuisineType.Mexican},
                new Restaurant{ Id = 2, Name = "Yashu's Fries", Location = "Enola",Cuisine =Restaurant.CuisineType.Mexican},
                new Restaurant{ Id = 3, Name = "Pete's Biryani", Location = "Harrisburg",Cuisine =Restaurant.CuisineType.Indian},
                new Restaurant{ Id = 4, Name = "Tims' Chai", Location = "Mechanicsburg",Cuisine =Restaurant.CuisineType.Italian},
                new Restaurant{ Id = 5, Name = "Super Coffee", Location = "Carlisle",Cuisine =Restaurant.CuisineType.None}

            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return  from r in restaurants
                    where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                    orderby r.Name
                    select r;
        }

        public Restaurant GetRestaurantById(int id = 0)
        {
            return restaurants.SingleOrDefault(i => i.Id == id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Cuisine = updatedRestaurant.Cuisine;

            }
            return restaurant;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {            
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return 0;
        }
    }
}

using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
                {
                    new Restaurant { Id = 1, Name = "Brian's Pizza", Cuisine = CuisineType.Italian},
                    new Restaurant { Id = 2, Name = "Tersiguels", Cuisine = CuisineType.French},
                    new Restaurant { Id = 3, Name = "India Cafe", Cuisine = CuisineType.Indian}
                };
        }

        public void Add(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
        }

        public void Update(Restaurant restaurant)
        {
            var exisiting = Get(restaurant.Id);
            if(exisiting != null)
            {
                exisiting.Name = restaurant.Name;
                exisiting.Cuisine = restaurant.Cuisine;
            }
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }
    }
}

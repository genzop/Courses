using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> _Restaurants;

        public InMemoryRestaurantData()
        {
            _Restaurants = new List<Restaurant>
            {
                new Restaurant{ Id = 1, Name = "Enzo's Pizza Place" },
                new Restaurant{ Id = 2, Name = "Tersiguels" },
                new Restaurant{ Id = 3, Name = "King's Contrivance" }
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _Restaurants.OrderBy(x => x.Name);
        }
    }
}

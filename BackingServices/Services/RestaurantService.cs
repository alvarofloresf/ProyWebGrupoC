using BackingServices.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BackingServices.Services
{
    public class RestaurantService
    {
        public async Task<Restaurant> GetRestaurantServiceAsync()
        {
            try
            {
                Console.WriteLine("Pidiendo info de Restaurant");
                using (HttpClient client = new HttpClient())
                {
                    Restaurant restaurant = new Restaurant();
                    string restaurantURL = "https://random-data-api.com/api/restaurant/random_restaurant";
                    HttpResponseMessage response = await client.GetAsync(restaurantURL);
                    if (response.IsSuccessStatusCode)
                    {
                        dynamic restaurantBody = await response.Content.ReadAsStringAsync();
                        dynamic res = JsonConvert.DeserializeObject(restaurantBody);// aca revisar
                        restaurant.Id = res["uid"];
                        restaurant.Name = res["name"];
                        restaurant.Description = res["description"];
                        restaurant.PhoneNumber = res["phone_number"];
                        return restaurant;
                    }
                    else
                    {
                        throw new Exception("HUBO FALLAS al pedir info del Restaurant");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("HUBO FALLAS al pedir info del Restaurant");
                Console.WriteLine(ex.Message + ex.StackTrace);
                throw;
            }
        }
    }
}

using JokeApiConsumtion.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JokeApiConsumtion.Controllers
{
    public class HomeController : Controller
    {
        private string url = "https://v2.jokeapi.dev/joke/Any";
        HttpClient client = new HttpClient();
       
        public IActionResult Index()
        {
            Joke obj = new Joke();
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var Data = JsonConvert.DeserializeObject<Joke>(result);
                if (Data != null)
                {
                    ViewData["setup"] = Data.setup;
                    ViewData["Delivery"] = Data.delivery;
                }
            }

            return View();
        }
    }
}

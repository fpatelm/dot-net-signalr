using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rx.Http;


namespace whiteboard_be_dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get() 
        {
            var rng = new Random();
            Func<int, int, int> f = (int a, int b)=>a+b;
            var mylist = new List<int>();
            mylist.Where(x=>x>2);

            var http = new RxHttpClient(new HttpClient());
            var s = await http.Get("https://reqbin.com/echo/get/json", options=>{
                options.AddHeader("hferbgu","gergertg");
            }); 

            Console.WriteLine(s);
        
        
        
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

        
        }
    }
}

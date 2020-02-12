using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAppNetCore1.Interfaces;
using WebAppNetCore1.Models;

namespace WebAppNetCore1.Controllers
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
        private readonly ISaleOrderService _saleOrderService;

        public WeatherForecastController(ISaleOrderService saleOrderService)
        {
            _saleOrderService = saleOrderService;
        }

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("sales/get")]
        public IEnumerable<SaleOrder> GetSaleOrders()
        {   
            return _saleOrderService.GetSaleOrders();
        }

        [HttpPost]
        [Route("sales/add")]
        public int AddSaleOrder(SaleOrder saleOrder)
        {
            return _saleOrderService.AddSaleOrder(saleOrder);
        }
    }
}

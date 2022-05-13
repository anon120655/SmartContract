using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SmartContract.Infrastructure.Data.ConnectionContext;
using SmartContract.Infrastructure.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartContract.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly smartContractContext _context;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, smartContractContext context)
        {
            _logger = logger;
            _context = context;
        }

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

        //[HttpGet("GetSmartmasters")]
        //public IEnumerable<Smartmaster> GetSmartmasters()
        //{
        //    return _context.Smartmasters.Include(x => x.Smartmasteritems).ToList();
        //}

        //[HttpGet("InsertSmartmasters")]
        //public IEnumerable<Smartmaster> InsertSmartmasters(String Str)
        //{
        //    Smartmaster smartmaster = new Smartmaster()
        //    {
        //        Mastername = $"Mastername_{Str}",
        //        Createdate = DateTime.Now
        //    };
        //    _context.Smartmasters.Add(smartmaster);
        //    _context.SaveChanges();

        //    return _context.Smartmasters.ToList();
        //}

        //[HttpGet("InsertSmartmasteritem")]
        //public IEnumerable<Smartmasteritem> InsertSmartmasteritem(String masterid, String Str)
        //{
        //    Smartmasteritem smartmasteritem = new Smartmasteritem()
        //    {
        //        Masterid = masterid,
        //        ItmeName = $"MasternameItem_{Str}",
        //    };
        //    _context.Smartmasteritems.Add(smartmasteritem);
        //    _context.SaveChanges();

        //    return _context.Smartmasteritems.ToList();
        //}

    }
}

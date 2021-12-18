using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUI.Features.Cars
{
    [Route("api/cars")]
    public class CarsController : Controller
    {
        [HttpGet]
        public ActionResult<List<Car>> GetCars()
        {
            var cars = new List<Car>()
            {
                new Car
                {
                    TeamName="Tam A",
                    Speed=100,
                    MelFunctionChance=0.2
                },
                 new Car
                {
                    TeamName="Tam B",
                    Speed=95,
                    MelFunctionChance=0.15
                }
            };

            return Ok(cars);
        }
    }
}


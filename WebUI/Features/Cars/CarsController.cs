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

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Car> GetCar(int id)
        {
            var car = new Car
            {
                TeamName = "Tam B",
                Speed = 95,
                MelFunctionChance = 0.15
            };

            return Ok(car);
        }

        //create car
        [HttpPost]
         public ActionResult<Car> CreateCar(Car car)
        {
            var newCar = new Car
            {
                Id = car.Id,
                TeamName = car.TeamName,
                Speed = car.Speed,
                MelFunctionChance = car.MelFunctionChance
            };

            return Ok(newCar);
        }

       
        [HttpPut]
        [Route("{id}")]
        public ActionResult<Car> UpdateMotorbike(Car car)
        {
            var carUpdated = new Car
            {
                Id = car.Id,
                TeamName = car.TeamName,
                Speed = car.Speed,
                MelFunctionChance = car.MelFunctionChance
            };

            return Ok(carUpdated);
        }

        //delete car
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCar(int id)
        {
            return Ok($"Car with id {id} was succesfuly deleted");
        }
    }
}


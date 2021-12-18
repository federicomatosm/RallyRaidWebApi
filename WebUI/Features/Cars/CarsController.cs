using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUI.Features.Cars
{
    [Route("api/cars")]
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Car>> GetCars()
        {
            var cars = _context.Cars.ToList();

            return Ok(cars);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Car> GetCar(int id)
        {
            var car = _context.Cars.FirstOrDefault(x => x.Id == id);
            if (car == null)
            {
                return NotFound($"The car with id {id} isn't not found");
            }

            return Ok(car);
        }

        //create car
        [HttpPost]
         public ActionResult<Car> CreateCar(Car car)
        {
            _context.Cars.Add(car);

            var result = _context.SaveChanges();
            if(result>0)
                return Ok(car);

            return BadRequest("Error while finding a car");
        }

       
        [HttpPut]
        [Route("{id}")]
        public ActionResult<Car> UpdateCar(int id,[FromBody]Car car)
        {
            var carToUpdate = _context.Cars.FirstOrDefault(x => x.Id == id);
            if (carToUpdate == null)
            {
                return NotFound($"The car with id {car.Id} is not  found");
            }
            carToUpdate.TeamName = car.TeamName;
            carToUpdate.Speed = car.Speed;
            carToUpdate.MelFunctionChance = car.MelFunctionChance;
            _context.SaveChanges();

            return Ok(carToUpdate);
        }

        //delete car
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCar(int id)
        {
            var car = _context.Cars.FirstOrDefault(x => x.Id == id);
            if (car == null)
            {
                return NotFound($"The car with id {id} isn't not found");
            }
            _context.Remove(car);
            _context.SaveChanges();
            return Ok($"Car with id {id} was succesfuly deleted");
        }
    }
}


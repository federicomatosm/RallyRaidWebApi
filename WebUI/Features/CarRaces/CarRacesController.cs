using System;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebUI.Features.CarRaces.Models;

namespace WebUI.Features.CarRaces
{
	[Route("api/carraces")]
	[ApiController]
	public class CarRacesController: ControllerBase
	{
        private readonly ApplicationDbContext _context;

        public CarRacesController(ApplicationDbContext context)
        {
            _context = context;
        }

		[HttpGet]
		public ActionResult<List<CarRace>> GetCarRaces()
        {
			var carRaces = _context.CarRaces.Include(x => x.Cars).ToList();
			return Ok(carRaces);
        }

		[HttpGet("{id}")]
		public ActionResult<CarRace> GetCarRace(int id)
			
		{
			var carRaces = _context.CarRaces.Include(x => x.Cars).FirstOrDefault(x => x.Id == id);
			return Ok();
		}

		[HttpPost]
		public IActionResult CreateCarRaces(CarRaceCreateModel carRace)
		{
			var newCarRace = new CarRace
			{
				Name = carRace.Name,
				Location = carRace.Location,
				Distance = carRace.Distance,
				Time = carRace.Time
			};

			_context.CarRaces.Add(newCarRace);
			if (_context.SaveChanges() > 0)
				return Ok(newCarRace);

			return BadRequest();
		}

		[HttpPut("{id}")]
		public IActionResult UpdateCarRaces(CarRaceUpdateModel carRaceUpdateModel)
		{
			var carRaces = _context.CarRaces.Include(x => x.Cars).FirstOrDefault(x => x.Id == carRaceUpdateModel.Id);
            if (carRaces == null)
            {
				return NotFound();
            }

			carRaces.Name = carRaceUpdateModel.Name;
			carRaces.Location = carRaceUpdateModel.Location;
			carRaces.Distance = carRaceUpdateModel.Distance;
			
			return Ok();
		}

		[HttpPut("{carRaceId}/Addcar/{carId}")]
		public ActionResult AddCarToCarRace(int carRaceId, int carId)
		{
			var dbCarRace = _context.CarRaces.Include(x => x.Cars).SingleOrDefault(x=> x.Id== carRaceId);
			if (dbCarRace == null)
			{
				return NotFound($"CarRace with carRaceId {carRaceId} not found");
			}

			var car = _context.Cars.SingleOrDefault(x => x.Id == carId);
			if(car == null)
            {
				return NotFound($"Car with carId {carId} not found");
			}

			dbCarRace.Cars.Add(car);
			_context.SaveChanges();
			return Ok(dbCarRace);
		}

		[HttpPut("{id}/start")]
		public IActionResult StartCarRaces(int id)
		{
			var carRace = _context.CarRaces.Include(x => x.Cars)
							.FirstOrDefault(x => x.Id == id);
			if (carRace == null)
			{
				return NotFound($"CarRace with id {id} not found");
			}
			carRace.Status = "Started";
			_context.SaveChanges();

			return Ok(carRace);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteCarRaces(int id)
		{
			var carRace = _context.CarRaces.Include(x => x.Cars)
							.FirstOrDefault(x => x.Id == id);

			if(carRace == null)
            {
				return NotFound($"CarRace with id {id} not found");
            }

			_context.Remove(carRace);
			_context.SaveChanges();
			return Ok($"CarRace with id {id} was succesfully deleted");
		}

	}
}


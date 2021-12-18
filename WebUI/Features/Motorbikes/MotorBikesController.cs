using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUI.Features.Motorbikes
{
    [ApiController]
    [Route("api/motorbikes")]
    public class MotorBikesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MotorBikesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<List<Motorbike>> GetMotorbikes()
        {
            

            return Ok(_context.Motorbikes.ToList());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Motorbike> GetMotorbike(int id)
        {
            var motorbike1 = _context.Motorbikes.FirstOrDefault(x => x.Id == id);
            if (motorbike1 == null)
            {
                return NotFound();
            }

            return Ok(motorbike1);
        }

        [HttpPost]
        public ActionResult<Motorbike> CreateMotorbike(Motorbike motorbike)
        {
            var newMotorbike = new Motorbike
            {
                Id = motorbike.Id,
                TeamName = motorbike.TeamName,
                Speed = motorbike.Speed,
                MelfunctionChance = motorbike.MelfunctionChance
            };
            _context.Motorbikes.Add(newMotorbike);
            var result = _context.SaveChanges();
            if(result>0)
                return Ok(newMotorbike);

            return BadRequest();
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<Motorbike> UpdateMotorbike(int id, Motorbike motorbike)
        {
            var motorBikeToUpdated = _context.Motorbikes.FirstOrDefault(x => x.Id == id);
            if (motorBikeToUpdated == null)
            {
                return NotFound();
            }

            motorBikeToUpdated.TeamName = motorbike.TeamName;
            motorBikeToUpdated.Speed = motorbike.Speed;
            motorBikeToUpdated.MelfunctionChance = motorbike.MelfunctionChance;

            _context.SaveChanges();
           

            return Ok(motorBikeToUpdated);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCar(int id)
        {
            var motorBikeToDelete= _context.Motorbikes.FirstOrDefault(x => x.Id == id);
            if (motorBikeToDelete == null)
            {
                return NotFound();
            }
            _context.Remove(motorBikeToDelete);
            _context.SaveChanges();

            return Ok($"Motorbike with id {id} was succesfuly deleted");
        }
    }
}


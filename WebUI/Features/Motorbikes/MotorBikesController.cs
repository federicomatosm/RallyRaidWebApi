﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUI.Features.Motorbikes
{
    [Route("api/motorbikes")]
    public class MotorBikesController : Controller
    {
        [HttpGet]
        public ActionResult<List<Motorbike>> GetMotorbikes()
        {
            var motorbikes = new List<Motorbike>();
            var motorbike1 = new Motorbike
            {
                TeamName = "Team A",
                Speed = 100,
                MelfunctionChance = 0.2
            };
            var motorbike2 = new Motorbike
            {
                TeamName = "Team B",
                Speed = 90,
                MelfunctionChance = 0.15
            };
            motorbikes.Add(motorbike1);
            motorbikes.Add(motorbike2);

            return Ok(motorbikes);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Motorbike> GetMotorbike(int id)
        {
            var motorbike1 = new Motorbike
            {
                TeamName = "Team A",
                Speed = 100,
                MelfunctionChance = 0.2
            };

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

            return Ok(newMotorbike);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<Motorbike> UpdateMotorbike(Motorbike motorbike)
        {
            var updateMotorbike = new Motorbike
            {
                Id = motorbike.Id,
                TeamName = motorbike.TeamName,
                Speed = motorbike.Speed,
                MelfunctionChance = motorbike.MelfunctionChance
            };

            return Ok(updateMotorbike);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCar(int id)
        {
            return Ok($"Motorbike with id {id} was succesfuly deleted");
        }
    }
}


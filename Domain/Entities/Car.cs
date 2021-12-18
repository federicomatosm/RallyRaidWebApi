using System;
namespace Domain.Entities
{
	public class Car
	{
        public int Id { get; set; }
        public string TeamName { get; set; }
        public int Speed { get; set; }
        public double MelFunctionChance { get; set; }
        public int MelFunctionsOccured { get; set; }
        public int DistanceConverInMiles { get; set; }
        public int FinishedRace { get; set; }
        public int RacedForHours { get; set; }
       

    }
}


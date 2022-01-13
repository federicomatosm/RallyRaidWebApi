using System;
namespace WebUI.Features.CarRaces.Models
{
	public class CarRaceCreateModel
	{
        public  int Time;

        public string Name { get; set; }
        public string Location { get; set; }
        public int Distance { get; set; }
        public int TimeLimit { get; set; }
    }
}


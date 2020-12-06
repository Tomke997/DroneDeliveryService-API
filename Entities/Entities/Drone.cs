using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ApplicationEntities
{
    public class Drone
    {
        public int DroneId { get; set; }

        public float CurrentPositionLat { get; set; }

        public float CurrentPositionLong { get; set; }

        public float CurrentPositionAlt { get; set; }

        public string Course { get; set; }

        public float Speed { get; set; }

        public DateTime Date { get; set; }

        public int Satelites { get; set; }
    }
}

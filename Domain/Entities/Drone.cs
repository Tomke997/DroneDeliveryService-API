using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Entities.ApplicationEntities
{
    [BsonIgnoreExtraElements]
    public class Drone
    {
        public int DroneId { get; set; }

        public string Lat { get; set; }

        public string Long { get; set; }

        public string Alt { get; set; }

        public string Course { get; set; }

        public string Speed { get; set; }

        public DateTime Date { get; set; }

        public int Satelites { get; set; }

        public bool CarryingOrder { get; set; }
    }
}

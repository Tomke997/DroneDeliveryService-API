using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Entities.ApplicationEntities
{
    [BsonIgnoreExtraElements]
    public class Order
    {
        public int OrderId { get; set; }

        public int AssignedDroneId { get; set; }

        public int OrderedItemId { get; set; }

        public DateTime OrderDate { get; set; }

        public string DeliveryAddress { get; set; }

        public string DeliveryAddressLat { get; set; }

        public string DeliveryAddressLong { get; set; }

        public string PickupLocation { get; set; }

        public string PickupLocationLat { get; set; }

        public string PickupLocationLong { get; set; }
    }
}
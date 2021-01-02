using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class MqttBrokerSettings : IMqttBrokerSettings
    {
        public string MqttUsername { get; set; }
        public string MqttPassword { get; set; }
        public string MqttIp { get; set; }
        public int MqttPort { get; set; }
    }
}

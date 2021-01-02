using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IMqttBrokerSettings
    {
        string MqttUsername { get; set; }
        string MqttPassword { get; set; }
        string MqttIp { get; set; }
        int MqttPort { get; set; }
    }
}

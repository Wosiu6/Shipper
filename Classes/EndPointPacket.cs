using System;
using System.Net;

namespace Classes
{
    [Serializable]
    public class EndPointPacket : Packet
    {
        public EndPoint EndPoint;

        public EndPointPacket(EndPoint endP)
        {
            EndPoint = endP;
            Type = PacketType.ENDPOINT;
        }
    }
}
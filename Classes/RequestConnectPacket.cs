using System;

namespace Classes
{
    [Serializable]
    public class RequestConnectPacket : Packet
    {
        public RequestConnectPacket()
        {
            Type = PacketType.REQUESTCONNECT;
        }
    }
}
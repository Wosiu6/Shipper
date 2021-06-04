using System;

namespace Classes
{
    [Serializable]
    public class RequestDisconnectPacket : Packet
    {


        public RequestDisconnectPacket()
        {
            Type = PacketType.REQUESTDISCONNECT;
        }
    }
}
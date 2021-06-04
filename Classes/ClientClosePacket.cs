using System;

namespace Classes
{
    [Serializable]
    public class ClientClosePacket : Packet
    {
        public ClientClosePacket()
        {
            Type = PacketType.CLIENTCLOSE;
        }
    }
}
using System;

namespace Classes
{
    [Serializable]
    public class MessagePacket : Packet
    {
        public string msg { private set; get; }
        public MessagePacket(string msg)
        {
            this.msg = msg;
            Type = PacketType.MESSAGEPACKET;
        }
    }
}
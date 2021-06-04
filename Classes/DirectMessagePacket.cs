using System;

namespace Classes
{
    [Serializable]
    public class DirectMessagePacket : Packet
    {
        public string receiverID { private set; get; }
        public string msg { private set; get; }

        public DirectMessagePacket(string receiverID, string msg)
        {
            Type = PacketType.DIRECTMESSAGE;
            this.receiverID = receiverID;
            this.msg = msg;
        }
        public DirectMessagePacket(string receiverID)
        {
            Type = PacketType.NOTCONNECTEDDIRECTMESSAGE;
            this.receiverID = receiverID;
        }
    }
}
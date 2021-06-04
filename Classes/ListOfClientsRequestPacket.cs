using System;

namespace Classes
{
    [Serializable]
    public class ListOfClientsRequestPacket : Packet
    {
        public ListOfClientsRequestPacket()
        {
            Type = PacketType.LISTOFCLIENTREQUEST;
        }
    }
}
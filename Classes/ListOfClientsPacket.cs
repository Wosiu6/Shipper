using System;
using System.Collections.Generic;

namespace Classes
{
    [Serializable]
    public class ListOfClientsPacket : Packet
    {
        public SortedDictionary<string, int> ListOfClients;

        public ListOfClientsPacket(SortedDictionary<string, int> clients)
        {
            ListOfClients = clients;
            Type = PacketType.LISTOFCLIENTS;
        }
    }
}
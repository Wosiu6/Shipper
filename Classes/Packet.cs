using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Classes
{
    public enum PacketType
    {

        INITTYPE,
        NICKNAMEPACKET,
        MESSAGEPACKET,
        LISTOFCLIENTS,
        AVATAR,
        DIRECTMESSAGE,
        CLIENTCLOSE,
        LISTOFCLIENTREQUEST,
        IMAGE,
        CLEANIMAGE,
        REQUESTCONNECT,
        REQUESTDISCONNECT,
        ENDPOINT,
        PAINT,
        CHANGEPAINT,
        REQUESTPAINT,
        NOTCONNECTEDDIRECTMESSAGE

    }

    [Serializable]
    public class Packet
    {
        public PacketType Type { get; set; }

        public Packet()
        {
            Type = PacketType.INITTYPE;
        }

        public static byte[] Serialize(object o)
        {
            var ms = new MemoryStream(1024 * 4);
            var bf = new BinaryFormatter();
            bf.Serialize(ms, o);
            return ms.ToArray();
        }

        public static object Desirialize(byte[] bt)
        {
            var ms = new MemoryStream(1024 * 4);

            foreach (byte b in bt)

                ms.WriteByte(b);

            ms.Position = 0;
            var bf = new BinaryFormatter();
            var obj = bf.Deserialize(ms);
            ms.Close();
            return obj;
        }
    }
}
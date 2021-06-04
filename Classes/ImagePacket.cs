using System;
using System.Drawing;

namespace Classes
{
    [Serializable]
    public class ImagePacket : Packet
    {
        public byte[] bitmap;

        public Point direction;
        public ImagePacket(Point direction, byte[] image)
        {
            this.direction = direction;
            bitmap = image;
            Type = PacketType.IMAGE;
        }
        public ImagePacket(byte[] bitmap)
        {
            this.bitmap = bitmap;
            Type = PacketType.IMAGE;
        }
        public ImagePacket(Point direction)
        {
            this.direction = direction;
            Type = PacketType.IMAGE;
        }
    }
}
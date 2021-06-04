using System;
using System.Drawing;

namespace Classes
{
    [Serializable]
    public class PaintPacket : Packet
    {
        public Point point;
        public Point currentPoint;
        public Bitmap bmp;
        public Color col;
        public int size;

        public PaintPacket()
        {
            Type = PacketType.REQUESTPAINT;
        }

        public PaintPacket(Bitmap bmp)
        {
            this.bmp = bmp;
            Type = PacketType.CHANGEPAINT;
        }

        public PaintPacket(Point lastpoint, Point g, Color col, int size)
        {
            currentPoint = g;
            point = lastpoint;
            Type = PacketType.PAINT;
            this.col = col;
            this.size = size;
        }
    }
}
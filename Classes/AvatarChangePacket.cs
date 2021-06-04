using System;

namespace Classes
{
    [Serializable]
    public class AvatarChangePacket : Packet
    {
        public int avatarID;
        public AvatarChangePacket(int avatarID)
        {
            Type = PacketType.AVATAR;
            this.avatarID = avatarID;
        }
    }
}
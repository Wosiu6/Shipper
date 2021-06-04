using System;

namespace Classes
{
    [Serializable]
    public class NicknamePacket : Packet
    {
        public string nickname { private set; get; } //id
        public int avatarIndex { private set; get; }

        public NicknamePacket(string nickname, int avatarIndex)
        {
            this.avatarIndex = avatarIndex;
            this.nickname = nickname;
            Type = PacketType.NICKNAMEPACKET;
        }
    }
}
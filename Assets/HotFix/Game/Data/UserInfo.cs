using System;
using System.Collections.Generic;
using _Game.Scripts.Base;

namespace _Game.Scripts.Data
{
    [Serializable]
    public class UserInfo
    {
        public string userName;
        public string userFrame;
        public string userAvatar;
        public long coin;
        public long rose;
        public SerializableDictionary<int, long> giftDict;
    }
}
using System;
using System.Collections.Generic;
using _Game.Scripts.Base;

namespace _Game.Scripts.Data
{
    [Serializable]
    public class UserInfo
    {
        public string userName;
        public string userAvatar;
        public long coin;
        public long flower;
        public SerializableDictionary<int, long> giftDict;
    }
}
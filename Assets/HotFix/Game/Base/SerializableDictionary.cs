using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Base
{
    [Serializable]
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
    {
        [SerializeField] private List<TKey> keys = new();
        [SerializeField] private List<TValue> values = new();

        public void OnBeforeSerialize()
        {
            keys.Clear();
            values.Clear();
            foreach (KeyValuePair<TKey, TValue> pair in this)
            {
                keys.Add(pair.Key);
                values.Add(pair.Value);
            }
        }

        public void OnAfterDeserialize()
        {
            Clear();
            for (int i = 0; i < Math.Min(keys.Count, values.Count); i++)
            {
                Add(keys[i], values[i]);
            }
        }
    }
}
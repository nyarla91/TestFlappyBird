using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Extentions
{
    [Serializable]
    public class SerializedDictionary<TKey, TValue>
    {
        [SerializeField] private List<SerializedKeyValuePair<TKey, TValue>> _pairs;

        private Dictionary<TKey, TValue> _dictionary;
        
        public List<SerializedKeyValuePair<TKey, TValue>> Pairs => _pairs;

        public Dictionary<TKey, TValue> Dictionary => GenerateDictionary();

        private Dictionary<TKey, TValue> GenerateDictionary()
        {
            return _pairs.ToDictionary(pair => pair.Key, pair => pair.Value);
        }
    }

    [Serializable]
    public class SerializedKeyValuePair<TKey, TValue>
    {
        [SerializeField] private TKey _key;
        [SerializeField] private TValue _value;

        public TKey Key
        {
            get => _key;
            set => _key = value;
        }

        public TValue Value
        {
            get => _value;
            set => _value = value;
        }
    }
}
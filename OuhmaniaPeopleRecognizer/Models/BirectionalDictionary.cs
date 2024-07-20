using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace OuhmaniaPeopleRecognizer.Models
{
    public interface IBirectionalDictionary<TKey, TValue>
    {
        TKey GetByValue(TValue value);
        BirectionalDictionary<TKey, TValue> FromDictionary(Dictionary<TKey, TValue> source);
    }

    public class BirectionalDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IBirectionalDictionary<TKey, TValue>, ISerializable
    {
        private Dictionary<TValue, TKey> _inverted;

        public BirectionalDictionary()
        {
            _inverted = new Dictionary<TValue, TKey>();
        }

        public BirectionalDictionary(Dictionary<TKey, TValue> forward, Dictionary<TValue, TKey> backward)
        : base(forward)
        {
            _inverted = backward;
        }

        public new void Add(TKey key, TValue value)
        {
            base.Add(key, value);
            _inverted.Add(value, key);
        }

        public BirectionalDictionary<TKey, TValue> FromDictionary(Dictionary<TKey, TValue> source)
        {
            var values = source.Select(kv => kv.Value).ToList();
            var hasOnlyUniqeValues = values.Distinct().ToList().Count == values.Count;
            if (!hasOnlyUniqeValues)
                throw new Exception("Dictionary does not have unique values");

            var backward = source.ToDictionary(kv => kv.Value, kv => kv.Key);
            return new BirectionalDictionary<TKey, TValue>(source, backward);
        }

        public TKey GetByValue(TValue value)
        {
            return _inverted[value];
        }
    }
}

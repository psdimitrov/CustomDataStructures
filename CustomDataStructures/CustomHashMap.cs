namespace CustomDataStructures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomHashMap<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
    {
        public const int DefaultCapacity = 16;

        public const double LoadFactor = 0.75;

        private LinkedList<KeyValue<TKey, TValue>>[] slots;

        public CustomHashMap(int capacity = DefaultCapacity)
        {
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public int Capacity => this.slots.Length;

        public IEnumerable<TKey> Keys
        {
            get
            {
                return this.Select(element => element.Key);
            }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                return this.Select(element => element.Value);
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                return this.Get(key);
            }

            set
            {
                this.AddOrReplace(key, value);
            }
        }

        public void Add(TKey key, TValue value)
        {
            var slotNumber = this.FindSlotNumber(key);

            if (this.slots[slotNumber] == null)
            {
                this.slots[slotNumber] = new LinkedList<KeyValue<TKey, TValue>>();
            }

            if (this.slots[slotNumber].Any(element => element.Key.Equals(key)))
            {
                throw new ArgumentException("Key already exist: " + key);
            }

            this.slots[slotNumber].AddLast(new KeyValue<TKey, TValue>(key, value));
            this.Count++;

            this.GrowIfNeeded();
        }

        public bool AddOrReplace(TKey key, TValue value)
        {
            if (this.Find(key) == null)
            {
                this.Add(key, value);
                return true;
            }
            else
            {
                this.Find(key).Value = value;
                return false;
            }
        }

        public TValue Get(TKey key)
        {
            var result = this.Find(key);
            if (result == null)
            {
                throw new KeyNotFoundException("Missing key!");
            }

            return result.Value;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            var element = this.Find(key);

            if (element != null)
            {
                value = element.Value;
                return true;
            }

            value = default(TValue);
            return false;
        }

        public KeyValue<TKey, TValue> Find(TKey key)
        {
            var slotNumber = this.FindSlotNumber(key);
            var elements = this.slots[slotNumber];

            return elements?.FirstOrDefault(element => element.Key.Equals(key));
        }

        public bool ContainsKey(TKey key)
        {
            var result = this.Find(key) != null;

            return result;
        }

        public bool Remove(TKey key)
        {
            var slotNumber = this.FindSlotNumber(key);
            var elements = this.slots[slotNumber];
            var elementToRemove = this.Find(key);

            if (elementToRemove == null)
            {
                return false;
            }

            if (!elements.Remove(elementToRemove))
            {
                return false;
            }

            this.Count--;

            return true;
        }

        public void Clear()
        {
            Array.Clear(this.slots, 0, this.Capacity);
            this.Count = 0;
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[DefaultCapacity];
        }

        public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            return this.slots.Where(slot => slot != null).SelectMany(slot => slot).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void GrowIfNeeded()
        {
            if ((double)(this.Count + 1) / this.Capacity > LoadFactor)
            {
                this.Grow();
            }
        }

        private void Grow()
        {
            var newHashTable = new CustomHashMap<TKey, TValue>(2 * this.Capacity);
            foreach (var element in this)
            {
                newHashTable.Add(element.Key, element.Value);
            }

            this.slots = newHashTable.slots;
            this.Count = newHashTable.Count;
        }

        private int FindSlotNumber(TKey key)
        {
            var slotNumber = Math.Abs(key.GetHashCode()) % this.slots.Length;

            return slotNumber;
        }
    }
}

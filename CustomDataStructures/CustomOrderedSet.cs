namespace CustomDataStructures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CustomOrderedSet<T> : IEnumerable<T> where T : IComparable<T>
    {
        private readonly BinarySearchTree<T> elements;

        public CustomOrderedSet()
        {
            this.elements = new BinarySearchTree<T>();
            this.Count = 0;
        }

        public void Add(T element)
        {
            var added = this.elements.Insert(element);
            if (added)
            {
                this.Count++;
            }
        }

        public bool Contains(T element)
        {
            return this.elements.Contains(element);
        }

        public bool Remove(T element)
        {
            if (!this.Contains(element))
            {
                return false;
            }

            this.elements.Remove(element);
            this.Count--;

            return true;
        }

        public int Count { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            return this.elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

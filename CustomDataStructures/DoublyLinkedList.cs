namespace CustomDataStructures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        private ListNode head;

        private ListNode tail;

        public DoublyLinkedList()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode(element);
            }
            else
            {
                var newHead = new ListNode(element);
                newHead.NextNode = this.head;
                this.head.PrevNode = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode(element);
            }
            else
            {
                var newTail = new ListNode(element);
                newTail.PrevNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Empty collection");
            }

            var removedNode = this.head.Value;
            this.head = this.head.NextNode;
            if (this.head != null)
            {
                this.head.PrevNode = null;
            }
            else
            {
                this.tail = null;
            }

            this.Count--;

            return removedNode;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Empty collection");
            }

            var removedNode = this.tail.Value;
            this.tail = this.tail.PrevNode;
            if (this.tail != null)
            {
                this.tail.NextNode = null;
            }
            else
            {
                this.head = null;
            }

            this.Count--;

            return removedNode;
        }

        public void ForEach(Action<T> action)
        {
            var currentElement = this.head;
            while (currentElement != null)
            {
                action(currentElement.Value);
                currentElement = currentElement.NextNode;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentElement = this.head;
            while (currentElement != null)
            {
                yield return currentElement.Value;
                currentElement = currentElement.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];

            int index = 0;
            var currentNode = this.head;
            while (currentNode != null)
            {
                array[index] = currentNode.Value;
                index++;
                currentNode = currentNode.NextNode;
            }

            return array;
        }

        private class ListNode
        {
            public ListNode(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }

            public ListNode PrevNode { get; set; }

            public ListNode NextNode { get; set; }
        }
    }
}
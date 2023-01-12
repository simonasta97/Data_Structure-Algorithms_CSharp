namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;

    public class Queue<T> : IAbstractQueue<T>
    {
        private class Node
        {
            public T Element { get; set; }

            public Node Next { get; set; }

            public Node(T element, Node next)
            {
                Element = element;
                Next = next;
            }

            public Node(T element)
            {
                Element = element;
            }
        }

        private Node head;

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            var newNode = new Node(item);
            if (this.head == null)
            {
                this.head = newNode;
            }
            else
            {
                var node = this.head;
                while (node.Next != null)
                {
                    node = node.Next;
                }
                node.Next = newNode;
            }
            this.Count++;
        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            var oldHead = this.head;
            this.head = this.head.Next;
            Count--;
            return oldHead.Element;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            return this.head.Element;
        }

        public bool Contains(T item)
        {
            var head = this.head;
            while (head != null)
            {
                if (head.Element.Equals(item))
                {
                    return true;
                }
                head = head.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.head;
            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
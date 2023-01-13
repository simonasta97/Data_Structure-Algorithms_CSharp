﻿namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {

        private class Node
        {
            public Node Next { get; set; }

            public Node Previous { get; set; }

            public T Value { get; set; }

            public Node(T value)
            {
                this.Value = value;
            }
        }

        private Node head;
        private Node tail;
        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node(item);
            if (this.head == null)
            {
                this.head= newNode;
                this.tail= newNode;
            }
            else
            {
                this.head.Previous = newNode;
                newNode.Next = this.head;
                this.head = newNode;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node(item);
            if (this.head == null)
            {
                this.head = this.tail = newNode;

            }
            else
            {
                newNode.Previous = this.tail;
                this.tail.Next = newNode;
                this.tail = newNode;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            this.CheckIfListIsNotEmpty();

            return this.head.Value;
        }

        public T GetLast()
        {
            this.CheckIfListIsNotEmpty();

            return this.tail.Value;
        }

        public T RemoveFirst()
        {
            this.CheckIfListIsNotEmpty();

            var currentHead = this.head;

            if (this.head.Next == null)
            {
                this.head = this.tail = null;
            }
            else
            {
                var newHead = this.head.Next;
                newHead.Previous = null;
                this.head = newHead;
            }

            this.Count--;
            return currentHead.Value;
        }

        public T RemoveLast()
        {
            this.CheckIfListIsNotEmpty();

            Node current = this.tail;
            if (current.Previous == null)
            {
                this.head = this.tail = null;
            }
            else
            {
                Node newTail = this.tail.Previous;
                newTail.Next = null;
                this.tail = newTail;
            }

            this.Count--;
            return current.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void CheckIfListIsNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Doubly Linked List should not be empty!");
            }
        }
    }
}
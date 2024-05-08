using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp
{
    public class LinkedList<T> where T : IComparable
    {
        private Node<T> head;
        private Stack<T> minLeft;
        private Stack<T> minRight;
        private Stack<T> maxLeft;
        private Stack<T> maxRight;

        public LinkedList()
        {
            // Default constructor (initialize the min&max lists)
            this.Initialize();
        }

        public LinkedList(bool init)
        {
            this.Initialize();
        }

        /// <summary>
        /// Initialization of the Min & Max values lists.
        /// </summary>
        private void Initialize()
        {
            this.minLeft = new Stack<T>();
            this.minRight = new Stack<T>(); 
            this.maxLeft = new Stack<T>();  
            this.maxRight = new Stack<T>();
        }


        public void Append(Node<T> node)
        {
            // Add an item from right of the list. (0 -> 1 -> 2 -> null)
            if (this.head == null)
            {
                this.head = node;
                    this.maxRight.Push(node.Value);
                    this.minRight.Push(node.Value);
                return;
            }

            Node<T> current = head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = node;

            // Checking for min or max.
            
            if (node.Value.CompareTo(this.maxRight.Peek()) >= 0)
                this.maxRight.Push(node.Value);
            
            if (node.Value.CompareTo(this.minRight.Peek()) <= 0)
                this.minRight.Push(node.Value);
        }

        public void Append(T val)
        {
            Node<T> node = new Node<T>(val);

            this.Append(node);
        }

        public void Prepend(T val)
        {
            Node<T> node = new Node<T>(val, this.head);
            this.head = node;

            if (this.maxLeft.Count == 0 ||
                node.Value.CompareTo(this.maxLeft.Peek()) >= 0)
                this.maxLeft.Push(node.Value);

            if (this.minLeft.Count == 0 ||
                node.Value.CompareTo(this.minLeft.Peek()) <= 0)
                this.minLeft.Push(node.Value);
        }

        public T Pop()
        {
            Node<T> current = this.head;
            Node<T> next = current.Next;

            while (next.Next != null)
            {
                current = current.Next;
                next = next.Next;
            }

            current.Next = null;

            if (this.maxRight.Count > 0 && next.Value.CompareTo(this.maxRight.Peek()) == 0)
                this.maxRight.Pop();

            if (this.minLeft.Count > 0 && next.Value.CompareTo(this.minRight.Peek()) == 0)
                this.minRight.Pop();

            return next.Value;
        }

        public T Unqueue()
        {
            T val = this.head.Value;
            this.head = this.head.Next;

            if (this.maxLeft.Count > 0 && val.CompareTo(this.maxLeft.Peek()) == 0)
                this.maxLeft.Pop();

            if (this.minLeft.Count > 0 && val.CompareTo(this.minLeft.Peek()) == 0)
                this.minLeft.Pop();

            return val;
        }

        public IEnumerable<T> GetList()
        {
            Node<T> current = this.head;

            while (current.Next != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public bool IsCircular()
        {
            if (this.head == null || this.head.Next == null)
                return false;

            Node<T> slow = this.head;
            Node<T> fast = this.head.Next;

            while (slow != fast)
            {
                if (slow.Next != null)
                    slow = slow.Next;
                else
                    return false;

                if (fast.Next != null && fast.Next.Next != null)
                    fast = fast.Next.Next;
                else
                    return false;
            }

            return true;
        }

        public void Sort() 
        {
            Node<T> node, help, last;
            bool isSorted = false;

            while (!isSorted)
            {
                node = this.head;
                last = null;
                isSorted = true;
                

                while (node.Next != null)
                {
                    help = node.Next;
                    if (node.Value.CompareTo(node.Next.Value) > 0)
                    {
                        isSorted = false;
                        if (last != null)
                            last.Next = help;
                        else
                            this.head = help;
                        node.Next = help.Next;
                        help.Next = node;
                        last = help;
                    }
                    else
                    {
                        last = node;
                        node = help;
                    }
                }
            }
        }

        public T GetMaxValue()
        {
            if (this.maxLeft.Count > 0 && this.maxRight.Count == 0)
                return this.maxLeft.Peek();
            else if (this.maxRight.Count > 0 && this.maxLeft.Count == 0)
                return this.maxRight.Peek();

            if (this.maxLeft.Peek().CompareTo(this.maxRight.Peek()) > 0)
                return this.maxLeft.Peek();
            return this.maxRight.Peek();
        }

        public T GetMinValue()
        {
            if (this.minLeft.Count > 0 && this.minRight.Count == 0)
                return this.minLeft.Peek();
            else if (this.minRight.Count > 0 && this.minLeft.Count == 0)
                return this.minRight.Peek();

            if (this.minLeft.Peek().CompareTo(this.minRight.Peek()) < 0)
                return this.minLeft.Peek();
            return this.minRight.Peek();
        }
        
        public override string ToString()
        {
            string res = "";

            Node<T> n = this.head; 

            while (n != null)
            {
                res += n.Value + " -> ";
                n = n.Next;
            }

            return res + "null";
        }
    }
}

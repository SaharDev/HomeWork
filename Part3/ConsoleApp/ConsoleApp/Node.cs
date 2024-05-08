using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Node<T>
    {
        private T value;
        private Node<T> next = null;

        public T Value { get => this.value; set => this.value = value; }
        public Node<T> Next { get => this.next; set => this.next = value; }
        
        public Node(T val)
        {
            this.Value = val;
        }   

        public Node(T val, Node<T> next) : this(val)
        {
            this.Next = next;
        }

    }
}

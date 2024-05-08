using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //LinkedList<int> lst = new LinkedList<int>();
            //lst.Append(1);
            //lst.Append(2);
            //lst.Append(3);
            //lst.Append(4);
            //lst.Prepend(5);
            //lst.Pop();
            //lst.Unqueue();

            //Console.WriteLine(lst);
            //Console.WriteLine($"Max: {lst.GetMaxValue()},\nMin: {lst.GetMinValue()}");
            //lst.Pop();
            //lst.Unqueue();
            //lst.Unqueue();
            //lst.Append(3);
            //lst.Append(4);
            //lst.Prepend(5);
            //Console.WriteLine(lst);
            //Console.WriteLine($"Max: {lst.GetMaxValue()},\nMin: {lst.GetMinValue()}");


            //Node<int> ten = new Node<int>(10),
            //    nine = new Node<int>(9,ten),
            //    eight = new Node<int>(8, nine), 
            //    even = new Node<int>(7, eight),
            //    six  = new Node<int>(6, even),
            //    five = new Node<int>(5, six);
            //ten.Next = five;
            //lst.Append(five);
            //Console.WriteLine(lst.IsCircular());
            //Console.WriteLine(lst);
            //lst.Sort();
            //Console.WriteLine(lst);


            ////Console.WriteLine(lst.Pop());

            //foreach (int i in lst.GetList())
            //{
            //    Console.WriteLine(i);
            //}

            //Console.WriteLine(lst.IsCircular());

            //Console.WriteLine(lst);

            NumericalExpression n = new NumericalExpression(4165442415676);
            Console.WriteLine(n);
            //Console.WriteLine(NumericalExpression.SumLetters(151895));
            Console.ReadKey();
        }
    }
}

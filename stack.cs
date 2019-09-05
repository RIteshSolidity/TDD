using System;
using System.Collections;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Stack {
        private ArrayList elements = new ArrayList();
        public bool isEmpty() {
            return elements.Count == 0;
        }

        public void Push(object value) {
            elements.Insert(0, value);            
        }

        public object Pop()
        {
            object temp = Top();
            elements.Remove(temp);
            return temp;
        }

        public object Top()
        {
            if (isEmpty())
                throw new InvalidOperationException("empty stack cannot be topped");
            object temp = elements[0];
            return temp;
        }
    }
}

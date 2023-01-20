using System;

namespace LinkedList
{
    public class Stack
    {
        public Node Top;

        public void push (int data)
        {
            Node newNode = new Node (data);
            if (this.Top == null) {
                newNode.next = this.Top;
            }
            this.Top = newNode;
            Console.WriteLine($" The new top element is : {data}");
        }

        public void peek()
        {
            Node node = this.Top;
            Console.WriteLine($"The top element is : {node.data}");
        }
    }
}

using System;

namespace LinkedList
{

	public class LL
	{

		public Node head;

		// USE CASE - 1, 3
		public void ll_Add(int data)
		{
			Node node = new Node(data);


			if (head == null)
			{
				this.head = node;
			}
			else
			{
				Node temp = head;
				while (temp.next != null)
				{
					temp = temp.next;
				}
				temp.next = node;
			}

			Console.WriteLine($"The number add is {data}");
		}

		// USE CASE - 2 
		public void ll_Addfront(int data)
		{
			Node node = new Node(data);
			node.next = head;
			head = node;
		}


		public void display()
		{
			Node temp = head;
			if (temp == null) {
				Console.WriteLine("The LinkedList is empty");
			}
			else
			{
				while(temp.next != null)
				{
					Console.Write(temp.data + " -> ");
					temp = temp.next;
				}
				Console.Write(temp.data);

			}
		}

		public void ll_InsertMid(int data ,int item)
		{
			Node node = new Node(data);
			if (head == null)
			{
				Console.WriteLine("The LL is empty");
			}
			else
			{	
				Node temp = head;
				while (temp.next != null && temp.data!= item) {
					temp = temp.next;
				}

				if (temp.next == null)
				{
					temp.next = node;
				}
				else
				{
					Node next_node = temp.next;
					temp.next = node;
					node.next = next_node;
				}
			}
		}
	}
}
using System;

namespace UnsafeStackAndLinkedList
{
    public struct DoublyLinkedList
    {
        public Node head;
        public Node tail;
        
        public class Node
        {
            public int data;
            public Node next;
            public Node prev;
        }
        
        private Node CreateNewNode(int data)
        {
            Node newNode = new Node();
            newNode.data = data;
            newNode.next = null;
            newNode.prev = null;
            return newNode;
        }


        public void InsertAtHead(int data)
        {
            Node newNode = CreateNewNode(data);

            if (head == null)
            {
                head = newNode;
                tail = head;
                return;
            }

            head.prev = newNode;
            newNode.next = head;
            head = newNode;
            
            return;
        }


        public void Print()
        {
            Console.WriteLine("Printing from head...");
            if (head == null)
            {
                Console.WriteLine("List is empty");
                return;
            }

            Node temp = head;

            while (temp != null)
            {
                Console.Write($"{temp.data} ");
                temp = temp.next;
            }

            Console.WriteLine();
        }


        public void PrintReverse()
        {
            Console.WriteLine("Reversal printing...");
            if (tail == null)
            {
                Console.WriteLine("List is empty");
                return;
            }

            Node temp = tail;
            while (temp != null)
            {
                Console.Write($"{temp.data.ToString()} ");
                temp = temp.prev;
            }
            
            Console.WriteLine();
        }


        public Node Search(int data)
        {
            
            if (head == null)
            {
                Console.WriteLine($"There isn't element with value {data.ToString()} in the List");
                return null;
            }
            
            Node temp = head;
            while (temp.data != data)
            {
                temp = temp.next;
            }
            
            return temp;
        }


        public void Delete(int data)
        {
            Node rmNode = Search(data);
            if (rmNode == null)
                return;

            if (rmNode == head)
            {
                rmNode.next.prev = null;
                head = rmNode.next;
            }
            else if (rmNode == tail)
            {
                rmNode.prev.next = null;
                tail = rmNode.prev;
            }
            else
            {
                rmNode.prev.next = rmNode.next;
                rmNode.next.prev = rmNode.prev;
            }
            
            Console.WriteLine($"Element with value {data.ToString()} deleted!");
        }
    }
}
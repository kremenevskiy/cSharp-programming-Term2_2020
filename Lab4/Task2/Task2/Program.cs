using System;
using System.Collections;
using System.Runtime.InteropServices;
//using System.Runtime.InteropServices;
using UnsafeStackAndLinkedList;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Project is working with UnsafeStackAndLinkedList.dll\n");
            
            // Working with unsafe code, implemented in class "UnsafeStack"
            Console.WriteLine("_______Working with unsafe Stack_______\n");
            
            UnsafeStack stack = new UnsafeStack();
            stack.Init();
            
            for (int i = 0; i < 13; i++)
            {
                stack.PushBack(i*i);
            }
            
            stack.ShowCurrent();
            
            Console.WriteLine("Popping top elements: ");
            for (int i = 0; i < 14; i++)
            {
                int temp = stack.Pop();
                Console.Write(temp.ToString() + " ");
            }

            Console.WriteLine("Adding few more elements...");
            for (int i = 0; i < 20; i++)
            {
                stack.PushBack(i*i*i);
            }
            
            stack.ShowCurrent();
            
            // Show all elements without deleting
            stack.ExtractAllStack();
            
            
            
            // Working with DoublyLinkedList
            Console.WriteLine("\n\n_______Working with DoublyLinkedList_______\n");
            
            DoublyLinkedList linkedList = new DoublyLinkedList();

            
            Random rand = new Random(12);
            for (int i = 0; i < 5; i++)
            {
                linkedList.InsertAtHead(rand.Next(0, 10));
            }
            
            // few more elements
            linkedList.InsertAtHead(1000);
            linkedList.InsertAtHead(1200);
            linkedList.InsertAtHead(333);
            linkedList.InsertAtHead(2);
            linkedList.InsertAtHead(124);
            linkedList.InsertAtHead(34);
            linkedList.InsertAtHead(424);
            linkedList.InsertAtHead(1);
            
            linkedList.Print();
            linkedList.PrintReverse();
            
            Console.WriteLine("\nDeleting few elements...\n");
            linkedList.Delete(1000);
            linkedList.Delete(333);
            linkedList.Delete(34);
            linkedList.Delete(124);

            // Printing 
            Console.WriteLine();
            linkedList.Print();
            linkedList.PrintReverse();
        }
    }
}
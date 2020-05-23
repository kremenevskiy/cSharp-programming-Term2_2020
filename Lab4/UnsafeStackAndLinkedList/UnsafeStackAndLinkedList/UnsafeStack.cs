using System;

namespace UnsafeStackAndLinkedList
{
    unsafe public struct UnsafeStack
    {
        private const int SIZE = 1000;
        
        public fixed int array[SIZE];
        private int top;
        private bool initialized;

        
        public void Init()
        {
            top = -1;
            initialized = true;
        }

        
        public void ExtractAllStack()
        {
            fixed (int* arrayPtr = array)
            {
                int* pointer = arrayPtr;
                
                Console.Write("All Stack values: ");
                for (int i = 0; i <= top; i++)
                {
                    Console.Write($"{*pointer} ");
                    pointer++;
                }
                
                Console.WriteLine();
            }
        }
        

        public void PushBack(int data)
        {
            if (initialized)
            {
                if (top < SIZE)
                {
                    array[++top] = data;
                    
                }
                else
                {
                    Console.WriteLine("Stack is full");
                }
            }
            else
            {
                Console.WriteLine("Can't add element in Stack!\n" +
                                  "First initialize Stack with: <stack>.init");
            }
        }

        
        public int Pop()
        {
            if (initialized)
            {
                if (isEmpty())
                {
                    Console.WriteLine("Stack is empty! Couldn't get number from empty stack");
                    return 0;
                }
                else
                {
                    return array[top--];
                }
            }
            else
            {
                Console.WriteLine("First initialize the Stack with <stack>.init\n");
                return 0;
            }
        }
        
        
        private bool isEmpty()
        {
            return top == -1;
        }

        
        public void ShowCurrent()
        {
            Console.WriteLine("Element at the top: {0}", array[top].ToString());
        }
    }
}
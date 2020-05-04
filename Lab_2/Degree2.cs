using System;
using System.Net;
using System.Numerics;

namespace Lab_2
{
    public class Degree2
    {
        
        public static ulong DegreeFrom0(ulong num)
        {
            ulong ans = 0;
            
            while (num > 0)
            {
                ans += num / 2;
                num /= 2;
            }
            
            return ans;
        }

        public static void Execute()
        {
            
            Console.WriteLine("Task: Рассчитать максимальную степень двойки, на которую делится произведение" +
                              " подряд идущих чисел от a до b (числа целые 64-битные без знака).\n");
            
            
            while (true)
            {
               

                ulong a = 0;
                ulong b = 0;
                
                try
                {
                    Console.Write("Enter value: a = ");
                    a = Convert.ToUInt64(Console.ReadLine());
                    Console.Write("Enter value: b = ");
                    b = Convert.ToUInt64(Console.ReadLine());

                    if (a == 0 || b == 0)
                    {
                        throw new Exception("Values must be greater then 0\n");
                    }
                    
                    if (a == b)
                        throw new Exception("Values can't be the same !!\n");

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}\n");
                    continue;
                }

                if (a > b)
                {
                    a ^= b;
                    b ^= a;
                    a ^= b;
                }
                
                int degreeOf2 = (int)(DegreeFrom0(b) - DegreeFrom0(a-1));
                int degreeOf2_2 = DegreeBigInt(a, b);
                
                // First way
                Console.WriteLine($"Max Degree of 2: {degreeOf2.ToString()}");
                
                // Second way, using BigInteger
                // Console.WriteLine($"Max Degree of 2: {degreeOf2_2.ToString()}");

                
                Console.WriteLine("\nPress any key to Continue\n");
                Console.ReadKey(true);
                
                break;
            }

        }

        public static int DegreeBigInt(ulong a, ulong b)
        {
            
            BigInteger bigInteger = new BigInteger(a);
            while (a <= b)
            {
                a++;
                bigInteger *= a;
            }

            int degree = 0;
            while (bigInteger % 2 == 0)
            {
                degree++;
                bigInteger /= 2;
            }

            return degree;
        }
    }
}
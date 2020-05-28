using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Fraction
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Constructor test
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Creating Fractions from different constructors");
            Console.ResetColor();
            
            List<Fraction> fractionsList = new List<Fraction>()
            {
                new Fraction(),
                new Fraction(24),
                new Fraction(25, 4),
                new Fraction(2.5),
                new Fraction(100, 50, 1, 1, 1),
                
            };
            Console.Write("List: ");
            foreach (var fractNumber in fractionsList)
            {
                Console.Write(fractNumber + ", ");
            }
            
            
            // Simplifying test
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\nAll fraction automatically simplifying to shortest form(if it possible)\n");
            Console.ResetColor();
            Console.WriteLine("List: ");

            List<Fraction> fractionsList2 = new List<Fraction>()
            {
                new Fraction(100,2),
                new Fraction(33, 3),
                new Fraction(21, 9),
                new Fraction(600, 21),
                new Fraction(4.2)
            };

            foreach (var fractNumber in fractionsList2)
            {
                Console.Write(fractNumber + ", ");
            }
            
            
            // Random number to Fraction test
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\n\nDemonstrating with random numbers!");
            Console.ResetColor();
            
            Console.WriteLine("\nFractions added to Array:\n");

            Random rand = new Random();
            
            int size = 20;
            Fraction[] fractArray = new Fraction[size];
            int size1 = size - 5;
            for (int i = 0; i < size1; i++)
            {
                long numerator = rand.Next(-1000, 1000);
                long denumerator = rand.Next(-1000, 1000);
                
                while (denumerator == 0)
                    denumerator = rand.Next(-1000, 1000);
                
                fractArray[i] = new Fraction(numerator, denumerator);
                Console.Write("{0, -21} | {1, -23} ===> {2, -10}\n", 
                    $"Rand numerator: {numerator.ToString()}", $"Rand Denomerator: {denumerator}", $"{fractArray[i]}");
            }

            Console.WriteLine("\nAlso adding to array few integers which equal to random frations:");

            int cnt = size1;
            while(cnt < size)
            {
                long numerator = rand.Next(-1000, 1000);
                long denumerator = rand.Next(-1000, 1000);
                
                while (denumerator == 0)
                    denumerator = rand.Next(-1000, 1000);
                
                Fraction fraction = new Fraction(numerator, denumerator);

                if (fraction.Denominator == 1)
                {
                    fractArray[cnt] = fraction;
                    cnt++;
                    Console.Write("{0, -21} | {1, -23} ===> {2, -10}\n", 
                        $"Rand numerator: {numerator.ToString()}", $"Rand Denomerator: {denumerator}", $"{fraction}");
                }
            }

            
            
            Console.WriteLine("\nPrinting all our Array:");
            foreach (var fractNum in fractArray)
            {
                Console.Write($"{fractNum}, ");
            }
            
            // Sorting test
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\nSorting our Array:");
            Console.ResetColor();
            
            Array.Sort(fractArray);
            
            foreach (var fractNum in fractArray)
            {
                Console.Write($"{fractNum}, ");
            }
            
            
            // Testing Math operators
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\nTesting Math operators:");
            Console.ResetColor();
            
            long numTest = 1;
            long denumTest = 0;
            long numTest2 = 1;
            long denumTest2 = 0;

            while (numTest == 1 || denumTest == 0 || numTest2 == 1 || denumTest2 == 0)
            {
                numTest = rand.Next(-20, 20);
                denumTest = rand.Next(-20, 20);
                numTest2 = rand.Next(-20, 20);
                denumTest2 = rand.Next(-20, 20);
            }
            
            Fraction fractTest1 = new Fraction(numTest, denumTest);
            Fraction fractTest2 = new Fraction(numTest2, denumTest2);

            Console.WriteLine("Our random fractions: {0}, {1}", fractTest1, fractTest2);
            Console.WriteLine($"{fractTest1} + {fractTest2} = {fractTest1+fractTest2}");
            Console.WriteLine($"{fractTest1} - {fractTest2} = {fractTest1-fractTest2}");
            Console.WriteLine($"{fractTest1} * {fractTest2} = {fractTest1*fractTest2}");
            Console.WriteLine($"{fractTest1} / {fractTest2} = {fractTest1/fractTest2}");
            Console.WriteLine($"{fractTest1} % {fractTest2} = {fractTest1%fractTest2}");
            Console.WriteLine($"{fractTest1} > {fractTest2} = {(fractTest1>fractTest2).ToString()}");
            Console.WriteLine($"{fractTest1} < {fractTest2} = {(fractTest1<fractTest2).ToString()}");
            Console.WriteLine($"{fractTest1} >= {fractTest2} = {(fractTest1>=fractTest2).ToString()}");
            Console.WriteLine($"{fractTest1} <= {fractTest2} = {(fractTest1<=fractTest2).ToString()}");
            Console.WriteLine($"{fractTest1} == {fractTest2} = {(fractTest1==fractTest2).ToString()}");
            Console.WriteLine($"++ {fractTest1} ==> {(++fractTest1).ToString()}");
            Console.WriteLine($"-- {fractTest1} ==> {(--fractTest1).ToString()}");

            
            // Testing Converting types from Fraction to simple C# types
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\nTesting Converting types from Fraction to simple C# types:");
            Console.ResetColor();
            
            fractTest1 = new Fraction(-17, 13);
            Console.WriteLine("Testing type converting with fraction: {0}", fractTest1);
            Console.WriteLine("Fraction to sbyte: {0}", ((sbyte)fractTest1).ToString());
            Console.WriteLine("Fraction to short: {0}", ((short)fractTest1).ToString());
            Console.WriteLine("Fraction to int: {0}", ((int)fractTest1).ToString());
            Console.WriteLine("Fraction to long: {0}", ((long)fractTest1).ToString());
            Console.WriteLine("Fraction to float: {0}", ((float)fractTest1).ToString());
            Console.WriteLine("Fraction to double: {0}", ((double)fractTest1).ToString());
            Console.WriteLine("Fraction to decimal: {0}", ((decimal)fractTest1).ToString());

            
            // Testing Converting float, double, decimal to Fraction type
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nTesting Converting float, double, decimal to Fraction type");
            Console.ResetColor();
            
            Fraction test = null;

            double duble = 9024.24;
            test = duble;
            Console.WriteLine("Double to Fraction: {0} ==> {1}", duble.ToString(), test);

            float floate = 9124.234f;
            test = floate;
            Console.WriteLine("Float to Fraction: {0} ==> {1}", floate.ToString(), test);

            decimal decim = 23412.32414m;
            test = decim;
            Console.WriteLine("Decimal to Fraction: {0} ==> {1}", decim.ToString(), test);



            // Demonstrating ToString Overloading
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nFraction ToString method:");
            Console.ResetColor();
            
            Fraction testString = new Fraction(12375, 5000);
            
            Console.WriteLine("Fractional Number: " + testString.ToString());
            Console.WriteLine("Enumerator: " + testString.ToString("NUM"));
            Console.WriteLine("Denominator: " + testString.ToString("DENUM"));
            Console.WriteLine("Format FLOAT: " + testString.ToString("FLOAT"));
            Console.WriteLine("Format INT: " + testString.ToString("INT"));
            Console.WriteLine("Format FULL: " + testString.ToString("FULL"));

            // Getting Fraction from String
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nGetting Fraction from string:");
            Console.ResetColor();

            string tryString = "Not a Parsable Fraction";
            string tryString1 = "5/3";
            string tryString2 = "    5/3";
            string tryString3 = "    5    /3";
            string tryString4 = "    5    /     3   ";
            string tryString5 = "234";
            string tryString6 = "      234";
            string tryString7 = "   234    ";
            string tryString8 = "65.225";
            string tryString9 = "     65.225";
            string tryString10 = "2,25     ";
            string tryString11 = "     2,25";
            string tryString12 = "      2,25      ";
            string tryString13 = "2.25";
            string tryString14 = "Last string for parsing";
            
            List<string> stringsForParse = new List<string>();
            
            stringsForParse.Add(tryString);
            stringsForParse.Add(tryString1);
            stringsForParse.Add(tryString2);
            stringsForParse.Add(tryString3);
            stringsForParse.Add(tryString4);
            stringsForParse.Add(tryString5);
            stringsForParse.Add(tryString6);
            stringsForParse.Add(tryString7);
            stringsForParse.Add(tryString8);
            stringsForParse.Add(tryString8);
            stringsForParse.Add(tryString9);
            stringsForParse.Add(tryString10);
            stringsForParse.Add(tryString11);
            stringsForParse.Add(tryString12);
            stringsForParse.Add(tryString13);
            stringsForParse.Add(tryString14);

            foreach (var parsingStr in stringsForParse)
            {
                Console.WriteLine("Parsing string: {0}", parsingStr);
                if (Fraction.TryParse(parsingStr, out Fraction fraction1))
                    Console.WriteLine("Result Parse: {0}\n", fraction1);
                else
                    Console.WriteLine("Can't Parse from -- {0}\n", parsingStr);
            }
        }
    }
}
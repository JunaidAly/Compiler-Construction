using System;
using System.Collections.Generic;

namespace FirstFollowSet
{
    class Program
    {
        static int limit, x = 0;
        static string[,] production = new string[10, 10];
        static char[] array = new char[10];

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    // To signify empty space.
                    production[i, j] = "-";
                }
            }

            int count;
            char option, ch;

            Console.WriteLine("\nEnter Total Number of Productions:\t");
            limit = Convert.ToInt32(Console.ReadLine());

            for (count = 0; count < limit; count++)
            {
                Console.WriteLine($"\nValue of Production Number {count + 1}:\t");
                string temp = Console.ReadLine();
                for (int i = 0; i < temp.Length; i++)
                {
                    production[count, i] = temp[i].ToString(); // Convert char to string
                }
            }

            do
            {
                x = 0;
                Console.WriteLine("\nEnter production Value to Find Follow:\t");
                ch = Console.ReadKey().KeyChar;
                find_follow(ch);
                Console.WriteLine($"\nFollow Value of {ch}:\t{{");
                for (count = 0; count < x; count++)
                {
                    Console.Write(array[count]);
                }
                Console.Write("}\n");
                Console.Write("To Continue, Press Y:\t");
                option = ch = Console.ReadKey().KeyChar;
            } while (option == 'y' || option == 'Y');

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(production[i, j]);
                }
                Console.Write("\n");
            }

            Console.ReadKey();
        }

        static void find_follow(char ch)
        {
            int i = 0, j;
            for (int k = 0; k < 10; k++)
            {
                if (production[k, 0] == ch.ToString())
                {
                    i = k;
                    break;
                }
            }

            int length = production[i, 1].Length;

            if (production[0, 0] == ch.ToString())
            {
                array_manipulation('$');
            }

            for (i = 0; i < limit; i++)
            {
                for (j = 2; j < length; j++)
                {
                    if (production[i, j] == ch.ToString())
                    {
                        if (production[i, j + 1] == "\0")
                        {
                            find_follow(Convert.ToChar(production[i, 0]));
                        }
                        if (production[i, j + 1] == "\0" && ch == Convert.ToChar(production[i, 0]))
                        {
                            find_follow(Convert.ToChar(production[i, 0]));
                        }
                    }
                }
            }
        }

        static void array_manipulation(char ch)
        {
            int count;
            for (count = 0; count <= x; count++)
            {
                if (array[count] == ch)
                {
                    return;
                }
            }
            array[x++] = ch;
        }
    }
}
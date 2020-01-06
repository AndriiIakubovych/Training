using System;
using System.Collections;

namespace BracesArrangementCheck
{
    class Program
    {
        public static bool Check(string text)
        {
            char[] openedBraces = { '(', '[', '{' };
            char[] closedBraces = { ')', ']', '}' };
            char deletedBrace;
            var stack = new Stack();
            foreach (var c in text)
            {
                if (Array.Exists(openedBraces, e => e == c))
                {
                    stack.Push(c);
                    continue;
                }
                if (!Array.Exists(closedBraces, e => e == c))
                    continue;
                if (stack.Count > 0)
                    deletedBrace = (char)stack.Pop();
                else
                    return false;
                if (Array.IndexOf(openedBraces, deletedBrace) != Array.IndexOf(closedBraces, c))
                    return false;
            }
            return stack.Count == 0;
        }

        static void Main(string[] args)
        {
            string text;
            Console.WriteLine("Введите текст:");
            text = Console.ReadLine();
            if (Check(text))
                Console.WriteLine("\nСкобки расставлены верно!");
            else
                Console.WriteLine("\nСкобки расставлены неверно!");
            Console.ReadKey();
        }
    }
}
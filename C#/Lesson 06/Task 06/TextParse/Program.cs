using System;
using System.Collections.Generic;

namespace TextParse
{
    class Program
    {
        static void Main(string[] args)
        {
            string text;
            char[] symbols = { '.', '!', '?', ',', '-', ':', ';', '(', ')', '"', '+', '*', '/', '=', '\\', '№', '|', '<', '>', '%', '@', '{', '}', '~', '^', '`' };
            string[] array;
            Dictionary<string, int> textWords = new Dictionary<string, int>();
            bool hasElement;
            int count;
            Console.Title = "Анализ текста";
            Console.WriteLine("Введите текст:");
            text = Console.ReadLine();
            text = text.ToLower();
            for (int i = 0; i < symbols.Length; i++)
                text = text.Replace(symbols[i], ' ');
            for (int i = 0; i < 10; i++)
                text = text.Replace(Convert.ToChar(i.ToString()), ' ');
            array = text.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < array.Length; i++)
            {
                hasElement = false;
                foreach (KeyValuePair<string, int> k in textWords)
                    if (k.Key == array[i])
                        hasElement = true;
                if (hasElement)
                    continue;
                else
                {
                    count = 1;
                    for (int j = i + 1; j < array.Length; j++)
                        if (array[j] == array[i])
                            count++;
                    textWords.Add(array[i][0].ToString().ToUpper() + array[i].Remove(0, 1), count);
                }
            }
            Console.WriteLine("\nСлова, встречающиеся в тексте:");
            foreach (KeyValuePair<string, int> k in textWords)
                if (Convert.ToInt32(k.Value.ToString()[k.Value.ToString().Length - 1].ToString()) > 1 && Convert.ToInt32(k.Value.ToString()[k.Value.ToString().Length - 1].ToString()) < 5)
                    Console.WriteLine(k.Key + " - " + k.Value + " раза");
                else
                    Console.WriteLine(k.Key + " - " + k.Value + " раз");
            Console.ReadKey();
        }
    }
}
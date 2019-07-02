using System;

namespace StringStatistics
{
    class Program
    {
        static void PrintStatistics(string s)
        {
            int lettersUpper = 0, lettersLower = 0, figures = 0, punctuationSymbols = 0, spaces = 0;
            Console.WriteLine("\nОбщее количество символов в строке: " + s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                for (char cUp = 'A', cLow = 'a'; cUp <= 'Z'; cUp++, cLow++)
                {
                    if (s[i] == cUp)
                        lettersUpper++;
                    if (s[i] == cLow)
                        lettersLower++;
                }
                for (char cUp = 'А', cLow = 'а'; cUp <= 'Я'; cUp++, cLow++)
                {
                    if (s[i] == cUp)
                        lettersUpper++;
                    if (s[i] == cLow)
                        lettersLower++;
                }
                if (s[i] == 'Ё')
                    lettersUpper++;
                if (s[i] == 'ё')
                    lettersLower++;
                for (char c = '0'; c <= '9'; c++)
                    if (s[i] == c)
                        figures++;
                if (s[i] == ',' || s[i] == ';' || s[i] == ':' || s[i] == '.' || s[i] == '?' || s[i] == '!' || s[i] == '-' || s[i] == '(' || s[i] == ')' || s[i] == '"' || s[i] == '\'')
                    punctuationSymbols++;
                if (s[i] == ' ')
                    spaces++;
            }
            Console.WriteLine("Количество букв в строке: " + (lettersUpper + lettersLower) + " (" + lettersUpper + " в верхнем регистре и " + lettersLower + " в нижнем регистре)");
            Console.WriteLine("Количество цифр в строке: " + figures);
            Console.WriteLine("Количество символов пунктуации: " + punctuationSymbols);
            Console.WriteLine("Количество пробельных символов: " + spaces);
        }

        static void Main(string[] args)
        {
            string s;
            Console.Title = "Статистика по строке";
            Console.Write("Введите строку: ");
            s = Console.ReadLine();
            PrintStatistics(s);
            Console.ReadKey();
        }
    }
}
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace TagsCleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath, text;
            string[] s;
            bool save = false;
            StreamReader sr;
            StreamWriter sw;
            Regex regex;
            Console.Title = "Очистка тегов в HTML";
            try
            {
                Console.WriteLine("Введите путь к html-файлу:");
                filePath = Console.ReadLine();
                if (Path.GetExtension(filePath).Equals(".html"))
                {
                    sr = new StreamReader(filePath);
                    text = sr.ReadToEnd();
                    sr.Dispose();
                    regex = new Regex(" *?<.+?>", RegexOptions.Multiline | RegexOptions.Compiled | RegexOptions.ExplicitCapture);
                    text = regex.Replace(text, "");
                    s = text.Split('\n');
                    Console.Write("\nСодержимое html-файла очищено от тегов!\n\nСохранить результат в текстовый файл (y/n)? ");
                    save = Console.ReadLine().ToLower().StartsWith("y");
                    if (save)
                    {
                        Console.WriteLine("Введите путь к файлу и его имя:");
                        filePath = Console.ReadLine();
                        sw = new StreamWriter(filePath);
                        for (int i = 0; i < s.Length; i++)
                            if (s[i].Length > 1)
                                sw.WriteLine(s[i]);
                            else
                                sw.Write(s[i]);
                        sw.Dispose();
                        Console.WriteLine("\nРезультат сохранён!");
                    }
                    else
                        Console.WriteLine("\nРабота завершена!");
                }
                else
                    Console.WriteLine("\nФайл должен иметь расширение *.html!");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("\nПапка не найдена!");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("\nФайл не найден!");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("\nОшибка доступа!");
            }
            Console.ReadKey();
        }
    }
}
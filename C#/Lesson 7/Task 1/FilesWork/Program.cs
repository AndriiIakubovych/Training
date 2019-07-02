using System;
using System.Collections.Generic;
using System.IO;

namespace FilesWork
{
    class Program
    {
        static void Delete(List<string> filesList)
        {
            foreach (string s in filesList)
                if (!s.Contains("."))
                {
                    if (Directory.Exists(s))
                        Directory.Delete(s, true);
                }
                else
                    if (File.Exists(s))
                    File.Delete(s);
        }

        static void Move(List<string> filesList, string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            foreach (string s in filesList)
                if (!s.Contains("."))
                {
                    if (Directory.Exists(s))
                    {
                        if (Directory.Exists(Path.Combine(path, Path.GetFileName(s))))
                            Directory.Delete(Path.Combine(path, Path.GetFileName(s)), true);
                        Directory.Move(s, Path.Combine(path, Path.GetFileName(s)));
                    }
                }
                else
                    if (File.Exists(s))
                    {
                        if (File.Exists(Path.Combine(path, Path.GetFileName(s))))
                            File.Delete(Path.Combine(path, Path.GetFileName(s)));
                        File.Move(s, Path.Combine(path, Path.GetFileName(s)));
                    }
        }

        static void Copy(List<string> filesList, string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            foreach (string s in filesList)
                if (!s.Contains("."))
                {
                    if (!Directory.Exists(Path.Combine(path, Path.GetFileName(s))))
                        Directory.CreateDirectory(Path.Combine(path, Path.GetFileName(s)));
                    CopyDirectory(s, Path.Combine(path, Path.GetFileName(s)));
                }
                else
                {
                    if (File.Exists(s))
                        File.Copy(s, Path.Combine(path, Path.GetFileName(s)), true);
                }
        }

        static void CopyDirectory(string sourcePath, string targetPath)
        {
            DirectoryInfo di = new DirectoryInfo(sourcePath);
            foreach (DirectoryInfo d in di.GetDirectories())
            {
                if (!Directory.Exists(Path.Combine(targetPath, d.Name)))
                    Directory.CreateDirectory(Path.Combine(targetPath, d.Name));
                CopyDirectory(d.FullName, Path.Combine(targetPath, d.Name));
            }
            foreach (string file in Directory.GetFiles(sourcePath))
                File.Copy(file, Path.Combine(targetPath, Path.GetFileName(file)), true);
        }

        static void Main(string[] args)
        {
            int searchType = 0, operationType;
            string text, pattern = "*", path, content, newContent;
            string[] numbers;
            bool choice, hasNumber = false;
            double minSize, maxSize;
            DateTime minDate, maxDate;
            DirectoryInfo mainDirectoryInfo;
            DirectoryInfo[] directories;
            FileInfo[] files;
            List<string> filesList = new List<string>();
            List<string> contentList = new List<string>();
            StreamReader sr;
            StreamWriter sw;
            Console.Title = "Работа с файлами";
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("М Е Н Ю");
                    Console.WriteLine("\n1 - Поиск файлов и папок по имени");
                    Console.WriteLine("2 - Поиск файлов по размеру");
                    Console.WriteLine("3 - Поиск файлов и папок по дате создания");
                    Console.WriteLine("4 - Поиск файлов и папок по дате доступа");
                    Console.WriteLine("5 - Поиск файлов и папок по дате модификации");
                    Console.WriteLine("6 - Поиск текстовых файлов по содержимому");
                    Console.WriteLine("7 - Выход");
                    Console.Write("\nВаш выбор: ");
                    searchType = Convert.ToInt32(Console.ReadLine());
                    switch (searchType)
                    {
                        case 1:
                            Console.Clear();
                            filesList.Clear();
                            try
                            {
                                Console.WriteLine("Введите путь, по которому следует искать файлы и папки:");
                                mainDirectoryInfo = new DirectoryInfo(Console.ReadLine());
                                Console.Write("Введите имя или часть имени искомого файла или папки: ");
                                text = Console.ReadLine();
                                if (text.Contains("*"))
                                    pattern = text;
                                Console.Write("Искать внутри подкаталогов (y/n)? ");
                                choice = Console.ReadLine().ToLower().StartsWith("y");
                                if (choice)
                                {
                                    directories = mainDirectoryInfo.GetDirectories(pattern, SearchOption.AllDirectories);
                                    files = mainDirectoryInfo.GetFiles(pattern, SearchOption.AllDirectories);
                                }
                                else
                                {
                                    directories = mainDirectoryInfo.GetDirectories(pattern);
                                    files = mainDirectoryInfo.GetFiles(pattern);
                                }
                                for (int i = 0; i < directories.Length; i++)
                                    if (directories[i].Name.ToLower().Contains(text.ToLower()) || pattern == text)
                                        filesList.Add(directories[i].FullName);
                                for (int i = 0; i < files.Length; i++)
                                    if (files[i].Name.ToLower().Contains(text.ToLower()) || pattern == text)
                                        filesList.Add(files[i].FullName);
                                if (filesList.Count > 0)
                                {
                                    Console.WriteLine("\nСписок найденных файлов и папок:");
                                    foreach (string s in filesList)
                                        Console.WriteLine(s);
                                }
                                else
                                {
                                    Console.WriteLine("\nНичего не найдено!");
                                    Console.ReadKey();
                                    break;
                                }
                                Console.Write("\nВыберите действие с найденным списком (1 - удаление, 2 - перемещение,\n3 - копирование, 4 - выход в главное меню): ");
                                operationType = Convert.ToInt32(Console.ReadLine());
                                switch (operationType)
                                {
                                    case 1:
                                        Delete(filesList);
                                        Console.WriteLine("\nФайлы и папки удалены!");
                                        Console.ReadKey();
                                        break;
                                    case 2:
                                        Console.WriteLine("\nВведите путь, куда следует переместить файлы и папки:");
                                        path = Console.ReadLine();
                                        Move(filesList, path);
                                        Console.WriteLine("\nФайлы и папки перемещены!");
                                        Console.ReadKey();
                                        break;
                                    case 3:
                                        Console.WriteLine("\nВведите путь, куда следует скопировать файлы и папки:");
                                        path = Console.ReadLine();
                                        Copy(filesList, path);
                                        Console.WriteLine("\nФайлы и папки скопированы!");
                                        Console.ReadKey();
                                        break;
                                    case 4:
                                        break;
                                    default:
                                        Console.WriteLine("\nНет такого действия!");
                                        Console.ReadKey();
                                        break;
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("\nОшибка при вводе!");
                                Console.ReadKey();
                            }
                            catch (DirectoryNotFoundException)
                            {
                                Console.WriteLine("\nПуть указан неверно!");
                                Console.ReadKey();
                            }
                            catch (UnauthorizedAccessException)
                            {
                                Console.WriteLine("\nОшибка доступа!");
                                Console.ReadKey();
                            }
                            break;
                        case 2:
                            Console.Clear();
                            filesList.Clear();
                            try
                            {
                                Console.WriteLine("Введите путь, по которому следует искать файлы:");
                                mainDirectoryInfo = new DirectoryInfo(Console.ReadLine());
                                Console.Write("Введите минимальный размер файлов: ");
                                minSize = Convert.ToDouble(Console.ReadLine());
                                Console.Write("Введите максимальный размер файлов: ");
                                maxSize = Convert.ToDouble(Console.ReadLine());
                                if (maxSize < minSize || minSize < 0 || maxSize < 0)
                                {
                                    Console.WriteLine("\nРазмеры введены неверно!");
                                    Console.ReadKey();
                                    break;
                                }
                                pattern = "*";
                                Console.Write("Искать внутри подкаталогов (y/n)? ");
                                choice = Console.ReadLine().ToLower().StartsWith("y");
                                if (choice)
                                    files = mainDirectoryInfo.GetFiles(pattern, SearchOption.AllDirectories);
                                else
                                    files = mainDirectoryInfo.GetFiles(pattern);
                                for (int i = 0; i < files.Length; i++)
                                    if (files[i].Length >= minSize && files[i].Length <= maxSize)
                                        filesList.Add(files[i].FullName);
                                if (filesList.Count > 0)
                                {
                                    Console.WriteLine("\nСписок найденных файлов:");
                                    foreach (string s in filesList)
                                        Console.WriteLine(s);
                                }
                                else
                                {
                                    Console.WriteLine("\nНичего не найдено!");
                                    Console.ReadKey();
                                    break;
                                }
                                Console.Write("\nВыберите действие с найденным списком (1 - удаление, 2 - перемещение,\n3 - копирование, 4 - выход в главное меню): ");
                                operationType = Convert.ToInt32(Console.ReadLine());
                                switch (operationType)
                                {
                                    case 1:
                                        Delete(filesList);
                                        Console.WriteLine("\nФайлы удалены!");
                                        Console.ReadKey();
                                        break;
                                    case 2:
                                        Console.WriteLine("\nВведите путь, куда следует переместить файлы:");
                                        path = Console.ReadLine();
                                        Move(filesList, path);
                                        Console.WriteLine("\nФайлы перемещены!");
                                        Console.ReadKey();
                                        break;
                                    case 3:
                                        Console.WriteLine("\nВведите путь, куда следует скопировать файлы:");
                                        path = Console.ReadLine();
                                        Copy(filesList, path);
                                        Console.WriteLine("\nФайлы скопированы!");
                                        Console.ReadKey();
                                        break;
                                    case 4:
                                        break;
                                    default:
                                        Console.WriteLine("\nНет такого действия!");
                                        Console.ReadKey();
                                        break;
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("\nОшибка при вводе!");
                                Console.ReadKey();
                            }
                            catch (DirectoryNotFoundException)
                            {
                                Console.WriteLine("\nПуть указан неверно!");
                                Console.ReadKey();
                            }
                            catch (UnauthorizedAccessException)
                            {
                                Console.WriteLine("\nОшибка доступа!");
                                Console.ReadKey();
                            }
                            break;
                        case 3:
                            Console.Clear();
                            filesList.Clear();
                            try
                            {
                                Console.WriteLine("Введите путь, по которому следует искать файл и папки:");
                                mainDirectoryInfo = new DirectoryInfo(Console.ReadLine());
                                Console.Write("Введите дату начала периода: ");
                                minDate = Convert.ToDateTime(Console.ReadLine());
                                Console.Write("Введите дату окончания периода: ");
                                maxDate = Convert.ToDateTime(Console.ReadLine());
                                if (maxDate < minDate)
                                {
                                    Console.WriteLine("\nДаты введены неверно!");
                                    Console.ReadKey();
                                    break;
                                }
                                pattern = "*";
                                Console.Write("Искать внутри подкаталогов (y/n)? ");
                                choice = Console.ReadLine().ToLower().StartsWith("y");
                                if (choice)
                                {
                                    directories = mainDirectoryInfo.GetDirectories(pattern, SearchOption.AllDirectories);
                                    files = mainDirectoryInfo.GetFiles(pattern, SearchOption.AllDirectories);
                                }
                                else
                                {
                                    directories = mainDirectoryInfo.GetDirectories(pattern);
                                    files = mainDirectoryInfo.GetFiles(pattern);
                                }
                                for (int i = 0; i < directories.Length; i++)
                                    if (directories[i].CreationTime >= minDate && directories[i].CreationTime <= maxDate)
                                        filesList.Add(directories[i].FullName);
                                for (int i = 0; i < files.Length; i++)
                                    if (files[i].CreationTime >= minDate && files[i].CreationTime <= maxDate)
                                        filesList.Add(files[i].FullName);
                                if (filesList.Count > 0)
                                {
                                    Console.WriteLine("\nСписок найденных файлов и папок:");
                                    foreach (string s in filesList)
                                        Console.WriteLine(s);
                                }
                                else
                                {
                                    Console.WriteLine("\nНичего не найдено!");
                                    Console.ReadKey();
                                    break;
                                }
                                Console.Write("\nВыберите действие с найденным списком (1 - удаление, 2 - перемещение,\n3 - копирование, 4 - выход в главное меню): ");
                                operationType = Convert.ToInt32(Console.ReadLine());
                                switch (operationType)
                                {
                                    case 1:
                                        Delete(filesList);
                                        Console.WriteLine("\nФайлы и папки удалены!");
                                        Console.ReadKey();
                                        break;
                                    case 2:
                                        Console.WriteLine("\nВведите путь, куда следует переместить файлы и папки:");
                                        path = Console.ReadLine();
                                        Move(filesList, path);
                                        Console.WriteLine("\nФайлы и папки перемещены!");
                                        Console.ReadKey();
                                        break;
                                    case 3:
                                        Console.WriteLine("\nВведите путь, куда следует скопировать файлы и папки:");
                                        path = Console.ReadLine();
                                        Copy(filesList, path);
                                        Console.WriteLine("\nФайлы и папки скопированы!");
                                        Console.ReadKey();
                                        break;
                                    case 4:
                                        break;
                                    default:
                                        Console.WriteLine("\nНет такого действия!");
                                        Console.ReadKey();
                                        break;
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("\nОшибка при вводе!");
                                Console.ReadKey();
                            }
                            catch (DirectoryNotFoundException)
                            {
                                Console.WriteLine("\nПуть указан неверно!");
                                Console.ReadKey();
                            }
                            catch (UnauthorizedAccessException)
                            {
                                Console.WriteLine("\nОшибка доступа!");
                                Console.ReadKey();
                            }
                            break;
                        case 4:
                            Console.Clear();
                            filesList.Clear();
                            try
                            {
                                Console.WriteLine("Введите путь, по которому следует искать файл и папки:");
                                mainDirectoryInfo = new DirectoryInfo(Console.ReadLine());
                                Console.Write("Введите дату начала периода: ");
                                minDate = Convert.ToDateTime(Console.ReadLine());
                                Console.Write("Введите дату окончания периода: ");
                                maxDate = Convert.ToDateTime(Console.ReadLine());
                                if (maxDate < minDate)
                                {
                                    Console.WriteLine("\nДаты введены неверно!");
                                    Console.ReadKey();
                                    break;
                                }
                                pattern = "*";
                                Console.Write("Искать внутри подкаталогов (y/n)? ");
                                choice = Console.ReadLine().ToLower().StartsWith("y");
                                if (choice)
                                {
                                    directories = mainDirectoryInfo.GetDirectories(pattern, SearchOption.AllDirectories);
                                    files = mainDirectoryInfo.GetFiles(pattern, SearchOption.AllDirectories);
                                }
                                else
                                {
                                    directories = mainDirectoryInfo.GetDirectories(pattern);
                                    files = mainDirectoryInfo.GetFiles(pattern);
                                }
                                for (int i = 0; i < directories.Length; i++)
                                    if (directories[i].LastAccessTime >= minDate && directories[i].LastAccessTime <= maxDate)
                                        filesList.Add(directories[i].FullName);
                                for (int i = 0; i < files.Length; i++)
                                    if (files[i].LastAccessTime >= minDate && files[i].LastAccessTime <= maxDate)
                                        filesList.Add(files[i].FullName);
                                if (filesList.Count > 0)
                                {
                                    Console.WriteLine("\nСписок найденных файлов и папок:");
                                    foreach (string s in filesList)
                                        Console.WriteLine(s);
                                }
                                else
                                {
                                    Console.WriteLine("\nНичего не найдено!");
                                    Console.ReadKey();
                                    break;
                                }
                                Console.Write("\nВыберите действие с найденным списком (1 - удаление, 2 - перемещение,\n3 - копирование, 4 - выход в главное меню): ");
                                operationType = Convert.ToInt32(Console.ReadLine());
                                switch (operationType)
                                {
                                    case 1:
                                        Delete(filesList);
                                        Console.WriteLine("\nФайлы и папки удалены!");
                                        Console.ReadKey();
                                        break;
                                    case 2:
                                        Console.WriteLine("\nВведите путь, куда следует переместить файлы и папки:");
                                        path = Console.ReadLine();
                                        Move(filesList, path);
                                        Console.WriteLine("\nФайлы и папки перемещены!");
                                        Console.ReadKey();
                                        break;
                                    case 3:
                                        Console.WriteLine("\nВведите путь, куда следует скопировать файлы и папки:");
                                        path = Console.ReadLine();
                                        Copy(filesList, path);
                                        Console.WriteLine("\nФайлы и папки скопированы!");
                                        Console.ReadKey();
                                        break;
                                    case 4:
                                        break;
                                    default:
                                        Console.WriteLine("\nНет такого действия!");
                                        Console.ReadKey();
                                        break;
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("\nОшибка при вводе!");
                                Console.ReadKey();
                            }
                            catch (DirectoryNotFoundException)
                            {
                                Console.WriteLine("\nПуть указан неверно!");
                                Console.ReadKey();
                            }
                            catch (UnauthorizedAccessException)
                            {
                                Console.WriteLine("\nОшибка доступа!");
                                Console.ReadKey();
                            }
                            break;
                        case 5:
                            Console.Clear();
                            filesList.Clear();
                            try
                            {
                                Console.WriteLine("Введите путь, по которому следует искать файл и папки:");
                                mainDirectoryInfo = new DirectoryInfo(Console.ReadLine());
                                Console.Write("Введите дату начала периода: ");
                                minDate = Convert.ToDateTime(Console.ReadLine());
                                Console.Write("Введите дату окончания периода: ");
                                maxDate = Convert.ToDateTime(Console.ReadLine());
                                if (maxDate < minDate)
                                {
                                    Console.WriteLine("\nДаты введены неверно!");
                                    Console.ReadKey();
                                    break;
                                }
                                pattern = "*";
                                Console.Write("Искать внутри подкаталогов (y/n)? ");
                                choice = Console.ReadLine().ToLower().StartsWith("y");
                                if (choice)
                                {
                                    directories = mainDirectoryInfo.GetDirectories(pattern, SearchOption.AllDirectories);
                                    files = mainDirectoryInfo.GetFiles(pattern, SearchOption.AllDirectories);
                                }
                                else
                                {
                                    directories = mainDirectoryInfo.GetDirectories(pattern);
                                    files = mainDirectoryInfo.GetFiles(pattern);
                                }
                                for (int i = 0; i < directories.Length; i++)
                                    if (directories[i].LastWriteTime >= minDate && directories[i].LastWriteTime <= maxDate)
                                        filesList.Add(directories[i].FullName);
                                for (int i = 0; i < files.Length; i++)
                                    if (files[i].LastWriteTime >= minDate && files[i].LastWriteTime <= maxDate)
                                        filesList.Add(files[i].FullName);
                                if (filesList.Count > 0)
                                {
                                    Console.WriteLine("\nСписок найденных файлов и папок:");
                                    foreach (string s in filesList)
                                        Console.WriteLine(s);
                                }
                                else
                                {
                                    Console.WriteLine("\nНичего не найдено!");
                                    Console.ReadKey();
                                    break;
                                }
                                Console.Write("\nВыберите действие с найденным списком (1 - удаление, 2 - перемещение,\n3 - копирование, 4 - выход в главное меню): ");
                                operationType = Convert.ToInt32(Console.ReadLine());
                                switch (operationType)
                                {
                                    case 1:
                                        Delete(filesList);
                                        Console.WriteLine("\nФайлы и папки удалены!");
                                        Console.ReadKey();
                                        break;
                                    case 2:
                                        Console.WriteLine("\nВведите путь, куда следует переместить файлы и папки:");
                                        path = Console.ReadLine();
                                        Move(filesList, path);
                                        Console.WriteLine("\nФайлы и папки перемещены!");
                                        Console.ReadKey();
                                        break;
                                    case 3:
                                        Console.WriteLine("\nВведите путь, куда следует скопировать файлы и папки:");
                                        path = Console.ReadLine();
                                        Copy(filesList, path);
                                        Console.WriteLine("\nФайлы и папки скопированы!");
                                        Console.ReadKey();
                                        break;
                                    case 4:
                                        break;
                                    default:
                                        Console.WriteLine("\nНет такого действия!");
                                        Console.ReadKey();
                                        break;
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("\nОшибка при вводе!");
                                Console.ReadKey();
                            }
                            catch (DirectoryNotFoundException)
                            {
                                Console.WriteLine("\nПуть указан неверно!");
                                Console.ReadKey();
                            }
                            catch (UnauthorizedAccessException)
                            {
                                Console.WriteLine("\nОшибка доступа!");
                                Console.ReadKey();
                            }
                            break;
                        case 6:
                            Console.Clear();
                            filesList.Clear();
                            hasNumber = false;
                            Console.WriteLine("Введите путь, по которому следует искать файлы:");
                            mainDirectoryInfo = new DirectoryInfo(Console.ReadLine());
                            Console.Write("Введите часть содержимого, по которому следует искать файлы: ");
                            text = Console.ReadLine();
                            Console.Write("Искать внутри подкаталогов (y/n)? ");
                            choice = Console.ReadLine().ToLower().StartsWith("y");
                            pattern = "*.txt";
                            if (choice)
                                files = mainDirectoryInfo.GetFiles(pattern, SearchOption.AllDirectories);
                            else
                                files = mainDirectoryInfo.GetFiles(pattern);
                            for (int i = 0; i < files.Length; i++)
                            {
                                sr = new StreamReader(files[i].FullName);
                                content = sr.ReadToEnd();
                                sr.Dispose();
                                if (content.Contains(text))
                                {
                                    filesList.Add(files[i].FullName);
                                    contentList.Add(content);
                                }
                            }
                            if (filesList.Count > 0)
                            {
                                Console.WriteLine("\nСписок найденных файлов:");
                                for (int i = 0; i < filesList.Count; i++)
                                    Console.WriteLine((i + 1) + ") " + filesList[i]);
                            }
                            else
                            {
                                Console.WriteLine("\nНичего не найдено!");
                                Console.ReadKey();
                                break;
                            }
                            Console.Write("\nЗаменить данную подстроку на другую (y/n)? ");
                            choice = Console.ReadLine().ToLower().StartsWith("y");
                            if (choice)
                            {
                                Console.Write("Введите новую подстроку: ");
                                newContent = Console.ReadLine();
                                Console.WriteLine("Выберите текстовые файлы из найденного списка (введите их номера через пробел):");
                                numbers = Console.ReadLine().Split(' ');
                                for (int i = 0; i < filesList.Count; i++)
                                    for (int j = 0; j < numbers.Length; j++)
                                        if (numbers[j] == (i + 1).ToString())
                                        {
                                            hasNumber = true;
                                            sw = new StreamWriter(files[i].FullName);
                                            sw.Write(contentList[i].Replace(text, newContent));
                                            sw.Dispose();
                                            break;
                                        }
                                if (hasNumber)
                                    Console.WriteLine("\nФайлы изменены!");
                                else
                                    Console.WriteLine("\nФайлы не изменены!");
                                Console.ReadKey();
                            }
                            break;
                        case 7:
                            Console.Clear();
                            Console.WriteLine("Работа завершена!");
                            break;
                        default:
                            Console.WriteLine("\nНеверный выбор!");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nОшибка при вводе!");
                    Console.ReadKey();
                }
            }
            while (searchType != 7);
            Console.ReadKey();
        }
    }
}
using System;

namespace StackImitation
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();
            bool continueEnter;
            int size, n, index;
            object requiredElement;
            object[] array;
            Console.Title = "Имитация работы стека";
            Console.Write("Добавить новый элемент в стек (y/n)? ");
            continueEnter = Console.ReadLine().ToLower().StartsWith("y");
            while (continueEnter)
            {
                Console.Write("Введите значение нового элемента стека: ");
                stack.Push(Console.ReadLine());
                Console.Write("Добавить новый элемент в стек (y/n)? ");
                continueEnter = Console.ReadLine().ToLower().StartsWith("y");
            }
            try
            {
                if (stack.Size > 0)
                {
                    size = stack.Size;
                    Console.WriteLine("\nКоличество элементов стека: " + size);
                }
                else
                    throw new InvalidOperationException();
                Console.WriteLine("\nСодержимое стека:");
                foreach (object element in stack)
                    Console.WriteLine(element);
                Console.WriteLine("\nЗначение элемента, который был помещён в стек последним: " + stack.Peek());
                continueEnter = true;
                Console.WriteLine();
                while (continueEnter)
                {
                    if (stack.Size == 0)
                        throw new InvalidOperationException();
                    Console.Write("Удалить элемент из стека (y/n)? ");
                    continueEnter = Console.ReadLine().ToLower().StartsWith("y");
                    if (continueEnter)
                        stack.Pop();
                }
                if (stack.Size < size)
                {
                    Console.WriteLine("\nСодержимое стека после извлечения элементов:");
                    foreach (object element in stack)
                        Console.WriteLine(element);
                }
                Console.Write("\nВведите значение искомого элемента стека: ");
                requiredElement = Console.ReadLine();
                if (stack.Contains(requiredElement))
                    Console.WriteLine("Данный элемент присутствует в стеке!");
                else
                    Console.WriteLine("Элемент отсутствует!");
                Console.Write("\nВведите размерность массива: ");
                n = Convert.ToInt32(Console.ReadLine());
                if (n > 0)
                {
                    array = new object[n];
                    Console.WriteLine();
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write("Введите элемент массива с индексом [" + i + "]: ");
                        array[i] = Console.ReadLine();
                    }
                    Console.WriteLine("\nВы ввели массив:");
                    for (int i = 0; i < n; i++)
                        Console.Write(array[i] + " ");
                    Console.Write("\n\nУкажите позицию, с которой следует начать копирование: ");
                    index = Convert.ToInt32(Console.ReadLine());
                    stack.CopyTo(array, index);
                    Console.WriteLine("\nМассив после копирования содержимого стека в него:");
                    for (int i = 0; i < n; i++)
                        Console.Write(array[i] + " ");
                    stack.Clear();
                    if (stack.Size == 0)
                        Console.WriteLine("\n\nСтек очищен! Работа завершена!");
                }
                else
                    Console.WriteLine("\nРазмерность массива введена неверно!");
            }
            catch (FormatException)
            {
                Console.WriteLine("\nОшибка ввода!");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("\nСтек пуст!");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("\nКопирование элементов невозможно!");
            }
            Console.ReadKey();
        }
    }
}
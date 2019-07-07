using System;

namespace LibraryTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            Reader reader = new Reader();
            Console.Title = "Модель приложения \"Библиотека\"";
            reader.SeeBooks(library);
            Console.ReadKey();
        }
    }
}
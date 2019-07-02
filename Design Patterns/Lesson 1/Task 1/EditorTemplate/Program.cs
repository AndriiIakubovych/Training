using System;

namespace EditorTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            EditorFactory factory = new EditorFactory();
            Console.Title = "Универсальный каркас многодокументного редактора";
            var textEditor = factory.CreateEditor("Text");
            var graphicEditor = factory.CreateEditor("Graphic");
            Console.ReadKey();
        }
    }
}
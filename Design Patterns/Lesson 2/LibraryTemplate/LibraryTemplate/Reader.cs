using System;

namespace LibraryTemplate
{
    class Reader
    {
        public void SeeBooks(Library library)
        {
            IBookIterator iterator = library.CreateNumerator();
            Book book;
            while (iterator.HasNext())
            {
                book = iterator.Next();
                Console.WriteLine(book.Name);
            }
        }
    }
}
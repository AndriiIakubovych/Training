namespace LibraryTemplate
{
    class Library : IBookNumerable
    {
        private Book[] books;

        public Library()
        {
            books = new Book[] { new Book { Name = "Война и мир" }, new Book { Name = "Отцы и дети" }, new Book { Name = "Вишнёвый сад" } };
        }

        public IBookIterator CreateNumerator()
        {
            return new LibraryNumerator(this);
        }

        public int Count
        {
            get { return books.Length; }
        }

        public Book this[int index]
        {
            get { return books[index]; }
        }
    }
}
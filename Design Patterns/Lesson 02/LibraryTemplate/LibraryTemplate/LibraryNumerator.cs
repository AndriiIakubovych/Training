namespace LibraryTemplate
{
    class LibraryNumerator : IBookIterator
    {
        IBookNumerable aggregate;
        int index = 0;

        public LibraryNumerator(IBookNumerable aggregate)
        {
            this.aggregate = aggregate;
        }

        public bool HasNext()
        {
            return index < aggregate.Count;
        }

        public Book Next()
        {
            return aggregate[index++];
        }
    }
}
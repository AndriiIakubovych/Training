namespace LibraryTemplate
{
    interface IBookIterator
    {
        bool HasNext();
        Book Next();
    }
}
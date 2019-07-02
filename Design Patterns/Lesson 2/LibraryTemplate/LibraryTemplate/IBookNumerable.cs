﻿namespace LibraryTemplate
{
    interface IBookNumerable
    {
        IBookIterator CreateNumerator();

        int Count { get; }
        Book this[int index] { get; }
    }
}
using System;
using System.Collections;

namespace StackImitation
{
    class Stack
    {
        private object[] array;
        private int size;

        public Stack()
        {
            array = new object[0];
            size = 0;
        }

        public Stack(int initialCapacity)
        {
            array = new object[initialCapacity];
            size = 0;
        }

        public void Push(object obj)
        {
            Array.Resize(ref array, ++size);
            for (int i = size - 1; i >= 1; i--)
                array[i] = array[i - 1];
            array[0] = obj;
        }

        public object Pop()
        {
            object obj = null;
            if (size <= 0)
                throw new InvalidOperationException();
            obj = array[0];
            for (int i = 0; i < size - 1; i++)
                array[i] = array[i + 1];
            Array.Resize(ref array, --size);
            return obj;
        }

        public object Peek()
        {
            object obj = null;
            if (size <= 0)
                throw new InvalidOperationException();
            obj = array[0];
            return obj;
        }

        public bool Contains(object obj)
        {
            for (int i = 0; i < size; i++)
                if (array[i].Equals(obj))
                    return true;
            return false;
        }

        public void Clear()
        {
            size = 0;
            Array.Resize(ref array, size);
        }

        public void CopyTo(Array array, int index)
        {
            if (array.Rank != 1)
                throw new ArgumentException();
            for (int i = 0; i < size; i++)
                array.SetValue(this.array[i], i + index);
        }

        public virtual object Clone()
        {
            Stack stack = new Stack(size);
            stack.size = size;
            Array.Copy(array, 0, stack.array, 0, size);
            return stack;
        }

        public virtual object[] ToArray()
        {
            return array;
        }

        public int Size
        {
            get { return array.Length; }
        }

        public IEnumerator GetEnumerator()
        {
            return array.GetEnumerator();
        }
    }
}
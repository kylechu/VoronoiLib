using System;
using System.Collections.Generic;
using System.Text;

namespace VoronoiLib.Structures
{
    public class PoolLinkedListElement<T>
    {
        public PoolLinkedListElement<T> Previous { get; set; }
        public PoolLinkedListElement<T> Next { get; set; }
        public T Value { get; set; }

        public void Initialize(T value)
        {
            Previous = null;
            Next = null;
            Value = value;
        }
    }

    public class PoolLinkedList<T>
    {
        public PoolLinkedListElement<T> First { get; private set; }
        public PoolLinkedListElement<T> Last { get; private set; }

        public int Count { get; private set; }

        public void Clear(Action<T> disposeValue = null)
        {
            var current = First;
            while (current != null)
            {
                RecycleElement(current);
                disposeValue?.Invoke(current.Value);
                current = current.Next;
            }
            First = null;
            Last = null;
            Count = 0;
        }

        private PoolLinkedListElement<T> GetElement(T value)
        {
            var element = ObjectPool<PoolLinkedListElement<T>>.Get();
            element.Initialize(value);
            return element;
        }

        private void RecycleElement(PoolLinkedListElement<T> element)
        {
            ObjectPool<PoolLinkedListElement<T>>.Recycle(element);
        }

        public void AddFirst(T value)
        {
            var element = GetElement(value);
            if (Count > 0)
            {
                First.Previous = element;
                element.Next = First;
            }
            else
            {
                Last = element;
            }
            First = element;
            Count += 1;
        }

        public T RemoveFirst()
        {
            T toReturn = default(T);
            if (Count > 0)
            {
                var toRemove = First;
                First = First.Next;
                if (Count == 1)
                {
                    Last = null;
                }
                else
                {
                    First.Previous = null;
                }
                toReturn = toRemove.Value;
                RecycleElement(toRemove);
                Count -= 1;
            }
            return toReturn;
        }

        public void AddLast(T value)
        {
            var element = GetElement(value);
            if (Count > 0)
            {
                Last.Next = element;
                element.Previous = Last;
            }
            else
            {
                First = element;
            }
            Last = element;
            Count += 1;
        }

        public T RemoveLast(T value)
        {
            T toReturn = default(T);
            if (Count > 0)
            {
                var toRemove = Last;
                Last = Last.Previous;
                if (Count == 1)
                {
                    First = null;
                }
                else
                {
                    Last.Next = null;
                }
                toReturn = toRemove.Value;
                RecycleElement(toRemove);
                Count -= 1;
            }
            return toReturn;
        }

        public T Remove(PoolLinkedListElement<T> element)
        {
            var value = element.Value;
            if (element.Previous != null)
            {
                element.Previous.Next = element.Next;
            }
            if (element.Next != null)
            {
                element.Next.Previous = element.Previous;
            }
            if (First == element)
            {
                First = element.Next;
            }
            if (Last == element)
            {
                Last = element.Previous;
            }
            RecycleElement(element);
            Count -= 1;
            return value;
        }
    }
}

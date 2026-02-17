using System;

namespace SmartDataManager.Data
{
    public class MyLinkedList<T>// generische verkettete Liste, die verschiedene Operationen wie Hinzufügen, Entfernen, Suchen und Sortieren von Elementen unterstützt
    {
        private Node<T>? _head;
        private Node<T>? _tail;

        public int Count { get; private set; }

        public void AddLast(T item)
        {
            var node = new Node<T>(item);

            if (_head == null)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                _tail!.Next = node;
                _tail = node;
            }

            Count++;
        }

        public bool RemoveFirst(out T? removedItem)
        {
            if (_head == null)
            {
                removedItem = default;
                return false;
            }

            removedItem = _head.Value;
            _head = _head.Next;

            if (_head == null)
                _tail = null;

            Count--;
            return true;
        }

        public bool TryFind(Func<T, bool> predicate, out T? found)
        {
            var current = _head;

            while (current != null)
            {
                if (predicate(current.Value))
                {
                    found = current.Value;
                    return true;
                }

                current = current.Next;
            }

            found = default;
            return false;
        }

        public void ForEach(Action<T> action)
        {
            var current = _head;

            while (current != null)
            {
                action(current.Value);
                current = current.Next;
            }
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        public bool RemoveFirstMatch(Func<T, bool> predicate, out T? removedItem)
        {
            removedItem = default;

            if (_head == null) return false;

            if (predicate(_head.Value))
            {
                removedItem = _head.Value;
                _head = _head.Next;

                if (_head == null)
                    _tail = null;

                Count--;
                return true;
            }

            var prev = _head;
            var current = _head.Next;

            while (current != null)
            {
                if (predicate(current.Value))
                {
                    removedItem = current.Value;
                    prev.Next = current.Next;

                    if (current == _tail)
                        _tail = prev;

                    Count--;
                    return true;
                }

                prev = current;
                current = current.Next;
            }

            return false;
        }


        public void Sort(Comparison<T> comparison)
        {
            if (_head == null || _head.Next == null)
                return;

            bool swapped;
            do
            {
                swapped = false;
                var current = _head;

                while (current.Next != null)
                {
                    if (comparison(current.Value, current.Next.Value) > 0)
                    {
                        T temp = current.Value;
                        current.Value = current.Next.Value;
                        current.Next.Value = temp;

                        swapped = true;
                    }

                    current = current.Next;
                }
            } while (swapped);
        }

    }



}

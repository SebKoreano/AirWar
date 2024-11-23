using System.Collections;

namespace AirWar
{
    // Nodo para la lista enlazada
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T>? Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    // Lista enlazada simple
    public class LinkedList<T> : IEnumerable<T>
    {
        private Node<T>? head;
        public int Count { get; private set; }

        public LinkedList()
        {
            head = null;
            Count = 0;
        }

        public void Add(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            Count++;
        }

        public bool Remove(T data)
        {
            if (head == null)
            {
                return false;
            }

            if (head.Data != null && head.Data.Equals(data))
            {
                head = head.Next;
                Count--;
                return true;
            }

            Node<T>? current = head;
            while (current.Next != null)
            {
                if (current.Next.Data != null && current.Next.Data.Equals(data))
                {
                    current.Next = current.Next.Next;
                    Count--;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public bool Contains(T data)
        {
            Node<T>? current = head;
            while (current != null)
            {
                if (current.Data != null && current.Data.Equals(data))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public int IndexOf(T data)
        {
            Node<T>? current = head;
            int index = 0;
            while (current != null)
            {
                if (current.Data != null && current.Data.Equals(data))
                {
                    return index;
                }
                current = current.Next;
                index++;
            }
            return -1;
        }

        public T this[int index]
        {
            get
            {
                Node<T>? current = head;
                int currentIndex = 0;
                while (current != null)
                {
                    if (currentIndex == index)
                    {
                        return current.Data;
                    }
                    current = current.Next;
                    currentIndex++;
                }
                throw new IndexOutOfRangeException("Index out of range.");
            }
            set
            {
                Node<T>? current = head;
                int currentIndex = 0;
                while (current != null)
                {
                    if (currentIndex == index)
                    {
                        current.Data = value;
                        return;
                    }
                    current = current.Next;
                    currentIndex++;
                }
                throw new IndexOutOfRangeException("Index out of range.");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

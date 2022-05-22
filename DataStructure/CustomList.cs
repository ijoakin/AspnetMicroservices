using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class CustomList<T>    
    {
        public Node<T> root { get; set; }

        public Node<T> current { get; set; }

        public Node<T> previus;

        public void Start()
        {
            current = root;
            previus = root;
        }

        public bool isEmpty()
        {
            return current
        }

        public void Add(T value)
        {
            var node = new Node<T>(value);

            if (root == null) {
                root = node;
            }
            else {
                this.Start();
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = node;
            }
        }

        public void deleteAt(int pos)
        {
            int i = 0;

            if (this.isEmpty())
                return;

            this.Start();
            if (pos == 0)
            {
                root = current.Next;
                current = current.Next;
            }
            else
            {
                do
                {
                    if (i == pos - 1) {
                        previus.Next = current.Next;
                        break;
                    } 
                    previus = current;
                    current = current.Next;
                }
                while (current.Next != null);
            }
        }

        public T GetValue()
        {
            if (current != null) {
                return current.value;
            }
            return root.value;
        }

        public Node<T> ElementAt(int pos)
        {
            this.Start();

            int i = 0;
            var defaultVal = default(T);

            do
            {
                if (i == pos -1)
                    return current;

                current = current.Next;
            }
            while (current.Next != null);
            return new Node<T>(defaultVal);
        }

        public T ValueAt(int pos)
        {
            this.Start();

            int i = 0;
            var defaultVal = default(T);

            do
            {
                if (i == pos - 1)
                    return current.value;

                current = current.Next;
            }
            while (current.Next != null);
            return defaultVal;
        }


        public T FindElement(T value)
        {
            var defaultVal = default(T);
            this.Start();
            do
            {
                if (current.value.Equals(value))
                {

                    return current.value;
                }

                current = current.Next;
            }
            while (current.Next != null);
            return defaultVal;
        }

        public bool Next()
        {
            if (current.Next == null)
                return false;

            current = current.Next;
            return true;
        }
    }
}

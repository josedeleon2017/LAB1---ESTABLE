using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinealStructures.Structures
{
    class Node<T>
    {
        public Node<T> Next { get; set; }
        public Node<T> Prev { get; set; }
        public T Value { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null;
            Prev = null;
        }
    }
}

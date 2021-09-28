using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Graph
{
    class Vertex<T>
    {
        public T storage;
        public Vertex(T data)
        {
            storage = data;
        }
    }
}

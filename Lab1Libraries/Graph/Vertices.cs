using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Libraries.Graph
{
    public class Vertices<TData>
    {
        private readonly List<Vertex<TData>> storage;

        public Vertices()
        {
            storage = new List<Vertex<TData>>();
        }

        public void Add(TData data)
        {
            storage.Add(new Vertex<TData>(data));
        }

        public void Remove(int index)
        {
            storage.RemoveAt(index);
        }

        public int Count()
        {
            return storage.Count;
        }
    }
}

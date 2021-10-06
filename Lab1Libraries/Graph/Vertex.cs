namespace Lab1Libraries.Graph
{
    internal class Vertex<T>
    {
        public T storage;
        public Vertex(T data)
        {
            storage = data;
        }

        public T Get()
        {
            return storage;
        }

        public void Set(T data)
        {
            storage = data;
        }
    }
}

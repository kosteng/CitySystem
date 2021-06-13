using System.Collections.Generic;

namespace Extensions.Pool
{
    public class Pool<T>
    {
        private readonly IFactory<T> _factory;
        private readonly Queue<T> PoolQueue = new Queue<T>();

        public Pool(IFactory<T> factory)
        {
            _factory = factory;
        }

        public T GetObject()
        {
            return PoolQueue.Count > 0 ? PoolQueue.Dequeue() : _factory.Create();
        }

        public void Back(T gameObject)
        {
            PoolQueue.Enqueue(gameObject);
        }
    }
}


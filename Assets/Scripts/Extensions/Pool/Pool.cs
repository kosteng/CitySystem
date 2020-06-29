using System.Collections.Generic;

public class Pool<T>
{
    private IFactory<T> _factory;
    public Queue<T> PoolQueue = new Queue<T>();

    public Pool(IFactory<T> factory)
    {
		_factory = factory;
    }

    public T GetObject()
    {
        if (PoolQueue.Count > 0)
            return PoolQueue.Dequeue();
        return _factory.Create();
    }

    public void Back(T gameObject)
    {
        PoolQueue.Enqueue(gameObject);
    }
}


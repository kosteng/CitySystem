namespace Engine.Mediators
{
    /// <summary>
    /// Классы, реализующие данный интерфейс обновляются на любой сцене и не зависят от иерархии инсталлеров.
    /// Наиболее применимо для классов инициализируемых на уровне проекта. 
    /// </summary>
    public interface IAlwaysUpdatable
    {
        void Update(float deltaTime);
    }
}
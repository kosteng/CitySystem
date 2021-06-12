public interface IFactory<T>
{
	T Create();
	T Create(EInteractItemType prefab);
}
namespace Extensions.Pool
{
	public interface IFactory<T>
	{
		T Create();
	}
}
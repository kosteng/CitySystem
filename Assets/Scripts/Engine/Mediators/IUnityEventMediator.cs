namespace Engine.Mediators
{
    public interface IUnityEventMediator
    {
        bool IsActive { get; set; }
        
        void Update(float deltaTime);
        void LateUpdate(float deltaTime);
        void FixedUpdate(float deltaTime);
    }
}
using InputControls.CameraControls;
using Zenject;

public class InputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<CameraController>().AsSingle();
        Container.BindInterfacesTo<InputClicker>().AsSingle();
    }
}

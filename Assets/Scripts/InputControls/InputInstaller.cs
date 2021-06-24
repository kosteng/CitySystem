using InputControls.CameraControls;
using InputControls.InpitClicker;
using Zenject;

namespace InputControls
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CameraController>().AsSingle();
            Container.BindInterfacesTo<InputClicker>().AsSingle();
        }
    }
}

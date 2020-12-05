using UnityEngine;
using Zenject;
[CreateAssetMenu(menuName = "DatabasesSO/InputPrefabsInstaller")]
public class InputPrefabsInstaller : ScriptableObjectInstaller
{
    [SerializeField] private CameraView _cameraView;
    public override void InstallBindings()
    {
        Container.BindInstance(_cameraView);
    }
}

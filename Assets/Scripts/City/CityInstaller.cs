using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CityInstaller : MonoInstaller
{
    [SerializeField] private CityView _cityView;
    
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<CityController>().AsSingle().NonLazy();
        Container.BindInstance(_cityView);
    }
}

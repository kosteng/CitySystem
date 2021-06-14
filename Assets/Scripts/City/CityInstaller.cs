using City;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CityInstaller : MonoInstaller
{

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<CityController>().AsSingle().NonLazy();
    }
}

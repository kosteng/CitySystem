using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DayCounterInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<DayCounterController>().AsSingle().NonLazy();
    }
}

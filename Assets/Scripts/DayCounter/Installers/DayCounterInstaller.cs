using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DayCounterInstaller : MonoInstaller
{
    [SerializeField]private DayCounterView _dayCounterView;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<DayCounterController>().AsSingle().NonLazy();
        Container.BindInstance(_dayCounterView);

    }
}

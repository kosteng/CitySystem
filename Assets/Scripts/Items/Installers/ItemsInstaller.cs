using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ItemsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<InteractableItemController>().AsSingle();
    }
}

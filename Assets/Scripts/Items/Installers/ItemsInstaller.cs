using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ItemsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<Items.InteractableItemController>().AsSingle();
        Container.BindInterfacesTo<Items.InteractItemFactory>().AsSingle();
    }
}

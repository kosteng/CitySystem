using DayChangeSystem.Controllers;
using DayChangeSystem.Models;
using Engine.Mediators;
using UnityEngine;
using Zenject;

namespace DayChangeSystem.Installers
{
    public class DaySystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DayCounterController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<HourController>().AsSingle();
            Container.BindInterfacesAndSelfTo<DayCounterPresenter>().AsSingle();
            Container.BindInterfacesTo<DayModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<SunPrefabFactory>().AsSingle();

        }
    }
}

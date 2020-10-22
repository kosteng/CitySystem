using DayChangeSystem.Controllers;
using DayChangeSystem.Models;
using Engine.Mediators;
using UnityEngine;
using Zenject;

namespace DayChangeSystem.Installers
{
    public class DaySystemInstaller : MonoInstaller
    {
        [SerializeField] private DayCounterView _dayCounterView;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DayCounterController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<HourController>().AsSingle();
            Container.BindInterfacesTo<DayModel>().AsSingle();
            Container.BindInstance(_dayCounterView);
        }
    }
}

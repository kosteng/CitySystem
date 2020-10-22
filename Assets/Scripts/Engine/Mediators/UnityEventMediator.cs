using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


namespace Engine.Mediators
{
    public class UnityEventMediator : IUnityEventMediator
    {
        private readonly List<IUpdatable> _updatables;
        private readonly List<IAlwaysUpdatable> _alwaysUpdatables;
        private readonly List<ILateUpdatable> _lateUpdatables;
        private readonly List<IFixedUpdatable> _fixedUpdatables;


        public bool IsActive { get; set; } = true;

        public UnityEventMediator(
            [Inject(Optional = true, Source = InjectSources.Local)]
            List<IUpdatable> updatables,
            [Inject(Optional = true, Source = InjectSources.Local)]
            List<ILateUpdatable> lateUpdatables,
            [Inject(Optional = true, Source = InjectSources.Local)]
            List<IFixedUpdatable> fixedUpdatables,
            List<IAlwaysUpdatable> alwaysUpdatables)
        {
            _updatables = updatables;
            _lateUpdatables = lateUpdatables;
            _fixedUpdatables = fixedUpdatables;
            _alwaysUpdatables = alwaysUpdatables;


            var unityEventMediatorView = new GameObject("UnityEventMediator").AddComponent<UnityEventMediatorView>();
            unityEventMediatorView.Init(this);
        }

        public void Update(float deltaTime)
        {
            foreach (var item in _updatables)
                item.Update(deltaTime);

            foreach (var item in _alwaysUpdatables)
                item.Update(deltaTime);
        }

        public void LateUpdate(float deltaTime)
        {
            foreach (var item in _lateUpdatables)
                item.LateUpdate(deltaTime);
        }

        public void FixedUpdate(float deltaTime)
        {
            foreach (var item in _fixedUpdatables)
                item.FixedUpdate(deltaTime);
        }
    }
}
using System;
using UnityEngine;


namespace Engine.Mediators
{
    [DefaultExecutionOrder(200)] // CinemachineBrain - расположен в 100, и поэтому код отображающий индикаторы не поспевает
    public class UnityEventMediatorView : MonoBehaviour
    {
        private IUnityEventMediator _unityEventMediator;

        public void Init(IUnityEventMediator unityEventMediator)
        {
            _unityEventMediator = unityEventMediator;
        }
        
        private void Update()
        {
            _unityEventMediator?.Update(Time.deltaTime);
        }

        private void LateUpdate()
        {
            _unityEventMediator?.LateUpdate(Time.deltaTime);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using Engine.Mediators;
using UnityEngine;
using Zenject;

public class CameraController : IUpdatable, IInitializable 
{
    private CameraView _cameraView;

    public CameraController(CameraView cameraView)
    {
        _cameraView = cameraView;
    }

    public void Update(float deltaTime)
    {
        _cameraView.Move();
    }

    public void Initialize()
    {
        _cameraView = MonoBehaviour.Instantiate(_cameraView);
    }
}

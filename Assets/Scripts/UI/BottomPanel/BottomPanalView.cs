using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomPanalView : MonoBehaviour
{
    [SerializeField] private Button _buildings;
    public event Action OnClickBuildingsButton;

    public void OnBuildingsClick()
    {
        OnClickBuildingsButton?.Invoke();
    }
}

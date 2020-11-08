using System;
using UnityEngine;
using UnityEngine.UI;

public class BottomPanelView : MonoBehaviour
{
    [SerializeField] private Button _buildingsButton;
    
    public void Subscribe(Action onOpen)
    {
        _buildingsButton.onClick.AddListener(onOpen.Invoke);
    }
    
    public void Unsubscribe()
    {
        _buildingsButton.onClick.RemoveAllListeners();
    }
}

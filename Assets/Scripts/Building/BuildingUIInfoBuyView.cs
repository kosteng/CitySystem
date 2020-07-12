using System;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUIInfoBuyView : MonoBehaviour
{
    [SerializeField] private Button HouseBuldingButton;
    [SerializeField] private Button SawMillBuldingButton;
    [SerializeField] private Button MineBuldingButton;
    [SerializeField] private Text _nameBuildingText;
    [SerializeField] private Text _costBuildingText;
    public event Action OnHouseBildingClickButton;
    public event Action OnSawMillBildingClickButton;
    public event Action OnMineBildingClickButton;

    public void HouseBildingClick()
    {
        OnHouseBildingClickButton?.Invoke();
    }

    public void SawMillBildingClick()
    {
        OnSawMillBildingClickButton?.Invoke();
    }

    public void MineBildingClick()
    {
        OnMineBildingClickButton?.Invoke();
    }

    public void HouseBuldingButtonSetActive(bool value)
    {
        HouseBuldingButton.gameObject.SetActive(value);
    }

    public void SawMillBuldingButtonSetActive(bool value)
    {
        SawMillBuldingButton.gameObject.SetActive(value);
    }

    public void MineBuldingButtonSetActive(bool value)
    {
        MineBuldingButton.gameObject.SetActive(value);
    }
}

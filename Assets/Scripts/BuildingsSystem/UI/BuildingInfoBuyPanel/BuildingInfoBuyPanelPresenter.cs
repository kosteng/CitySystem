using System;
using BuildingsSystem.UI.BuildingInfoBuyPanel;
using UI.BottomPanel;
using UnityEngine;

public class BuildingInfoBuyPanelPresenter : IDisposable
{
    private readonly BuildingBuyPanel _view;
    private readonly BottomPanelPresenter _bottomPanelPresenter;
    private readonly BuildingFactory _buildingFactory;
    private readonly AllBuildingsDatabase _allBuildingsDatabase;

    private IBuilding _currentBuild;

    public IBuilding CurrentBuild => _currentBuild;

    public event Action OnBuyBuilding;

    public BuildingInfoBuyPanelPresenter(BuildingBuyPanel view,
        BottomPanelPresenter bottomPanelPresenter,
        BuildingFactory buildingFactory,
        AllBuildingsDatabase allBuildingsDatabase)
    {
        _view = view;
        _bottomPanelPresenter = bottomPanelPresenter;
        _buildingFactory = buildingFactory;
        _allBuildingsDatabase = allBuildingsDatabase;
        Subscribe();
    }

    public void Subscribe()
    {
        _bottomPanelPresenter.OnShowBuildingUIInfoBuyView += Show;
        _view.OnBuildingClickButton += ShowBuildingData;
        _view.OnCloseInfoPanelBuildingClickButton += CloseInfoBuyView;
        _view.OnBuyBuildingClickButton += BuyBuilding;
        _view.gameObject.SetActive(false);
    }

    private void Show()
    {
        Debug.Log("Buybutton");
        _view.gameObject.SetActive(!_view.gameObject.activeSelf);
    }

    private void CloseInfoBuyView()
    {
        _view.gameObject.SetActive(false);
    }

    private void ShowBuildingData(EBuildingType buildingType)
    {
        if (buildingType == EBuildingType.House)
        {
            _view.SetCostTextInfoPanel(_allBuildingsDatabase.HouseBuildingDatabase.ShowCost());
            _view.SetNameTextInfoPanel(_allBuildingsDatabase.HouseBuildingDatabase.Name);
        }
    }

// TO DO придумать способ проверки и оплаты до создания объекта
    private void BuyBuilding(EBuildingType buildingType)
    {
        if (!_allBuildingsDatabase.HouseBuildingDatabase.TryBuyBuilding())
        {
            Debug.Log("Не хватает ресурсов");
            return;
        }

        if (_currentBuild.IsBuy && _currentBuild != null)
        {
            Debug.Log("Куплено уже");
            return;
        }

        _currentBuild = _buildingFactory.Create();
        _currentBuild.PayBuilding();
        _currentBuild.SetData();
        OnBuyBuilding?.Invoke();
    }

    public void Dispose()
    {
        _bottomPanelPresenter.OnShowBuildingUIInfoBuyView -= Show;
        _view.OnBuildingClickButton -= ShowBuildingData;
        _view.OnCloseInfoPanelBuildingClickButton -= CloseInfoBuyView;
        _view.OnBuyBuildingClickButton -= BuyBuilding;
    }
}
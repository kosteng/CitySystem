﻿using Items.ResourceItems;
using UnityEngine;

namespace InputControls
{
    public interface IPlayerInputControls
    {
        void PressCheatAddResources(IResourcesStorage resourcesStorage);
        bool PressInventoryButton();
        void CheatAddResources(IResourcesStorage resourcesStorage);
        void ShowHideCityResourcesPanel(GameObject panel);
    }

    public class PlayerInputControls : IPlayerInputControls
    {
        public void PressCheatAddResources(IResourcesStorage resourcesStorage)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                foreach (var resourceItemData in resourcesStorage.ResourceItemsData)
                {
                    resourceItemData.Amount += 1000f;
                }
            }
        }

        public bool PressInventoryButton()
        {
            return Input.GetKeyDown(KeyCode.Space);
        }

        public void CheatAddResources(IResourcesStorage resourcesStorage)
        {
            foreach (var resourceItemData in resourcesStorage.ResourceItemsData)
            {
                resourceItemData.Amount += 1000f;
            }
        }

        public void ShowHideCityResourcesPanel(GameObject panel)
        {
            if (Input.GetKeyDown(KeyCode.C))
                panel.gameObject.SetActive(!panel.gameObject.activeSelf);
        }
    }
}
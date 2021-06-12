using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "DatabasesSO/ItemsPrefabsInstaller")]
public class ItemsPrefabsInstaller : ScriptableObjectInstaller
{
    [SerializeField] private InteractableItemView _interactableItemView;
    [SerializeField] private InteractItemDatabase _interactItemDatabase;
    
    public override void InstallBindings()
    {
        // Container.BindInstance(_interactableItemView);
        Container.BindInstance(_interactItemDatabase);
    }
}
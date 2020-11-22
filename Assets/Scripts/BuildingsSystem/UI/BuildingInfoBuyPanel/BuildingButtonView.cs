using System.Collections;
using System.Collections.Generic;
using Engine.UI;
using UnityEngine;
using UnityEngine.UI;

public class BuildingButtonView : APanel
{
    [SerializeField] private Text _nameText;

    public void SetName(string name)
    {
        _nameText.text = name;
    }
    
   // public void Sucribe
}

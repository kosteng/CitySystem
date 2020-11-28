using System;
using UnityEngine;

[CreateAssetMenu(menuName = "DatabasesSO/CityDatabase")]
public class CityDatabase : ScriptableObject
{
    [SerializeField] private ResourcesesModel _model;
    public float People;
    public float Gold;
    public float Food;
    public float Wood;
    public float Stone;
    public float Iron;
    public float Warrior;
    public void Clear()
    {
        People = 1000;
        Gold = 1000;
        Food = 1000;
        Wood = 1000;
        Stone = 1000;
        Iron = 1000;
        Warrior = 1000;
    }
}



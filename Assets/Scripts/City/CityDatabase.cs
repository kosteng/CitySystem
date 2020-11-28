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
        People = 10;
        Gold = 0;
        Food = 100;
        Wood = 0;
        Stone = 0;
        Iron = 0;
        Warrior = 0;
    }
}



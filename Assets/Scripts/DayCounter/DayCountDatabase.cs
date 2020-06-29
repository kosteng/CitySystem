using UnityEngine;

[CreateAssetMenu(menuName = "DatabasesSO/DayCounterDatabase")]
public class DayCountDatabase : ScriptableObject
{
    public float Day = 0f;
    public float HoursCountIsEndedDay = 24f;
}

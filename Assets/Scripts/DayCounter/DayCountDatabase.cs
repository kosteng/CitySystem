using UnityEngine;

[CreateAssetMenu(menuName = "DatabasesSO/DayCounterDatabase")]
public class DayCountDatabase : ScriptableObject
{
    public float Day;
    public float HoursCountIsEndedDay = 4f;

    public void Clear()
    {
        Day = 0;
    }
}

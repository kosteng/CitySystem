using UnityEngine;

public interface IInputClicker
{
    bool Click(ref IInteractableItem item, ref Vector3 hitPoint);
}
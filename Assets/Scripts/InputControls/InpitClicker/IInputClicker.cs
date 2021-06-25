using Items.InteractItems.Interfaces;
using UnityEngine;

namespace InputControls.InpitClicker
{
    public interface IInputClicker
    {
        bool Click(ref IInteractableItem item, ref Vector3 hitPoint);
    }
}
﻿namespace Items
{
    public interface IInteractItemFactory
    {
        IInteractableItem Create(EInteractItemType type);
    }
}
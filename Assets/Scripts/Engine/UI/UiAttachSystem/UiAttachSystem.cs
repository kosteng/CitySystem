using System.Collections.Generic;
using Zenject;

namespace Engine.UI.UiAttachSystem
{
    public class UiAttachSystem : IInitializable
    {
        private readonly ICanvasContainer _canvasContainer;
        private readonly List<IAttachableUi> _attachables;

        public UiAttachSystem(ICanvasContainer canvasContainer, List<IAttachableUi> attachables)
        {
            _canvasContainer = canvasContainer;
            _attachables = attachables;
        }

        public void Initialize()
        {
            foreach (var attachable in _attachables)
                _canvasContainer.Attach(attachable);
        }
    }
}


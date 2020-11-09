namespace Engine.UI.Canvas
{
    public class CanvasContainer : ICanvasContainer
    {
        private readonly CanvasView _view;

        public CanvasContainer(CanvasView view)
        {
            _view = view;
        }

        public void Attach(IAttachableUi attachable)
        {
            _view.Attach(attachable);
        }
    }
}
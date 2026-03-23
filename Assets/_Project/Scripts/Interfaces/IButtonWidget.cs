namespace Assets.Scripts.Interfaces
{
    using UnityEngine.EventSystems;

    public interface IButtonWidget : IPointerDownHandler, IPointerUpHandler
    {
        void AnimatePress();

        void AnimateRelease();
    }
}

using UnityEngine.EventSystems;

namespace Assets.Scripts.Interfaces
{
    public interface IButtonWidget : IPointerDownHandler, IPointerUpHandler
    {
        void AnimatePress();
        void AnimateRelease();
    }
}

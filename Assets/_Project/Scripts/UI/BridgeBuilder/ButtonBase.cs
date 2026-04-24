namespace Assets.Scripts.UI.BridgeBuilder
{
    using Assets.Project.Scripts.Other;
    using Assets.Scripts.Interfaces;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    public abstract class ButtonBase : MonoBehaviour, IButtonWidget
    {
        [field: SerializeField] public Button Button { get; private set; }

        protected virtual void OnEnable() =>
            Button.onClick.AddListener(OnClickButton);

        protected virtual void OnDisable() =>
            Button.onClick.RemoveListener(OnClickButton);

        public void OnPointerDown(PointerEventData eventData) =>
            AnimatePress();

        public void OnPointerUp(PointerEventData eventData) =>
            AnimateRelease();

        public void AnimatePress() =>
            TweenHelper.ButtonShake(transform);

        public void AnimateRelease() =>
            TweenHelper.HideButton(transform);

        protected abstract void OnClickButton();
    }
}
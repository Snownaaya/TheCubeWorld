using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.MainMenu
{
    public abstract class WindowView : MonoBehaviour
    {
        [field: SerializeField] protected Button ButtonOpen { get; private set; }
        [field: SerializeField] protected Button ButtonClose { get; private set; }

        private void OnEnable()
        {
            ButtonOpen.onClick.AddListener(Open);
            ButtonClose.onClick.AddListener(Close);
        }

        private void OnDisable()
        {
            ButtonOpen.onClick.RemoveListener(Open);
            ButtonClose.onClick.RemoveListener(Close);
        }

        protected abstract void Open();

        protected abstract void Close();
    }
}
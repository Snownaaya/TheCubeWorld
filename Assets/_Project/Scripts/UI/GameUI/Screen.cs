using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.GameUI
{
    public abstract class Screen : MonoBehaviour
    {
        [field: SerializeField] public RectTransform RectTransform { get; private set; }
        [field: SerializeField] public CanvasGroup CanvasGroup { get; private set; }
        [field: SerializeField] public Button Button { get; private set; }

        public abstract void Open();

        public abstract void Close();
    }
}

using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.GameUI
{
    public class BackgroundPanel : MonoBehaviour
    {
        [SerializeField] private RectTransform _background;

        public void Show() =>
            _background.gameObject.SetActive(true);

        public void Hide() =>
            _background.gameObject.SetActive(false);
    }
}

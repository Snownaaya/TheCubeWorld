using UnityEngine;

namespace Assets.Scripts.TutorialObject
{
    public class MoveTutorialPC : MonoBehaviour
    {
        [SerializeField] private RectTransform[] _rectTransforms;

        public void Disable() =>
            gameObject.SetActive(false);

        public void Enable() =>
            gameObject.SetActive(true);
    }
}
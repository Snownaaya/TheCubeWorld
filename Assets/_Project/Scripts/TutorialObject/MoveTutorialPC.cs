namespace Assets.Scripts.TutorialObject
{
    using UnityEngine;

    public class MoveTutorialPC : MonoBehaviour
    {
        [SerializeField] private RectTransform[] _rectTransforms;

        public void Disable() =>
            gameObject.SetActive(false);

        public void Enable() =>
            gameObject.SetActive(true);
    }
}
namespace Assets.Scripts.TutorialObject
{
    using Assets.Scripts.PluginYG;
    using UnityEngine;

    public class TutorialBridgeStep : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private TextBuildBridge _buildBridgeText;
        [SerializeField] private float _openDistance;

        private bool _isShown;

        public bool IsSetPosition(Vector3 position)
        {
            float distanceSqr = _openDistance * _openDistance;
            float currentDistanceSqr = (transform.position - position).sqrMagnitude;

            bool inRange = currentDistanceSqr < distanceSqr;

            if (inRange && _isShown == false)
            {
                _isShown = true;
                _buildBridgeText.SetText(LocalizedText.Get(
                    english: "Bridge Construction",
                    russia: "Постройка моста",
                    turkish: "Köprü inşaatı"));
                _buildBridgeText.Show();
            }
            else if (inRange == false && _isShown)
            {
                _isShown = false;
                _buildBridgeText.Hide();
            }

            return inRange;
        }

        public void ForceHide()
        {
            _isShown = false;
            _buildBridgeText?.Hide();
            _rectTransform.gameObject.SetActive(false);
        }
    }
}
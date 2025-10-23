using UnityEngine;

namespace Assets.Scripts.UI.SelectButtons
{
    public class BridgeChoicePanel : MonoBehaviour
    {
        private bool _isOpen;

        public bool IsOpen => _isOpen;

        public void Open()
        {
            if (_isOpen == false)
            {
                _isOpen = true;
                gameObject.SetActive(true);
            }
        }

        public void Close()
        {
            if (_isOpen)
            {
                _isOpen = false;
                gameObject.SetActive(false);
            }
        }
    }
}
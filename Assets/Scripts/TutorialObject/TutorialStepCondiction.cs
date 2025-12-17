using UnityEngine;

namespace Assets.Scripts.TutorialObject
{
    public class TutorialStepCondiction : MonoBehaviour, ITutorialObjectEventSource, ITutorialStepCondiction
    {
        private bool _isComplete = false;

        public bool Completed
        {
            get => _isComplete;
            set => _isComplete = value;
        }

        public void Disable()
        {
            Completed = false;
            gameObject.SetActive(false);
        }

        public void Enable()
        {
            Completed = true;
            gameObject.SetActive(true);
        }
    }
}
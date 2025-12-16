using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.AudioUI
{
    public abstract class VolumeSliderView : MonoBehaviour
    {
        [field: SerializeField] protected Slider VolumeSlider { get; private set; }

        private void OnEnable() =>
            VolumeSlider.onValueChanged.AddListener(OnVolumeChanged);

        private void OnDisable() =>
            VolumeSlider.onValueChanged.RemoveListener(OnVolumeChanged);

        protected abstract void OnVolumeChanged(float value);
    }
}
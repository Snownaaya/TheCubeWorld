using Assets.Scripts.Service.Audio;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.MainMenu
{
    public abstract class WindowView : MonoBehaviour
    {
        [field: SerializeField] protected Button ButtonOpen { get; private set; }
        [field: SerializeField] protected Button ButtonClose { get; private set; }

        private AudioService _audioService;

        [Inject]
        private void Construct(AudioService audioService) =>
            _audioService = audioService;

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

        protected virtual void Open() =>
            _audioService.PlaySound(AudioTypes.Buttons);

        protected virtual void Close() =>
            _audioService.PlaySound(AudioTypes.Buttons);
    }
}
namespace Assets.Scripts.UI.AudioUI
{
    using Assets.Scripts.Service.Audio;
    using Cysharp.Threading.Tasks;
    using Reflex.Attributes;

    public class BackgroundVolumeHandler : VolumeSliderView
    {
        private BackgroundAudioService _audioService;

        [Inject]
        private void Construct(BackgroundAudioService audioService) =>
            _audioService = audioService;

        protected override void OnVolumeChanged(float value) =>
            _audioService.BackgroundSetVolume(value).Forget();
    }
}
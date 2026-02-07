using Assets.Scripts.Service.Audio;
using Assets.Scripts.Service.LevelLoaderService.Loader;
using Assets.Scripts.UseCase;
using Cysharp.Threading.Tasks;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.MainMenu
{
    public class StartButton : MonoBehaviour
    {
        [SerializeField] private Button _startButton;

        private ForegroundAudioService _audioService;
        private SceneTransitions _sceneTransitions;

        [Inject]
        private void Construct(
            ForegroundAudioService audioService,
            SceneTransitions sceneTransitions)
        {
            _audioService = audioService;
            _sceneTransitions = sceneTransitions;
        }

        private void OnEnable() =>
            _startButton.onClick.AddListener(OnStartButtonClicked);

        private void OnDisable() =>
            _startButton.onClick.RemoveListener(OnStartButtonClicked);

        private void OnStartButtonClicked()
        {
            _audioService.PlaySound(AudioTypes.Buttons);
            _sceneTransitions.StartLevel(SceneID.Level_1).Forget();
        }
    }
}
namespace Assets.Scripts.UI.SettingsMenu
{
    using Assets.Scripts.Items;
    using Assets.Scripts.Service.Audio;
    using Assets.Scripts.UseCase;
    using Cysharp.Threading.Tasks;
    using Reflex.Attributes;
    using UnityEngine;

    public class ReturnMenu : MonoBehaviour
    {
        private const string MainMenu = nameof(MainMenu);

        [SerializeField] private Settings _settings;

        private IResourceService _resourceService;
        private SceneTransitions _sceneTransitions;
        private ForegroundAudioService _foregroundAudioService;

        [Inject]
        private void Construct(
            IResourceService resourceService,
            SceneTransitions sceneTransitions,
            ForegroundAudioService foregroundAudioService)
        {
            _resourceService = resourceService;
            _sceneTransitions = sceneTransitions;
            _foregroundAudioService = foregroundAudioService;
        }

        private void OnEnable() =>
            _settings.MainMenuRequested += OnLoadMenu;

        private void OnDisable() =>
            _settings.MainMenuRequested -= OnLoadMenu;

        private void OnLoadMenu()
        {
            _foregroundAudioService.PlaySound(AudioTypes.Buttons);
            _resourceService.Clear();
            _sceneTransitions.GetMainMenu().Forget();
            _settings.SetPause(false);
        }
    }
}
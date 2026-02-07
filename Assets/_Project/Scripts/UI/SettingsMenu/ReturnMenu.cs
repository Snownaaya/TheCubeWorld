using Assets.Scripts.Items;
using Assets.Scripts.UseCase;
using Cysharp.Threading.Tasks;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.UI.SettingsMenu
{
    public class ReturnMenu : MonoBehaviour
    {
        private const string MainMenu = nameof(MainMenu);

        [SerializeField] private Settings _settings;

        private IResourceService _resourceService;
        private SceneTransitions _sceneTransitions;

        [Inject]
        private void Construct(
            IResourceService resourceService,
            SceneTransitions sceneTransitions)
        {
            _resourceService = resourceService;
            _sceneTransitions = sceneTransitions;
        }

        private void OnEnable() =>
            _settings.MainMenuRequested += OnLoadMenu;

        private void OnDisable() =>
            _settings.MainMenuRequested -= OnLoadMenu;

        private void OnLoadMenu()
        {
            _resourceService.Clear();
            _sceneTransitions.GetMainMenu().Forget();
            _settings.SetPause(false);
        }
    }
}
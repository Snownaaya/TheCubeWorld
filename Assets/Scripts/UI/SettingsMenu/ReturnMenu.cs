using Assets.Scripts.Service.LevelLoaderService.Loader;
using Assets.Scripts.Items;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.UI.SettingsMenu
{
    public class ReturnMenu : MonoBehaviour
    {
        private const string MainMenu = nameof(MainMenu);

        [SerializeField] private Settings _settings;

        private ILevelLoader _levelLoader;
        private IResourceService _resourceService;

        [Inject]
        private void Construct(
            ILevelLoader levelLoader,
            IResourceService resourceService)
        {
            _levelLoader = levelLoader;
            _resourceService = resourceService;
        }

        private void OnEnable() =>
            _settings.MainMenuRequested += OnLoadMenu;

        private void OnDisable() =>
            _settings.MainMenuRequested -= OnLoadMenu;

        private void OnLoadMenu()
        {
            _resourceService.Clear();
            _levelLoader.Load(SceneID.MainMenu);
            _settings.SetPause(false);
        }
    }
}
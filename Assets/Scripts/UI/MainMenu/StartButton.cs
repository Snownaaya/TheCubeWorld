using Assets.Scripts.Service.LevelLoaderService.Loader;
using System.Linq;
using System;
using Assets.Scripts.Service.Audio;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.UI.MainMenu
{
    public class StartButton : MonoBehaviour
    {
        private const string LevelPrefix = "Level_";

        [SerializeField] private SceneID _levels;
        [SerializeField] private Button _startButton;

        private ForegroundAudioService _audioService;

        [Inject]
        private void Construct(ForegroundAudioService audioService) =>
            _audioService = audioService;

        private void OnEnable() =>
            _startButton.onClick.AddListener(OnStartButtonClicked);

        private void OnDisable() =>
            _startButton.onClick.RemoveListener(OnStartButtonClicked);

        private void OnStartButtonClicked()
        {
            SceneID level = Enum.GetValues(typeof(SceneID))
                .Cast<SceneID>()
                .Where(lvl => lvl.ToString()
                .StartsWith(LevelPrefix))
                .FirstOrDefault();
            ////.OrderBy(_ => Random.value)

            _audioService.PlaySound(AudioTypes.Buttons);
            SceneManager.LoadScene(level.ToString());
        }
    }
}
//_levels[/*Random.Range(0, _levels.Length)*/1];
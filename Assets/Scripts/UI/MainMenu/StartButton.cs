using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.UI.MainMenu
{
    internal class StartButton : MonoBehaviour
    {
        [SerializeField] private string[] _levels;
        [SerializeField] private Button _startButton;

        private void OnEnable() =>
            _startButton.onClick.AddListener(OnStartButtonClicked);

        private void OnDisable() =>
            _startButton.onClick.RemoveListener(OnStartButtonClicked);

        private void OnStartButtonClicked()
        {
            string level = _levels[/*Random.Range(0, _levels.Length)*/0];
            SceneManager.LoadScene(level);
        }
    }
}

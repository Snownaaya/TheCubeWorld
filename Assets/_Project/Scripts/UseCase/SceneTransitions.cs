using Assets.Scripts.Service.LevelLoaderService;
using Assets.Scripts.Service.LevelLoaderService.Loader;
using Cysharp.Threading.Tasks;

namespace Assets.Scripts.UseCase
{
    public class SceneTransitions
    {
        private ILevelLoader _levelLoader;
        private LevelSelected _levelSelected;
        private float _delay = 1.4f;

        public SceneTransitions(
            ILevelLoader levelLoader,
            LevelSelected levelSelected)
        {
            _levelLoader = levelLoader;
            _levelSelected = levelSelected;
        }

        public async UniTask LoadNextLevel()
        {
            await UniTask.Delay(System.TimeSpan.FromSeconds(_delay));
            await _levelLoader.Load(_levelSelected.GetNextLevel());
        }
    }
}
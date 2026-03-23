namespace Assets.Project.Scripts.UseCase
{
    using Assets.Scripts.Service.Audio;
    using Assets.Scripts.Service.LevelLoaderService.Loader;
    using Assets.Scripts.UseCase;
    using Cysharp.Threading.Tasks;

    public class StartButtonUseCase
    {
        private ForegroundAudioService _audioService;
        private SceneTransitions _sceneTransitions;

        public StartButtonUseCase(
            ForegroundAudioService audioService,
            SceneTransitions sceneTransitions)
        {
            _audioService = audioService;
            _sceneTransitions = sceneTransitions;
        }

        public void Execute()
        {
            _audioService.PlaySound(AudioTypes.Buttons);
            _sceneTransitions.StartLevel(SceneID.Level_1).Forget();
        }
    }
}

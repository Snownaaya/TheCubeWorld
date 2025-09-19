using Assets.Scripts.Service.LevelLoaderService.Loader;
using Assets.Scripts.Achievements;
using Random = UnityEngine.Random;
using Assets.Scripts.Interfaces;
using Cysharp.Threading.Tasks;
using Assets.Scripts.Items;
using System.Threading;
using System;
using Assets.Scripts.Player.Core;

namespace Assets.Scripts.GameStateMachine.States
{
    public class EndLevelState : BaseGameState
    {
        private ILevelLoader _levelLoader;
        private CharacterHolder _character;
        private AchievementService _achievementService;
        private CancellationTokenSource _cancellationTokenSource;

        private float _delay = 4;

        public EndLevelState(ISwitcher switcher,
            EntryPointState entryPoint,
            CharacterHolder character,
            ILevelLoader levelLoader,
            AchievementService achievementService) : base(switcher, entryPoint)
        {
            _levelLoader = levelLoader;
            _character = character;
            _achievementService = achievementService;
        }

        public override void Enter()
        {
            base.Enter();

            ResourceTypes selectedConfig = (ResourceTypes)Random.Range(0, Enum.GetValues(typeof(ResourceTypes)).Length);
            _cancellationTokenSource = new CancellationTokenSource();
            DelayNextLevel(_cancellationTokenSource.Token);
            _achievementService.Achieve(AchievementNames.Beginning); 
        }

        public override void Exit()
        {
            base.Exit();

            EntryPoint.EndLevel.LevelEnded -= Switcher.SwitchState<StartLevelState>;
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }

        private async void DelayNextLevel(CancellationToken cancellationToken)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_delay), cancellationToken : cancellationToken);

            if (cancellationToken.IsCancellationRequested)
                return;

            _levelLoader.Load(EntryPoint.LevelSelected.GetNextLevel());
            EntryPoint.EndLevel.LevelEnded += Switcher.SwitchState<StartLevelState>;
            _character.Character.CharacterHealth.ResetHealth();
        }
    }
}
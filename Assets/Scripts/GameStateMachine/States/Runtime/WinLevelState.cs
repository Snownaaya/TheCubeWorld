using Assets.Scripts.Service.LevelLoaderService.Loader;
using Assets.Scripts.Player.Wallet;
using Assets.Scripts.Achievements;
using Random = UnityEngine.Random;
using Assets.Scripts.Player.Core;
using Assets.Scripts.Interfaces;
using Cysharp.Threading.Tasks;
using Assets.Scripts.Items;
using System.Threading;
using System;

namespace Assets.Scripts.GameStateMachine.States.Runtime
{
    public class WinLevelState : RuntimeState
    {
        private ILevelLoader _levelLoader;
        private IWallet _wallet;
        private CharacterHolder _character;
        private AchievementService _achievementService;
        private CancellationTokenSource _cancellationTokenSource;

        private float _delay = 4;
        private int _addCoins = 20; 

        public WinLevelState(ISwitcher switcher,
            EntryPointState entryPoint,
            CharacterHolder character,
            ILevelLoader levelLoader,
            AchievementService achievementService,
            IWallet wallet) : base(switcher, entryPoint, character)
        {
            _levelLoader = levelLoader;
            _character = character;
            _achievementService = achievementService;
        }

        public override void Enter()
        {
            base.Enter();

            ResourceTypes selectedConfig = (ResourceTypes)Random.Range(0, Enum.GetValues(typeof(ResourceTypes)).Length);
            EntryPoint.EndLevel.LevelEnded += () => Switcher.SwitchState<StartLevelState>();
            _cancellationTokenSource = new CancellationTokenSource();
            DelayNextLevel(_cancellationTokenSource.Token);
            _wallet.AddCoins(_addCoins);
            _achievementService.Achieve(AchievementNames.Beginning);
        }

        public override void Exit()
        {
            base.Exit();

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
            _character.Character.Health.ResetHealth();
        }
    }
}
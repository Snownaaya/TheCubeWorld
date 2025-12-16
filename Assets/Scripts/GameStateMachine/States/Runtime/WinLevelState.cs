using Assets.Scripts.Service.LevelLoaderService.Loader;
using Assets.Scripts.Player.Wallet;
using Assets.Scripts.Achievements;
using Assets.Scripts.Player.Core;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Items;
using Cysharp.Threading.Tasks;
using Random = UnityEngine.Random;
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
            _wallet = wallet;
            _achievementService = achievementService;
        }

        public override void Enter()
        {
            base.Enter();

            ResourceTypes selectedConfig = (ResourceTypes)Random.Range(0, Enum.GetValues(typeof(ResourceTypes)).Length);
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
            if (cancellationToken.IsCancellationRequested)
                return;

            await UniTask.Delay(TimeSpan.FromSeconds(_delay), cancellationToken: cancellationToken);

            _character.Character.Health.ResetHealth();
            await _levelLoader.Load(EntryPoint.LevelSelected.GetNextLevel());
        }
    }
}
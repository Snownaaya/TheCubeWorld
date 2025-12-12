using Assets.Scripts.Interfaces;
using Assets.Scripts.Items;
using Assets.Scripts.Player.Core;
using Assets.Scripts.Service.Audio;
using Assets.Scripts.Service.CharacterService;

namespace Assets.Scripts.GameStateMachine.States.Runtime
{
    public class StartLevelState : RuntimeState
    {
        private ICharacterTeleportService _characterTeleportService;
        private IResourceService _resourceService;

        public StartLevelState(ISwitcher switcher,
            EntryPointState entryPoint,
            ICharacterTeleportService characterTeleportService,
            CharacterHolder characterHolder,
            IResourceService resourceService) : base(switcher,
                entryPoint,
                characterHolder)
        {
            _characterTeleportService = characterTeleportService;
            _resourceService = resourceService;
        }

        public override void Enter()
        {
            base.Enter();
            EntryPoint.EndLevel.LevelEnded += OnStartLevel;
            _characterTeleportService?.SpawnAtStart();
            _resourceService.ReturnAllPool();
            _resourceService.ActiveResources.Clear();
        }

        public override void Exit()
        {
            base.Exit();


            EntryPoint.EndLevel.LevelEnded -= OnStartLevel;
        }

        private void OnStartLevel() =>
            Switcher.SwitchState<WinLevelState>();
    }
}
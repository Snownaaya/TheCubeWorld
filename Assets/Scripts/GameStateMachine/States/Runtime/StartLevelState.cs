using Assets.Scripts.Interfaces;
using Assets.Scripts.Player.Core;
using Assets.Scripts.Service.CharacterService;

namespace Assets.Scripts.GameStateMachine.States.Runtime
{
    public class StartLevelState : RuntimeState
    {
        private ICharacterTeleportService _characterTeleportService;

        public StartLevelState(ISwitcher switcher,
            EntryPointState entryPoint,
            ICharacterTeleportService characterTeleportService,
            CharacterHolder characterHolder) : base(switcher, entryPoint, characterHolder)
        {
            _characterTeleportService = characterTeleportService;
        }

        public override void Enter()
        {
            base.Enter();
            
            _characterTeleportService?.SpawnAtStart();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
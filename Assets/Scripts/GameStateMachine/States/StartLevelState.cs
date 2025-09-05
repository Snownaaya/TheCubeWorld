using Assets.Scripts.Service.CharacterService;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Player.Core;

namespace Assets.Scripts.GameStateMachine.States
{
    public class StartLevelState : BaseGameState
    {
        private ICharacterTeleportService _characterTeleportService;
        private CharacterHolder _characterHolder;

        public StartLevelState(ISwitcher switcher,
            EntryPointState entryPoint,
            ICharacterTeleportService characterTeleportService,
            CharacterHolder characterHolder) : base(switcher, entryPoint)
        {
            _characterTeleportService = characterTeleportService;
            _characterHolder = characterHolder;
        }

        public override void Enter()
        {
            base.Enter();
            
            _characterTeleportService?.SpawnAtStart();

            _characterHolder.Character.Died += Switcher.SwitchState<LossState>;
        }

        public override void Exit()
        {
            base.Exit();

            _characterHolder.Character.Died -= Switcher.SwitchState<LossState>;
        }
    }
}
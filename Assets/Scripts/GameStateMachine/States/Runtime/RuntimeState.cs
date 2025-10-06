using Assets.Scripts.GameStateMachine.States.Phases;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Player.Core;

namespace Assets.Scripts.GameStateMachine.States.Runtime
{
    public abstract class RuntimeState : BaseGameState
    {
        private CharacterHolder _characterHolder;

        protected RuntimeState(ISwitcher switcher,
            EntryPointState entryPoint,
            CharacterHolder characterHolder) : base(switcher, entryPoint)
        {
            _characterHolder = characterHolder;
        }

        public override void Enter()
        {
            base.Enter();

            _characterHolder.Character.Health.Died += OnPLayerDeath;
        }

        public override void Exit()
        {
            base.Exit();

            _characterHolder.Character.Health.Died -= OnPLayerDeath;
        }

        private void OnPLayerDeath(ILoss loss) =>
            Switcher.SwitchState<LossState>();
    }
}

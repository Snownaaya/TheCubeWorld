using Assets.Scripts.Interfaces;

namespace Assets.Scripts.GameStateMachine.States
{
    internal class StartLevelState : BaseGameState
    {
        public StartLevelState(ISwitcher switcher, EntryPoint flow) : base(switcher, flow) { }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}

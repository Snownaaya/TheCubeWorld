using Assets.Scripts.Interfaces;

namespace Assets.Scripts.GameStateMachine.States
{
    internal class StartLevelState : BaseGameState
    {
        public StartLevelState(ISwitcher switcher, GameFlow flow) : base(switcher, flow) { }

        public override void Enter()
        {
            base.Enter();

            GameFlow.StartLevel.gameObject.SetActive(true);
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}

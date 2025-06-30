using Assets.Scripts.Interfaces;

namespace Assets.Scripts.GameStateMachine.States
{
    internal class StartLevelState : BaseGameState
    {
        public StartLevelState(ISwitcher switcher, GameFlow flow) : base(switcher, flow) { }

        public override void Enter()
        {
            base.Enter();

            GameFlow.LevelPool.SpawnLevel();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}

using Assets.Scripts.Interfaces;

namespace Assets.Scripts.GameStateMachine.States
{
    internal class RespawnState : BaseGameState
    {
        private const string Level_1 = nameof(Level_1);

        public RespawnState(ISwitcher switcher, GameFlow flow) : base(switcher, flow) { }

        public override void Enter()
        {
            base.Enter();

            GameFlow.LossScreen.Close();
            GameFlow.LevelLoader.Load(Level_1);
            GameFlow.PauseHandler.Remove(GameFlow.LossScreen);
            Switcher.SwitchState<StartLevelState>();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}

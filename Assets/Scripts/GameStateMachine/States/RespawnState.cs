using Assets.Scripts.Interfaces;

namespace Assets.Scripts.GameStateMachine.States
{
    internal class RespawnState : BaseGameState
    {
        public RespawnState(ISwitcher switcher, EntryPoint flow) : base(switcher, flow) { }

        public override void Enter()
        {
            base.Enter();

            GameFlow.LossScreen.Close();
            GameFlow.LevelLoader.Load(GameFlow.LevelSelected.GetCurrentLevel());
            GameFlow.PauseHandler.Remove(GameFlow.LossScreen);
            Switcher.SwitchState<StartLevelState>();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}

using Assets.Scripts.Interfaces;

namespace Assets.Scripts.GameStateMachine.States
{
    public class RespawnState : BaseGameState
    {
        public RespawnState(ISwitcher switcher, EntryPointState entryPoint) : base(switcher, entryPoint) { }

        public override void Enter()
        {
            base.Enter();

            EntryPoint.LossScreen.Close();
            EntryPoint.LevelLoader.Load(EntryPoint.LevelSelected.GetCurrentLevel());
            EntryPoint.PauseHandler.Remove(EntryPoint.LossScreen);
            Switcher.SwitchState<StartLevelState>();
            EntryPoint.Inventory.Reset();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
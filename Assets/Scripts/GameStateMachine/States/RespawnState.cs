using Assets.Scripts.Service.LevelLoaderService.Loader;
using Assets.Scripts.Player.Inventory;
using Assets.Scripts.Service.Pause;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.GameStateMachine.States
{
    public class RespawnState : BaseGameState
    {
        private ILevelLoader _levelLoader;
        private PauseHandler _pauseHandler;
        private IInventory _inventory;

        public RespawnState(ISwitcher switcher,
            EntryPointState entryPoint,
            ILevelLoader levelLoader,
            PauseHandler pauseHandler,
            IInventory inventory) : base(switcher, entryPoint)
        {
            _levelLoader = levelLoader;
            _pauseHandler = pauseHandler;
            _inventory = inventory;
        }

        public override void Enter()
        {
            base.Enter();

            EntryPoint.LossScreen.Close();
            _levelLoader.Load(EntryPoint.LevelSelected.GetCurrentLevel());
            _pauseHandler.Remove(EntryPoint.LossScreen);
            Switcher.SwitchState<StartLevelState>();
            _inventory.Reset();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
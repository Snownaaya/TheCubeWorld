using Assets.Scripts.Service.LevelLoaderService.Loader;
using Assets.Scripts.Player.Inventory;
using Assets.Scripts.Service.Pause;
using Assets.Scripts.Player.Core;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.GameStateMachine.States
{
    public class RespawnState : BaseGameState
    {
        private PauseHandler _pauseHandler;
        private CharacterHolder _characterHolder;
        private ILevelLoader _levelLoader;
        private IInventory _inventory;

        public RespawnState(ISwitcher switcher,
            EntryPointState entryPoint,
            ILevelLoader levelLoader,
            PauseHandler pauseHandler,
            IInventory inventory,
            CharacterHolder characterHolder) : base(switcher, entryPoint)
        {
            _levelLoader = levelLoader;
            _pauseHandler = pauseHandler;
            _inventory = inventory;
            _characterHolder = characterHolder;
        }

        public override void Enter()
        {
            base.Enter();

            EntryPoint.LossScreen.Close();
            _levelLoader.Load(EntryPoint.LevelSelected.GetCurrentLevel());
            _pauseHandler.Remove(EntryPoint.LossScreen);
            _characterHolder.Character.CharacterModel.gameObject.SetActive(true);
            _characterHolder.Character.CharacterHealth.ResetHealth();
            Switcher.SwitchState<StartLevelState>();
            _inventory.Reset();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
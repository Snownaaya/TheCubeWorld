using Assets.Scripts.Service.LevelLoaderService.Loader;
using Assets.Scripts.GameStateMachine.States.Runtime;
using Assets.Scripts.Player.Inventory;
using Assets.Scripts.Service.Pause;
using Assets.Scripts.Player.Core;
using Assets.Scripts.Interfaces;
using Assets.Scripts.PluginYG;
using Assets.Scripts.Items;

namespace Assets.Scripts.GameStateMachine.States.Phases
{
    public class RespawnState : PhasesState
    {
        private PauseHandler _pauseHandler;
        private CharacterHolder _characterHolder;
        private ILevelLoader _levelLoader;

        public RespawnState(ISwitcher switcher,
            EntryPointState entryPoint,
            ILevelLoader levelLoader,
            PauseHandler pauseHandler,
            IInventory inventory,
            IResourceService resourceService,
            CharacterHolder characterHolder) : base(switcher, entryPoint, inventory, resourceService)
        {
            _levelLoader = levelLoader;
            _pauseHandler = pauseHandler;
            _characterHolder = characterHolder;
        }

        public override void Enter()
        {
            base.Enter();

            EntryPoint.LossScreen.Close();
            _levelLoader.Load(EntryPoint.LevelSelected.GetCurrentLevel());
            _pauseHandler.Remove(EntryPoint.LossScreen);
            _characterHolder.Character.CharacterModel.gameObject.SetActive(true);
            _characterHolder.Character.Health.ResetHealth();
            Switcher.SwitchState<StartLevelState>();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
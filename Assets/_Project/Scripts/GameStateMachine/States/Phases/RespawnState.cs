using Assets.Scripts.Service.LevelLoaderService.Loader;
using Assets.Scripts.GameStateMachine.States.Runtime;
using Assets.Scripts.Player.Inventory;
using Assets.Scripts.Service.Pause;
using Assets.Scripts.Player.Core;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Items;
using Assets.Scripts.UseCase;

namespace Assets.Scripts.GameStateMachine.States.Phases
{
    public class RespawnState : PhasesState
    {
        private PauseHandler _pauseHandler;
        private ICharacterHolder _characterHolder;

        public RespawnState(
            ISwitcher switcher,
            EntryPointState entryPoint,
            PauseHandler pauseHandler,
            IInventory inventory,
            IResourceService resourceService,
            ICharacterHolder characterHolder,
            SceneTransitions sceneTransitions)
            : base(switcher, entryPoint, inventory, resourceService, sceneTransitions)
        {
            _pauseHandler = pauseHandler;
            _characterHolder = characterHolder;
        }

        public override void Enter()
        {
            base.Enter();

            EntryPoint.LossScreen.Close();
            SceneTransitions.GetCurrentLevel();
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
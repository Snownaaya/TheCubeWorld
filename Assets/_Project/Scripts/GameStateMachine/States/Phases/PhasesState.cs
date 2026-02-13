using Assets.Scripts.Interfaces;
using Assets.Scripts.Items;
using Assets.Scripts.Player.Inventory;
using Assets.Scripts.Service.GameMessage;
using Assets.Scripts.UseCase;
using TMPro;

namespace Assets.Scripts.GameStateMachine.States.Phases
{
    public abstract class PhasesState : BaseGameState
    {
        private IInventory _inventory;
        private IResourceService _resourceService;
        private SceneTransitions _transitions;

        protected PhasesState(
            ISwitcher switcher,
            EntryPointState entryPoint,
            IInventory inventory,
            IResourceService resourceService,
            SceneTransitions sceneTransitions)
            : base(switcher, entryPoint)
        {
            _inventory = inventory;
            _resourceService = resourceService;
            _transitions = sceneTransitions;
        }

        public IInventory Inventory => _inventory;

        public IResourceService ResourceService => _resourceService;

        public SceneTransitions SceneTransitions => _transitions;

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

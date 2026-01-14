using Assets.Scripts.Interfaces;
using Assets.Scripts.Items;
using Assets.Scripts.Player.Inventory;

namespace Assets.Scripts.GameStateMachine.States.Phases
{
    public abstract class PhasesState : BaseGameState
    {
        private IInventory _inventory;
        private IResourceService _resourceService;

        protected PhasesState(
            ISwitcher switcher,
            EntryPointState entryPoint,
            IInventory inventory,
            IResourceService resourceService) : base(switcher, entryPoint)
        {
            _inventory = inventory;
            _resourceService = resourceService;
        }

        public override void Enter()
        {
            base.Enter();

            _inventory.Reset();
            _resourceService.Clear();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}

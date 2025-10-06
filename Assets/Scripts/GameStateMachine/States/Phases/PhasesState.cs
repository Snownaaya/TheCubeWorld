using Assets.Scripts.Interfaces;
using Assets.Scripts.Player.Inventory;

namespace Assets.Scripts.GameStateMachine.States.Phases
{
    public abstract class PhasesState : BaseGameState
    {
        private IInventory _inventory;

        protected PhasesState(ISwitcher switcher,
            EntryPointState entryPoint,
            IInventory inventory) : base(switcher, entryPoint)
        {
            _inventory = inventory;
        }

        public override void Enter()
        {
            base.Enter();

            _inventory.Reset();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}

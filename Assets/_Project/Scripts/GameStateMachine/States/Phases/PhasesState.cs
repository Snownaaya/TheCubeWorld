namespace Assets.Scripts.GameStateMachine.States.Phases
{
    using Assets.Scripts.Interfaces;
    using Assets.Scripts.Items;
    using Assets.Scripts.Player.Inventory;
    using Assets.Scripts.UseCase;

    public abstract class PhasesState : BaseGameState
    {
        private IInventory _inventory;
        private IResourceService _resourceService;
        private SceneTransitions _transitions;
        private GameEntryPointState _gameEntryPointState;

        protected PhasesState(
            ISwitcher switcher,
            IInventory inventory,
            IResourceService resourceService,
            SceneTransitions sceneTransitions,
            GameEntryPointState gameEntryPointState)
            : base(switcher)
        {
            _inventory = inventory;
            _resourceService = resourceService;
            _transitions = sceneTransitions;
            _gameEntryPointState = gameEntryPointState;
        }

        public IInventory Inventory => _inventory;

        public IResourceService ResourceService => _resourceService;

        public SceneTransitions SceneTransitions => _transitions;

        public GameEntryPointState GameEntryPointState => _gameEntryPointState;

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
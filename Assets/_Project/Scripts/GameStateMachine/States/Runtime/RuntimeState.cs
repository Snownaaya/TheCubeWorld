namespace Assets.Scripts.GameStateMachine.States.Runtime
{
    using Assets.Scripts.GameStateMachine.States.Phases;
    using Assets.Scripts.Interfaces;
    using Assets.Scripts.Items;
    using Assets.Scripts.Player.Attack;
    using Assets.Scripts.Player.Core;
    using Assets.Scripts.Service.GameMessage;
    using UniRx;

    public abstract class RuntimeState : BaseGameState
    {
        private ICharacterHolder _characterHolder;
        private GameMessageBus _messageBus;
        private IResourceService _resourceService;
        private CompositeDisposable _compositeDisposable = new CompositeDisposable();

        protected RuntimeState(
            ISwitcher switcher,
            GameEntryPointState gameEntryPointState,
            ICharacterHolder characterHolder,
            GameMessageBus gameMessageBus,
            IResourceService resource)
            : base(switcher)
        {
            _characterHolder = characterHolder;
            _messageBus = gameMessageBus;
            _resourceService = resource;
        }

        public override void Enter()
        {
            base.Enter();

            _messageBus.MessageBroker
                .Receive<NotEnoughResourcesEvent>()
                .Subscribe(enough => OnNotEnoughResources(enough))
                .AddTo(_compositeDisposable);

            _resourceService.Clear();
            _characterHolder.Character.Health.Died += OnPLayerDeath;
        }

        public override void Exit()
        {
            base.Exit();

            _characterHolder.Character.Health.Died -= OnPLayerDeath;
            _compositeDisposable.Dispose();
        }

        private void OnPLayerDeath(ILoss loss) =>
            Switcher.SwitchState<LossState>();

        private void OnNotEnoughResources(NotEnoughResourcesEvent enough) =>
            Switcher.SwitchState<LossState>();
    }
}
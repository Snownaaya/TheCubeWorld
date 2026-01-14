using Assets.Scripts.GameStateMachine.States.Phases;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Player.Attack;
using Assets.Scripts.Player.Core;
using Assets.Scripts.Service.GameMessage;
using UniRx;

namespace Assets.Scripts.GameStateMachine.States.Runtime
{
    public abstract class RuntimeState : BaseGameState
    {
        private CharacterHolder _characterHolder;
        private GameMessageBus _messageBus;
        private CompositeDisposable _compositeDisposable = new CompositeDisposable();

        protected RuntimeState(
            ISwitcher switcher,
            EntryPointState entryPoint,
            CharacterHolder characterHolder,
            GameMessageBus gameMessageBus) : base(switcher, entryPoint)
        {
            _characterHolder = characterHolder;
            _messageBus = gameMessageBus;
        }

        public override void Enter()
        {
            base.Enter();

            _messageBus.MessageBroker
                .Receive<NotEnoughResourcesEvent>()
                .Subscribe(enough => OnNotEnoughResources(enough))
                .AddTo(_compositeDisposable);

            _characterHolder.Character.Health.Died += OnPLayerDeath;
        }

        public override void Exit()
        {
            base.Exit();

            _characterHolder.Character.Health.Died -= OnPLayerDeath;
           // _compositeDisposable.Dispose();
        }

        private void OnPLayerDeath(ILoss loss) =>
            Switcher.SwitchState<LossState>();

        private void OnNotEnoughResources(NotEnoughResourcesEvent enough) =>
            Switcher.SwitchState<LossState>();
    }
}
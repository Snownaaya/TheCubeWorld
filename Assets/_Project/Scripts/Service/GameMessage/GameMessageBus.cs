namespace Assets.Scripts.Service.GameMessage
{
    using UniRx;

    public struct GameMessageBus
    {
        public IMessageBroker MessageBroker { get; private set; }

        public GameMessageBus(IMessageBroker messageBroker) =>
            MessageBroker = messageBroker;
    }
}
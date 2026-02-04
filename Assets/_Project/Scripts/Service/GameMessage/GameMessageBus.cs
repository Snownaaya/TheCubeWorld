using UniRx;

namespace Assets.Scripts.Service.GameMessage
{
    public struct GameMessageBus
    {
        public IMessageBroker MessageBroker { get; private set; }

        public GameMessageBus(IMessageBroker messageBroker) =>
            MessageBroker = messageBroker;
    }
}
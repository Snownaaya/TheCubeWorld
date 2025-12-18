using Assets.Scripts.Items;

namespace Assets.Scripts.Player.Attack
{
    public readonly struct NotEnoughResourcesEvent
    {
        public readonly ResourceTypes ResourceType;

        public NotEnoughResourcesEvent(ResourceTypes resourceType) =>
            ResourceType = resourceType;
    }
}
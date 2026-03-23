namespace Assets.Scripts.Player.Attack
{
    using Assets.Scripts.Items;

    public readonly struct NotEnoughResourcesEvent
    {
        public readonly ResourceTypes ResourceType;

        public NotEnoughResourcesEvent(ResourceTypes resourceType) =>
            ResourceType = resourceType;
    }
}
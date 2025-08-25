namespace Assets.Scripts.Items
{
    public interface IResourceStorage
    {
        public void AddResource(Resource resource);
        public void RemoveResource(ResourceTypes resourceType, int amount);
        public Resource GetResource(ResourceTypes resourceType);
    }
}
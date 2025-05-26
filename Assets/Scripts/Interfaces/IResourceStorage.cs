using Assets.Scripts.Items;

namespace Assets.Scripts.Interfaces
{
    public interface IResourceStorage
    {
        public void AddResource(Resource resource);
        public void RemoveResource(ResourceType resourceType, int amount);
        public Resource GetResource(ResourceType resourceType);
    }
}
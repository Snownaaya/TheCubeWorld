using Assets.Scripts.Items;

namespace Assets.Scripts.Interfaces
{
    public interface IResourceStorage
    {
        public void AddResource(Resource resource);
        public void RemoveResource(ResourceTypes resourceType, int amount);
        public Resource GetResource(ResourceTypes resourceType);
    }
}
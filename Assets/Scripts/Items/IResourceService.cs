using System.Collections;

namespace Assets.Scripts.Items
{
    public interface IResourceService
    {
        public IEnumerator SpawnRoutine(Assets.Scripts.Ground.Ground currentGround);
        void ReturnResource(Resource resource);
        Resource Pull(Resource prefab);
        void Push(Resource resource);
        public void ClearPool();
    }
}

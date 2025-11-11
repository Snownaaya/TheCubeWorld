using Cysharp.Threading.Tasks;
using System.Threading;

namespace Assets.Scripts.Items
{
    public interface IResourceService
    {
        public Resource Pull(Resource prefab);
        public void Push(Resource resource);
        public UniTask SpawnRoutine(Assets.Scripts.Ground.Ground currentGround, CancellationToken cancellationToken);
        public void ReturnResource(Resource resource);
        public void ReturnAllPool();
    }
}
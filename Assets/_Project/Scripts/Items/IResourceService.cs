namespace Assets.Scripts.Items
{
    using System.Collections.Generic;
    using System.Threading;
    using Cysharp.Threading.Tasks;

    public interface IResourceService
    {
        public List<Resource> ActiveResources { get; }

        public Resource Pull(Resource prefab);

        public void Push(Resource resource);

        public UniTask SpawnRoutine(Ground.Ground currentGround, CancellationToken cancellationToken);

        public void ReturnResource(Resource resource);

        public void Clear();
    }
}
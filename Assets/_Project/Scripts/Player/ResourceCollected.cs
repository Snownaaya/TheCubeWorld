namespace Assets.Scripts.Player
{
    using Assets.Scripts.Items;
    using Assets.Scripts.Particles;
    using Assets.Scripts.Player.Inventory;
    using Assets.Scripts.Service.Audio;
    using Reflex.Attributes;
    using UnityEngine;

    public class ResourceCollected : MonoBehaviour
    {
        private IInventory _playerInventory;
        private IResourceService _resourceSpawner;
        private IParticleSpawner _particleSpawner;
        private ForegroundAudioService _foregroundAudioService;

        [Inject]
        private void Construct(
            IResourceService resourceSpawner,
            IInventory inventory,
            IParticleSpawner particleSpawner,
            ForegroundAudioService foregroundAudioService)
        {
            _resourceSpawner = resourceSpawner;
            _playerInventory = inventory;
            _particleSpawner = particleSpawner;
            _foregroundAudioService = foregroundAudioService;

            _particleSpawner.Initialize(transform);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Resource resource))
            {
                _foregroundAudioService.PlaySound(AudioTypes.ResourceCollected);
                _particleSpawner.SpawnParticle(ParticleTypes.CollectResource, transform.position);
                _resourceSpawner.ReturnResource(resource);
                _playerInventory.AddResource(resource);
            }
        }
    }
}
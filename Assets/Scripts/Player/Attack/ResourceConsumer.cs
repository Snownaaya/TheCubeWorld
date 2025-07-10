using Assets.Scripts.GameStateMachine.States;
using Assets.Scripts.Enemies.Boss;
using Random = UnityEngine.Random;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Items;
using Assets.Scripts.UI;
using Reflex.Attributes;
using UnityEngine;
using System;

namespace Assets.Scripts.Player.Attack
{
    public class ResourceConsumer : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private Resource[] _resourcePrefabs;
        [SerializeField] private ResourceType[] _resourceType;
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private ResourceMediator _resourceMediator;

        [Header("Dependencies")]
        [SerializeField] private ResourceSpawner _resource;
        [SerializeField] private BossTarget _bossTarget;

        private IResourceStorage _resourceStorage;
        private IInventory _inventory;
        private ISwitcher _switcher;

        public ResourceSpawner ResourceSpawner => _resource;
        private int _resourceCount = 20;

        [Inject]
        private void Construct(IInventory inventory, IResourceStorage resourceStorage, ISwitcher switcher)
        {
            _inventory = inventory;
            _resourceStorage = resourceStorage;
            _switcher = switcher;
        }

        public bool TryConsumeResource()
        {
            ResourceType selectedConfig = (ResourceType)Random.Range(0, Enum.GetValues(typeof(ResourceType)).Length);

            //if (_inventory.HasResource(selectedConfig, new NotLessZeroProperty<int>(0)) == false)
            //{
            //    //_switcher.SwitchState<LossState>();
            //    return false;
            //}

            SpawnResource(selectedConfig);
            _inventory.UseResource(selectedConfig);
            _resourceStorage.RemoveResource(selectedConfig, 1);

            return true;
        }

        private void SpawnResource(ResourceType resourceType)
        {
            int prefabIndex = Random.Range(0, _resourcePrefabs.Length);
            Resource resource = _resourcePrefabs[prefabIndex];
            Resource resourcePrefab = _resource.Pull(resource);

            resourcePrefab.transform.position = _attackPoint.transform.position;
            resourcePrefab.transform.rotation = _attackPoint.transform.rotation;

            resourcePrefab.PrepareForThrow();
            resourcePrefab.MovePosition(_bossTarget);
            resourcePrefab.Release();
        }
    }
}
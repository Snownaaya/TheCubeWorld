using UnityEngine;
using Assets.Scripts.UI;
using Assets.Scripts.Interfaces;
using Reflex.Attributes;

[RequireComponent(typeof(Character))]
public class ResourceCollected : MonoBehaviour
{
    [SerializeField] private ResourceSpawner _resourceSpawner;
    [SerializeField] private ResourceMediator _resourceMediator;

    IResourceStorage _resourceStorage;

    [Inject]
    private void Construct(IResourceStorage resourceStorage) =>
        _resourceStorage = resourceStorage;

    private Character _character;

    private void Awake() =>
        _character = GetComponent<Character>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Resource resource))
        {
            _resourceMediator.Initialize(_character.PlayerInventory);
            _resourceStorage.AddResource(resource);
            _resourceSpawner.ReturnResource(resource);
            _character.PlayerInventory.AddResource(resource);
        }
    }
}
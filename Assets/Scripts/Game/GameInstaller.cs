using UnityEngine;
using Reflex.Core;
using Assets.Scripts.Items;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Player;

public class GameInstaller : MonoBehaviour, IInstaller
{
    [SerializeField] private ResourceStorage _resourceStorage;

    private IInventory _inventory;

    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        BindResourceStorage(containerBuilder);
        BindInventory(containerBuilder);
    }

    private void BindResourceStorage(ContainerBuilder containerBuilder)
    {
        containerBuilder.AddSingleton(_resourceStorage, typeof(IResourceStorage));
    }

    private void BindInventory(ContainerBuilder containerBuilder) =>
        containerBuilder.AddSingleton(new PlayerInventory(), typeof(IInventory));
}
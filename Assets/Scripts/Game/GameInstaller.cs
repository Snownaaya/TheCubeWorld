using UnityEngine;
using Reflex.Core;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Player;
using Assets.Scripts.Other;
using Assets.Scripts.LevelLoader.Loader;
using Assets.Scripts.Items;
using Assets.Scripts.Ground;

public class GameInstaller : MonoBehaviour, IInstaller
{
    [SerializeField] private ResourceStorage _resourceStorage;

    private IInventory _inventory;
    private ILevelLoader _levelLoader;

    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        BindResourceStorage(containerBuilder);
        BindInventory(containerBuilder);
        BindLevelLoader(containerBuilder);
        BindPauseHandler(containerBuilder);
    }

    private void BindResourceStorage(ContainerBuilder containerBuilder)
    {
        containerBuilder.AddSingleton(_resourceStorage, typeof(IResourceStorage));
    }

    private void BindInventory(ContainerBuilder containerBuilder) =>
        containerBuilder.AddSingleton(new PlayerInventory(), typeof(IInventory));

    private void BindLevelLoader(ContainerBuilder containerBuilder) =>
     containerBuilder.AddSingleton(new LevelLoader(), typeof(ILevelLoader));

    private void BindPauseHandler(ContainerBuilder containerBuilder) =>
       containerBuilder.AddSingleton(new PauseHandler(), typeof(PauseHandler));
}
using UnityEngine;
using Reflex.Core;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Other;
using Assets.Scripts.LevelLoader.Loader;
using Assets.Scripts.Items;
using Assets.Scripts.LevelLoader;
using Assets.Scripts.Player.Inventory;
using Assets.Scripts.Saves;
using Assets.Scripts.Json;

public class GameInstaller : MonoBehaviour, IInstaller
{
    [SerializeField] private ResourceStorage _resourceStorage;

    //private void Awake() =>
    //    DontDestroyOnLoad(gameObject);

    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        BindResourceStorage(containerBuilder);
        BindInventory(containerBuilder);
        BindLevelLoader(containerBuilder);
        BindPauseHandler(containerBuilder);
    }

    private void BindResourceStorage(ContainerBuilder containerBuilder) =>
        containerBuilder.AddSingleton(_resourceStorage, typeof(IResourceStorage));

    private void BindInventory(ContainerBuilder containerBuilder)
    {
        SaveServiceFactory factory = new SaveServiceFactory();
        var jsonService = factory.CreateJsonService();
        var saveService = factory.CreateSaveService();
        InventorySaver inventorySaver = new InventorySaver(jsonService, saveService);
        containerBuilder.AddSingleton(new PlayerInventory(inventorySaver), typeof(IInventory));
    }

    private void BindLevelLoader(ContainerBuilder containerBuilder) =>
     containerBuilder.AddSingleton(new LevelLoader(), typeof(ILevelLoader));

    private void BindPauseHandler(ContainerBuilder containerBuilder) =>
       containerBuilder.AddSingleton(new PauseHandler(), typeof(PauseHandler));
}
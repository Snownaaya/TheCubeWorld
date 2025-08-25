using Assets.Scripts.Items;
using Reflex.Core;
using UnityEngine;

public class GameInstaller : MonoBehaviour, IInstaller
{
    [SerializeField] private ResourceStorage _resourceStorage;

    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        BindResourceStorage(containerBuilder);
    }

    private void BindResourceStorage(ContainerBuilder containerBuilder) =>
        containerBuilder.AddSingleton(_resourceStorage, typeof(IResourceStorage));
}
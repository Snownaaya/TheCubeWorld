using Assets.Scripts.Service.LevelLoaderService.Loader;
using Assets.Scripts.Service.LevelLoaderService;
using Assets.Scripts.Service.CharacterService;
using Assets.Scripts.Service.Pause;
using Assets.Scripts.Player;
using Reflex.Core;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class ServiceInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            BindPlayerSpawnService(containerBuilder);
            BindLevelLoader(containerBuilder);
            BindPauseHandler(containerBuilder);
        }

        private void BindPlayerSpawnService(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton<ICharacterTeleportService>(container =>
            {
                ITransformable player = container.Resolve<ITransformable>();
                IStartLevel startLevel = container.Resolve<IStartLevel>();
                return new CharacterTeleportService(player, startLevel);
            });
        }

        private void BindLevelLoader(ContainerBuilder containerBuilder) =>
         containerBuilder.AddSingleton(new LevelLoader(), typeof(ILevelLoader));

        private void BindPauseHandler(ContainerBuilder containerBuilder) =>
           containerBuilder.AddSingleton(new PauseHandler(), typeof(PauseHandler));
    }
}

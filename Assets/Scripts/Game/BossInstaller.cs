using Assets.Scripts.Enemies.Boss;
using Reflex.Core;

namespace Assets.Scripts.Game
{
    public class BossInstaller : IInstaller
    {
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton(new CurrentBossService(), typeof(IBossTargetService));
        }
    }
}
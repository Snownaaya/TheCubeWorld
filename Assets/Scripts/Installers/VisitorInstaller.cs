using Assets.Scripts.Datas;
using Assets.Scripts.Visitor;
using Reflex.Core;
using UnityEngine;

namespace Assets.Scripts.Installers
{
    public class VisitorInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            BindVisitor(containerBuilder);
            BindVisitorFactory(containerBuilder);
        }

        private void BindVisitor(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton<VisitorsHolder>(container =>
            {
                CharacterData characterData = container.Resolve<CharacterData>();
                return new VisitorsHolder(characterData);
            });
        }

        private void BindVisitorFactory(ContainerBuilder containerBuilder) =>
            containerBuilder.AddSingleton(new VisitorFactory());
    }
}
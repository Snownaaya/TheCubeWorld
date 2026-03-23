namespace Assets.Project.Scripts.Installers
{
    using Assets.Scripts.UI.MainMenu;
    using Reflex.Core;
    using UnityEngine;

    public class MainMenuInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private StartButton _startButton;

        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            BindStartButton(containerBuilder);
        }

        private void BindStartButton(ContainerBuilder containerBuilder) =>
            containerBuilder.AddSingleton(_startButton);
    }
}
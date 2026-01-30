using Assets.Scripts.Camera;
using Assets.Scripts.Datas.Character;
using Assets.Scripts.GameStateMachine;
using Assets.Scripts.Ground;
using Assets.Scripts.Input;
using Assets.Scripts.Interfaces;
using Cinemachine;
using Reflex.Core;
using UnityEngine;

namespace Assets.Scripts.Installers
{
    public class SceneInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private JoystickInput _joystickInput;
        [SerializeField] private FinalPlatform _finalPlatform;
        [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;

        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            BindSwitcher(containerBuilder);
            BindFinalPlatform(containerBuilder);
            BindVirtualCamera(containerBuilder);
            BindJoystick(containerBuilder);
            BindTransientData(containerBuilder);
        }

        private void BindSwitcher(ContainerBuilder containerBuilder) =>
            containerBuilder.AddSingleton(new GameState(), typeof(ISwitcher));

        private void BindFinalPlatform(ContainerBuilder containerBuilder) =>
            containerBuilder.AddSingleton(_finalPlatform);

        private void BindVirtualCamera(ContainerBuilder containerBuilder) =>
            containerBuilder.AddSingleton(new CinemachineTargetBinder(_cinemachineVirtualCamera),
                typeof(IVirtualCamera));

        private void BindTransientData(ContainerBuilder containerBuilder) =>
            containerBuilder.AddSingleton(new TransientCharacterData(), typeof(ITransientCharacterData));

        private void BindJoystick(ContainerBuilder containerBuilder)
        {
            if (_joystickInput == null)
                return;

            JoystickInput joystickInput = Instantiate(_joystickInput);
            joystickInput.SetInteractable(false);

            containerBuilder.AddSingleton(joystickInput, typeof(IJoystickInput));
        }
    }
}
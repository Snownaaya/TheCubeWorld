using Assets.Scripts.HealthCharacters;
using Assets.Scripts.Player.Inventory;
using Assets.Scripts.Player.Attack;
using Assets.Scripts.Player.Move;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Player;
using Assets.Scripts.Input;
using Assets.Scripts.Saves;
using Reflex.Core;
using UnityEngine;
using YG;

namespace Assets.Scripts.Game
{
    public class CharacterInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private CharacterAttacker _characterAttacker;
        [SerializeField] private Character _character;
        [SerializeField] private Movement _movement;

        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            PlayerInput playerInput = InitInput(containerBuilder);
            BindInventory(containerBuilder);
            BindDamageable(containerBuilder);
            InitMoveble(containerBuilder);
            BindTransformable(containerBuilder);
            BindInput(containerBuilder, playerInput);
        }

        private void BindInventory(ContainerBuilder containerBuilder)
        {
            SaveServiceFactory factory = new SaveServiceFactory();
            var jsonService = factory.CreateJsonService();
            var saveService = factory.CreateSaveService();
            InventorySaver inventorySaver = new InventorySaver(jsonService, saveService);
            containerBuilder.AddSingleton(new PlayerInventory(inventorySaver), typeof(IInventory));
        }

        private PlayerInput InitInput(ContainerBuilder containerBuilder)
        {
            var playerInput = new PlayerInput();
            containerBuilder.AddSingleton(playerInput);

            return playerInput;
        }

        private void BindDamageable(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton(_characterAttacker, typeof(IDamageable));
        }

        private void BindHealth(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddScoped(_ => _character,typeof(IHealth));
        }

        private void InitMoveble(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddScoped(typeof(IMoveble));
        }

        private void BindTransformable(ContainerBuilder containerBuilder) =>
            containerBuilder.AddSingleton(_character, typeof(ITransformable));

        private void BindInput(ContainerBuilder containerBuilder, PlayerInput playerInput)
        {
            if (YG2.envir.isDesktop)
            {
                DesktopInput desktopInput = new DesktopInput(playerInput);
                containerBuilder.AddSingleton(desktopInput, typeof(IInput));
            }
            else if (YG2.envir.isMobile)
            {
                MobileInput mobileInput = new MobileInput(playerInput);
                containerBuilder.AddSingleton(mobileInput, typeof(IInput));
            }
        }
    }
}

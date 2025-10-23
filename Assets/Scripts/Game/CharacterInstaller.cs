using Assets.Scripts.Player.Inventory;
using Assets.Scripts.Service.Saves;
using Assets.Scripts.Player.Wallet;
using Assets.Scripts.Service.Json;
using Assets.Scripts.Player.Core;
using Assets.Scripts.Datas;
using Assets.Scripts.Input;
using Reflex.Injectors;
using Reflex.Core;
using UnityEngine;
using YG;

namespace Assets.Scripts.Game
{
    public class CharacterInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private CharacterFactory _characterFactory;

        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            PlayerInput playerInput = InitInput(containerBuilder);
            BindInput(containerBuilder, playerInput);
            BindInventory(containerBuilder);
            BindFactory(containerBuilder, playerInput);
            BindCharacterData(containerBuilder);
            BindWallet(containerBuilder);
            BindCharacterHolder(containerBuilder);
        }

        private void BindWallet(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton<IWallet>(container =>
            {
                IJsonService jsonService = container.Resolve<IJsonService>();
                ISaveService saveService = container.Resolve<ISaveService>();
                CharacterData characterData = container.Resolve<CharacterData>();

                WalletSaver walletSaver = new WalletSaver(jsonService, saveService);
                return new CharacterWallet(characterData, walletSaver);
            });
        }

        private void BindInventory(ContainerBuilder containerBuilder) =>
            containerBuilder.AddSingleton(new PlayerInventory(), typeof(IInventory));

        private PlayerInput InitInput(ContainerBuilder containerBuilder)
        {
            var playerInput = new PlayerInput();
            containerBuilder.AddSingleton(playerInput);

            return playerInput;
        }

        private void BindCharacterData(ContainerBuilder containerBuilder) =>
            containerBuilder.AddSingleton(new CharacterData());

        private void BindCharacterHolder(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton<CharacterHolder>(container =>
            {
                CharacterFactory factory = container.Resolve<CharacterFactory>();
                CharacterHolder holder = factory.CreateCharacter();

                GameObjectInjector.InjectRecursive(holder.Character.gameObject, container);
                return holder;
            });
        }

        private void BindFactory(ContainerBuilder containerBuilder, PlayerInput playerInput)
        {
            containerBuilder.AddSingleton<CharacterFactory>(container =>
            {
                GameObjectInjector.InjectRecursive(_characterFactory.gameObject, container);
                containerBuilder.AddSingleton(_characterFactory);

                return _characterFactory;
            });
        }

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
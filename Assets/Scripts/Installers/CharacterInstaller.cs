using Assets.Scripts.Player.Inventory;
using Assets.Scripts.Service.Saves;
using Assets.Scripts.Player.Wallet;
using Assets.Scripts.Service.Json;
using Assets.Scripts.Player.Core;
using Assets.Scripts.Player.Saves;
using Assets.Scripts.Input;
using Reflex.Injectors;
using Reflex.Core;
using UnityEngine;
using YG;
using Assets.Scripts.Datas.Character;

namespace Assets.Scripts.Installers
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
            BindWallet(containerBuilder);
            BindCharacterHolder(containerBuilder);
            BindCharacterSave(containerBuilder);
        }

        private void BindWallet(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton<IWallet>(container =>
            {
                IPersistentCharacterData characterData = container.Resolve<IPersistentCharacterData>();
                return new CharacterWallet(characterData);
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

        private void BindCharacterSave(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton<ICharacterSaveRepository>(container =>
            {
                IJsonService jsonService = container.Resolve<IJsonService>();
                ISaveService saveService = container.Resolve<ISaveService>();

                return new CharacterSaveRepository(jsonService, saveService);
            });
        }
    }
}
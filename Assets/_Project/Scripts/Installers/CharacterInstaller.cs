namespace Assets.Scripts.Installers
{
    using Assets.Scripts.Datas.Character;
    using Assets.Scripts.Input;
    using Assets.Scripts.Player.Core;
    using Assets.Scripts.Player.Inventory;
    using Assets.Scripts.Player.Saves;
    using Assets.Scripts.Player.Wallet;
    using Assets.Scripts.Service.GameMessage;
    using Assets.Scripts.Service.Json;
    using Assets.Scripts.Service.Saves;
    using Reflex.Core;
    using Reflex.Injectors;
    using UnityEngine;
    using YG;

    public class CharacterInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private CharacterFactory _characterFactory;
        [SerializeField] private JoystickInput _joystickInput;

        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            PlayerInput playerInput = InitInput(containerBuilder);
            BindMobileJoystick(containerBuilder, playerInput);
            BindDesktopInput(containerBuilder, playerInput);
            BindInventory(containerBuilder);
            BindFactory(containerBuilder, playerInput);
            BindWallet(containerBuilder);
            BindCharacterHolder(containerBuilder);
            BindCharacterSave(containerBuilder);
            BindCharacterLinker(containerBuilder);
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
            containerBuilder.AddSingleton<ICharacterHolder>(container =>
            {
                CharacterFactory factory = container.Resolve<CharacterFactory>();

                ICharacterHolder holder = factory.CreateCharacter();

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

        private void BindDesktopInput(ContainerBuilder containerBuilder, PlayerInput playerInput)
        {
            if (YG2.envir.isDesktop)
            {
                containerBuilder.AddSingleton<IInput>(container =>
                {
                    return new DesktopInput(playerInput);
                });
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

        private void BindCharacterLinker(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton<CharacterPersistentLinker>(container =>
            {
                ICharacterSaveRepository characterSaveRepository = container.Resolve<ICharacterSaveRepository>();
                IPersistentCharacterData persistentCharacterData = container.Resolve<IPersistentCharacterData>();

                GameMessageBus gameMessageBus = container.Resolve<GameMessageBus>();

                return new CharacterPersistentLinker(characterSaveRepository, persistentCharacterData, gameMessageBus);
            });
        }

        private void BindMobileJoystick(ContainerBuilder containerBuilder, PlayerInput playerInput)
        {
            containerBuilder.AddSingleton<IJoystickInput>(container =>
            {
                if (YG2.envir.isMobile)
                {
                    JoystickInput joystickInstance = Instantiate(_joystickInput);
                    GameObjectInjector.InjectRecursive(joystickInstance.gameObject, container);
                    DontDestroyOnLoad(joystickInstance);
                    return joystickInstance;
                }
                else
                {
                    return new NullJoystickInput();
                }
            });
            if (YG2.envir.isMobile)
            {
                containerBuilder.AddSingleton<IInput>(container =>
                {
                    IJoystickInput joystickInput = container.Resolve<IJoystickInput>();
                    return new MobileInput(playerInput, joystickInput);
                });
            }
        }
    }
}
using Assets.Scripts.Datas.Character;
using Assets.Scripts.Player.Saves;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.Initialize
{
    public class GameBootstrap : MonoBehaviour
    {
        private ICharacterSaveRepository _characterSaveRepository;
        private CharacterPersistentLinker _persistentLinker;
        private IPersistentCharacterData _persistentCharacterData;

        [Inject]
        private void Construct(
            ICharacterSaveRepository characterSaveRepository,
            CharacterPersistentLinker persistentLinker,
            IPersistentCharacterData persistentCharacterData)
        {
            _characterSaveRepository = characterSaveRepository;
            _persistentLinker = persistentLinker;
            _persistentCharacterData = persistentCharacterData;
        }

        private void Start()
        {
            _persistentLinker.Link();
            _persistentCharacterData.Initialize();

            DontDestroyOnLoad(this.gameObject);
        }

        private void OnDestroy()
        {
            _persistentCharacterData.Dispose();
            _persistentLinker?.Dispose();
        }
    }
}
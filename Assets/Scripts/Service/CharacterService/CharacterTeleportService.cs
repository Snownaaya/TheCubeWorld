using Assets.Scripts.Player;
using Assets.Scripts.Service.LevelLoaderService;
using Reflex.Attributes;

namespace Assets.Scripts.Service.CharacterService
{
    public class CharacterTeleportService : ICharacterTeleportService
    {
        private ITransformable _player;
        private IStartLevel _startLevel;

        public CharacterTeleportService(ITransformable player, IStartLevel startLevel)
        {
            _player = player;
            _startLevel = startLevel;
        }

        public void SpawnAtStart()
        {
            _player.CharacterModel.position = _startLevel.Transform.position;
            _player.CharacterModel.rotation = _startLevel.Transform.rotation;
        }
    }
}
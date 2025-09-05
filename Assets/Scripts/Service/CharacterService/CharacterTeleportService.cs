using Assets.Scripts.Service.LevelLoaderService;
using Assets.Scripts.Player.Core;

namespace Assets.Scripts.Service.CharacterService
{
    public class CharacterTeleportService : ICharacterTeleportService
    {
        private CharacterHolder _player;
        private IStartLevel _startLevel;

        public CharacterTeleportService(CharacterHolder player, IStartLevel startLevel)
        {
            _player = player;
            _startLevel = startLevel;
        }

        public void SpawnAtStart()
        {
            _player.Movement.CharacterModel.position = _startLevel.Transform.position;
            _player.Movement.CharacterModel.rotation = _startLevel.Transform.rotation;
        }
    }
}
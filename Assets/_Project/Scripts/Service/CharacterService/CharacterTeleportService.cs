namespace Assets.Scripts.Service.CharacterService
{
    using Assets.Scripts.Player.Core;
    using Assets.Scripts.Service.LevelLoaderService;

    public class CharacterTeleportService : ICharacterTeleportService
    {
        private ICharacterHolder _player;
        private IStartLevel _startLevel;

        public CharacterTeleportService(
            ICharacterHolder player,
            IStartLevel startLevel)
        {
            _player = player;
            _startLevel = startLevel;
        }

        public void SpawnAtStart()
        {
            _player.Movement.CharacterModel.position = _startLevel.Transform.position;
            _player.Movement.CharacterModel.rotation = _startLevel.Transform.rotation;
            _player.Character.gameObject.SetActive(true);
        }
    }
}
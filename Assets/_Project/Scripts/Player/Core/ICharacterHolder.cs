namespace Assets.Scripts.Player.Core
{
    using Assets.Scripts.Player.Attack;
    using Assets.Scripts.Player.Move;

    public interface ICharacterHolder
    {
        public Character Character { get; }

        public Movement Movement { get; }

        public CharacterAttacker Attacker { get; }

        public SkinChanger SkinChanger { get; }

        public void Initialize(
           Character characterAttacker,
           Movement movement,
           CharacterAttacker attacker,
           SkinChanger skinChanger);
    }
}
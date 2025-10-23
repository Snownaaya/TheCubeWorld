using Assets.Scripts.Player.Attack;
using Assets.Scripts.Player.Move;

namespace Assets.Scripts.Player.Core
{
    public class CharacterHolder
    {
        public Character Character { get; private set; }
        public Movement Movement { get; private set; }
        public CharacterAttacker Attacker { get; private set; }

        public bool Initilized => Character != null && Movement != null && Attacker != null;

        public void Initialize(Character characterAttacker,
            Movement movement,
            CharacterAttacker attacker)
        {
            Character = characterAttacker;
            Movement = movement;
            Attacker = attacker;

            if (Initilized == false)
                throw new System.Exception("CharacterHolder not initialized properly");
        }
    }
}

using Assets.Scripts.Enemies.Boss.Target;
using Assets.Scripts.Particles;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public interface ICharacterView
    {
        public void StartIdle();
        public void StopIdle();
        public void StartWalk();
        public void StopWalk();
        public void StartAttack();
        public void StopAttack();
    }
}
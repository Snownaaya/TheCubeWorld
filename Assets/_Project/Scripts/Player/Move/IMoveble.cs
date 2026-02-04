using UnityEngine;

namespace Assets.Scripts.Player.Move
{
    public interface IMoveble
    {
        public void OnMove(Vector3 direction);
        public void StopMove();
    }
}
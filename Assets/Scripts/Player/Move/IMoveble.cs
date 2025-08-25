using UnityEngine;

namespace Assets.Scripts.Player.Move
{
    public interface IMoveble : ITransformable
    {
        public void OnMove(Vector3 direction);
        public void StopMove();
    }
}
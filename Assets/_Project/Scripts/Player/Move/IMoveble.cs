namespace Assets.Scripts.Player.Move
{
    using UnityEngine;

    public interface IMoveble
    {
        public void Enable();

        public void Disable();

        public void OnMove(Vector3 direction);

        public void StopMove();
    }
}
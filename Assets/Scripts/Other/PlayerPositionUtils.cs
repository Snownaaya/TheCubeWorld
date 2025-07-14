using UnityEngine;

namespace Assets.Scripts.Other
{
    public static class PlayerPositionUtils
    {
        private static Character _character;

//#if UNITY_EDITOR
        public static Vector3 GetPlayerPosition()
        {
            Character character = GetPlayer();
            Vector3 position = character.transform.position;
            return position;
        }
//#endif

//#if UNITY_EDITOR
        private static Character GetPlayer()
        {
            if(_character == null)
                _character = Object.FindObjectOfType<Character>();

            return _character;
        }
//#endif
    }
}
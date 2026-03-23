namespace Assets.Scripts.Enemies.Obstacles.Patrollers
{
    using System.Collections.Generic;
    using UnityEngine;

    public class PatrollerStopper : MonoBehaviour
    {
        [SerializeField] private List<Patroller> _patrollers = new();

        public void ObstacleStopped(ObstacleTypes obstacleTypes)
        {
            foreach (Patroller patroller in _patrollers)
            {
                if (patroller.ObstacleTypes == obstacleTypes)
                    patroller.StopMove();
            }
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemies.Obstacles.Patrollers
{
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
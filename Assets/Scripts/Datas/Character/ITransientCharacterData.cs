using Assets.Scripts.Enemies.Obstacles;
using System.Collections.Generic;
using UnityEngine.Scripting;

namespace Assets.Scripts.Datas.Character
{
    [Preserve]
    public interface ITransientCharacterData
    {
        public IEnumerable<ObstacleTypes> OpenAbilities { get; }
        public ObstacleTypes SelectedAbility { get; set; }
        public void OpenAbility(ObstacleTypes obstacleTypes);
    }
}
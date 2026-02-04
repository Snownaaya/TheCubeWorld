using Assets.Scripts.Enemies.Obstacles;
using System.Collections.Generic;

namespace Assets.Scripts.Datas.Character
{
    public interface ITransientCharacterData
    {
        public IEnumerable<ObstacleTypes> OpenAbilities { get; }
        public ObstacleTypes SelectedAbility { get; set; }
        public void OpenAbility(ObstacleTypes obstacleTypes);
    }
}

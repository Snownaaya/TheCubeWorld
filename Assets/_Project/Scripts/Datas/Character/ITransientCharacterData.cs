namespace Assets.Scripts.Datas.Character
{
    using System.Collections.Generic;
    using Assets.Scripts.Enemies.Obstacles;

    public interface ITransientCharacterData
    {
        public IEnumerable<ObstacleTypes> OpenAbilities { get; }

        public ObstacleTypes SelectedAbility { get; set; }

        public void OpenAbility(ObstacleTypes obstacleTypes);
    }
}

using Assets.Scripts.Enemies.Obstacles;
using Assets.Scripts.Player.Skins;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Achievements.Observers
{
    public class AchievemntBuyObserver
    {
        //лист покупок, разщделающих достижения, и скины
        //в обсервере нужна коллекция на проверки, покупки скина или абилки, Add и Remove чтобы не допускать утчеки памяти
        //сам поле максимальных ачивок, покуа не понятно, разделять ли на скины и на абилки, (AbilityItem и SkinItem) по возможности, не усложняю ли я задачу
        // конструтор, с входнымит параметрами 
        // метод OnItemBuy(ShopItem item) - добавляет в лист покупок и запускает проверки с листом
        // создать сервис, который наследуется от интерфейса IAchievementObserverService,который будет отправлять в медиатор инфорацию о количестве покупок
        //все партиал скинуть в диайку, чтобы получить его в медиатор
        // насколько приемлемо ли по арзитектуре, кидать в медиатор, проверки количества покупок, или лучше сделать отдельный сервис, который будет заниматься только этим?
        //вызвать событие в двух разных магазинах, абилки и скинов, есть события, просто вызвать еего в медиаторе

        private HashSet<ObstacleTypes> _buySkinsCounts = new();
        private HashSet<CharacterSkins> _buyAbilityCounts = new();

        private int _maxSkinsBuyCount = 4;
        private int _maxAbilityBuyCount = 4;

        private IEnumerable<Action<HashSet<ObstacleTypes>>> _skinBuyCheckers;
        private IEnumerable<Action<HashSet<CharacterSkins>>> _abilityBuyCheckers;

        public AchievemntBuyObserver()
        {
            
        }

        public void OnSkinBuy(ObstacleTypes skinType)
        {
            _buySkinsCounts.Add(skinType);

            if (_buySkinsCounts.Count >= _maxSkinsBuyCount)
                _buySkinsCounts.Remove(skinType);

            foreach (Action<HashSet<ObstacleTypes>> skinCheck in _skinBuyCheckers)
                skinCheck(_buySkinsCounts);
        }

        public void OnAbilityBuy(CharacterSkins abilityType)
        {
            _buyAbilityCounts.Add(abilityType);

            if (_buyAbilityCounts.Count >= _maxAbilityBuyCount)
                _buyAbilityCounts.Remove(abilityType);

            foreach (Action<HashSet<CharacterSkins>> abilityCheck in _abilityBuyCheckers)
                abilityCheck(_buyAbilityCounts);
        }
    }
}
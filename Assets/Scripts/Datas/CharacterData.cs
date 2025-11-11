using Assets.Scripts.Service.Properties;
using Assets.Scripts.UI.Shop.CharacterSkin;
using System.Collections.Generic;

namespace Assets.Scripts.Datas
{
    public class CharacterData
    {
        private NotLessZeroProperty<int> _money;

        private List<CharacterSkins> _ownedSkins;

        public CharacterData()
        {
            _money = new NotLessZeroProperty<int>(1);
        }

        public NotLessZeroProperty<int> Money => _money;

        public void SetMoney(int value) => 
            _money.Value = value;

        public void OpenCharacterSkin()
        {

        }
    }
}
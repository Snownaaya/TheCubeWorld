using Assets.Scripts.Player;
using Assets.Scripts.Service.Properties;

namespace Assets.Scripts.Datas
{
    public class CharacterData
    {
        private NotLessZeroProperty<int> _money;

        public CharacterData()
        {
            
        }

        public NotLessZeroProperty<int> Money => _money;
    }
}

using Assets.Scripts.Service.Saves;
using Assets.Scripts.Service.Json;
using System.Collections.Generic;

namespace Assets.Scripts.Achievements
{
    public class AchievementDataRepository
    {
        private const string Achievements = nameof(Achievements);

        private readonly ISaveService _saveService;
        private readonly IJsonService _jsonService;

        public AchievementDataRepository(ISaveService saveService, IJsonService jsonService)
        {
            _saveService = saveService;
            _jsonService = jsonService;
        }

        public Dictionary<AchievementNames, bool> GetAchievements()
        {
            string json = _saveService.Load(Achievements);

            if (string.IsNullOrWhiteSpace(json))
                return new Dictionary<AchievementNames, bool>();

            return _jsonService.Deserialize<Dictionary<AchievementNames, bool>>(json);
        }

        public void SetAchievements(Dictionary<AchievementNames, bool> achievements)
        {
            string json = _jsonService.Serialize(achievements);
            _saveService.Save(Achievements, json);
        }
    }
}
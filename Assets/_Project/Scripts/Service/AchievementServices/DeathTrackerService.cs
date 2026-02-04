using Assets.Scripts.UI.HealthCharacters.Characters;
using Assets.Scripts.Achievements.Observers;

namespace Assets.Scripts.Service.AchievementServices
{
    public class DeathTrackerService : ICharacterDeathTracker
    {
        private AchievementDeathObserver _achievementDeathObserver;

        public DeathTrackerService(AchievementDeathObserver achievementDeathObserver) =>
            _achievementDeathObserver = achievementDeathObserver;

        public void Register(CharacterHealth health) =>
            health.Died += _achievementDeathObserver.OnPlayerDeath;

        public void Unregister(CharacterHealth health) =>
            health.Died -= _achievementDeathObserver.OnPlayerDeath;
    }
}
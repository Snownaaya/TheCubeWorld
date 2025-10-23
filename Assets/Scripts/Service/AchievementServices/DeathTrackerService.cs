using Assets.Scripts.HealthCharacters.Characters;
using Assets.Scripts.Achievements.Observers;

namespace Assets.Scripts.Service.AchievementServices
{
    public class DeathTrackerService : IAchievementTracker<CharacterHealth>
    {
        private AchievementDeathObserver _achievementDeathObserver;

        public DeathTrackerService(AchievementDeathObserver achievementDeathObserver) =>
            _achievementDeathObserver = achievementDeathObserver;

        public void Register(CharacterHealth health)
        {
            if (health.IsDead == true)
                health.Died += _achievementDeathObserver.OnPlayerDeath;
        }

        public void Unregister(CharacterHealth health)
        {
            if (health.IsDead == true)
                health.Died -= _achievementDeathObserver.OnPlayerDeath;
        }
    }
}
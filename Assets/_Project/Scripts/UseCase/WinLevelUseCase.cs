using Assets.Scripts.Achievements;

namespace Assets.Scripts.UseCase
{
    public class WinLevelUseCase
    {
        private readonly AchievementService _achievementService;

        public WinLevelUseCase(AchievementService achievementService) =>
            _achievementService = achievementService;

        public void Execute() =>
            _achievementService.Achieve(AchievementNames.Beginning);
    }
}
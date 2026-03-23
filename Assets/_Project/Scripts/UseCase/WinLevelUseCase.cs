namespace Assets.Scripts.UseCase
{
    using Assets.Scripts.Achievements;

    public class WinLevelUseCase
    {
        private readonly AchievementService _achievementService;

        public WinLevelUseCase(AchievementService achievementService) =>
            _achievementService = achievementService;

        public void Execute() =>
            _achievementService.Achieve(AchievementNames.Beginning);
    }
}
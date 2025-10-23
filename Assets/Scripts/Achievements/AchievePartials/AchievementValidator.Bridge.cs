using Assets.Scripts.Bridge.Factory;
using System.Collections.Generic;
using Assets.Scripts.Datas;
using Assets.Scripts.Items;
using System;

namespace Assets.Scripts.Achievements.AchievePartials
{
    public partial class AchievementValidator
    {
        private AchievementService _achievementService;

        public AchievementValidator(AchievementService achievementService) =>
            _achievementService = achievementService;

        private Action<Queue<BridgeData>> CreateChecker(int bridgesCount, Func<BridgeData, bool> isCorrectBridge, Action writeAchive)
        {
            return bridges =>
            {
                int count = bridgesCount;

                foreach (BridgeData bridge in bridges)
                {
                    if (isCorrectBridge(bridge) != true)
                        return;

                    if (--count == 0)
                    {
                        writeAchive();
                        return;
                    }
                }
            };
        }

        public List<Action<Queue<BridgeData>>> GetBridgeValidators()
        {
            return new List<Action<Queue<BridgeData>>>
            {
                CreateChecker
                (
                    bridgesCount: 3,
                    isCorrectBridge: bridge => bridge.ResourceTypes == ResourceTypes.Wood && bridge.BridgeType == BridgeType.Hard,
                    writeAchive: () => _achievementService.Achieve(AchievementNames.Aesthete)
                ),
                CreateChecker
                (
                   bridgesCount: 5,
                   isCorrectBridge: bridge => bridge.ResourceTypes == ResourceTypes.Stone && bridge.BridgeType == BridgeType.Hard,
                   writeAchive: () => _achievementService.Achieve(AchievementNames.Builder)
                ),
                CreateChecker
                (
                   bridgesCount: 9,
                   isCorrectBridge: bridge => bridge.ResourceTypes == ResourceTypes.Stone,
                   writeAchive: () => _achievementService.Achieve(AchievementNames.Bricklayer)
                ),
                CreateChecker
                (
                    bridgesCount: 6, 
                    isCorrectBridge: bridge => bridge.ResourceTypes == ResourceTypes.Dirt,
                    writeAchive: () => _achievementService.Achieve(AchievementNames.MudTycoon)
                ),
                CreateChecker
                (
                    bridgesCount: 10,
                    isCorrectBridge: bridge => bridge.ResourceTypes == ResourceTypes.Dirt,
                    writeAchive: () => _achievementService.Achieve(AchievementNames.Mud)
                )
            };
        }
    }
}

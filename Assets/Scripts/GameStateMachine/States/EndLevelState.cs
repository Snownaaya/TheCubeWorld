using Assets.Scripts.Service.LevelLoaderService.Loader;
using Random = UnityEngine.Random;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Items;
using System;

namespace Assets.Scripts.GameStateMachine.States
{
    public class EndLevelState : BaseGameState
    {
        private ILevelLoader _levelLoader;

        public EndLevelState(ISwitcher switcher,
            EntryPointState entryPoint,
            ILevelLoader levelLoader) : base(switcher, entryPoint)
        {
            _levelLoader = levelLoader;
        }

        public override void Enter()
        {
            base.Enter();

            ResourceTypes selectedConfig = (ResourceTypes)Random.Range(0, Enum.GetValues(typeof(ResourceTypes)).Length);
            _levelLoader.Load(EntryPoint.LevelSelected.GetNextLevel());
            EntryPoint.EndLevel.LevelEnded += Switcher.SwitchState<StartLevelState>;
        }

        public override void Exit()
        {
            base.Exit();

            EntryPoint.EndLevel.LevelEnded -= Switcher.SwitchState<StartLevelState>;
        }
    }
}
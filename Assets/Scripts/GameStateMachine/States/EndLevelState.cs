using Assets.Scripts.Interfaces;
using Assets.Scripts.Items;
using Random = UnityEngine.Random;
using System;

namespace Assets.Scripts.GameStateMachine.States
{
    public class EndLevelState : BaseGameState
    {
        public EndLevelState(ISwitcher switcher, EntryPointState entryPoint) : base(switcher, entryPoint) { }

        public override void Enter()
        {
            base.Enter();

            ResourceTypes selectedConfig = (ResourceTypes)Random.Range(0, Enum.GetValues(typeof(ResourceTypes)).Length);
            EntryPoint.LevelLoader.Load(EntryPoint.LevelSelected.GetNextLevel());
            EntryPoint.EndLevel.LevelEnded += Switcher.SwitchState<StartLevelState>;
        }

        public override void Exit()
        {
            base.Exit();

            EntryPoint.EndLevel.LevelEnded -= Switcher.SwitchState<StartLevelState>;
        }
    }
}
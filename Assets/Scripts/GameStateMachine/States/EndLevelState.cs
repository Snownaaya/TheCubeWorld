using Assets.Scripts.Interfaces;
using Assets.Scripts.Items;
using Random = UnityEngine.Random;
using System;

namespace Assets.Scripts.GameStateMachine.States
{
    public class EndLevelState : BaseGameState
    {
        public EndLevelState(ISwitcher switcher, EntryPoint flow) : base(switcher, flow) { }

        public override void Enter()
        {
            base.Enter();
            ResourceTypes selectedConfig = (ResourceTypes)Random.Range(0, Enum.GetValues(typeof(ResourceTypes)).Length);
            GameFlow.LevelLoader.Load(GameFlow.LevelSelected.GetNextLevel());
            GameFlow.EndLevel.LevelEnded += Switcher.SwitchState<StartLevelState>;
        }

        public override void Exit()
        {
            base.Exit();

            GameFlow.EndLevel.LevelEnded -= Switcher.SwitchState<StartLevelState>;
        }
    }
}

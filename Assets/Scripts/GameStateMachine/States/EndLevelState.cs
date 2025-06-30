using Assets.Scripts.Interfaces;
using System;

namespace Assets.Scripts.GameStateMachine.States
{
    public class EndLevelState : BaseGameState
    {
        private const string Level_1 = nameof(Level_1);

        public EndLevelState(ISwitcher switcher, GameFlow flow) : base(switcher, flow) { }

        public override void Enter()
        {
            base.Enter();

            GameFlow.EndLevel.LevelEnded += Switcher.SwitchState<StartLevelState>;
            //GameFlow.LevelLoader.Load(Level_1);
            GameFlow.LevelPool.SpawnLevel();
            GameFlow.StartLevel.gameObject.SetActive(false);
        }

        public override void Exit()
        {
            base.Exit();

            GameFlow.EndLevel.LevelEnded -= Switcher.SwitchState<StartLevelState>;
            //GameFlow.LevelPool.Push();
        }
    }
}

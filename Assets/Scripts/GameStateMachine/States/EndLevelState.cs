using Assets.Scripts.Interfaces;
using System;

namespace Assets.Scripts.GameStateMachine.States
{
    public class EndLevelState : BaseGameState
    {
        public EndLevelState(ISwitcher switcher, GameFlow flow) : base(switcher, flow) { }

        public override void Enter()
        {
            base.Enter();

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

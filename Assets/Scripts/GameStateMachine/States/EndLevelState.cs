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

            GameFlow.EndLevel.IsDeath();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}

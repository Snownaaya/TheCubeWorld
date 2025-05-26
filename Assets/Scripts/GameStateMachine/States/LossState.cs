using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.GameStateMachine.States
{
    public class LossState : BaseGameState
    {
        public LossState(ISwitcher switcher, GameFlow flow) : base(switcher, flow) { }

        public override void Enter()
        {
            base.Enter();

            GameFlow.LossScreen.Open();
            GameFlow.PauseHandler.SetPause(true);
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}

using Assets.Scripts.Interfaces;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.GameStateMachine.States
{
    public class LossState : BaseGameState
    {
        private Coroutine _coroutine;

        private float _delay = 2f;

        public LossState(ISwitcher switcher, GameFlow flow) : base(switcher, flow) { }

        public override void Enter()
        {
            base.Enter();

            _coroutine = GameFlow.StartCoroutine(DelayPause());
        }

        public override void Exit()
        {
            base.Exit();

            if (_coroutine != null)
                GameFlow.StopCoroutine(_coroutine);
        }

        private IEnumerator DelayPause()
        {
            yield return new WaitForSeconds(_delay);
            GameFlow.PauseHandler.SetPause(true);
            GameFlow.LossScreen.Open();
        }
    }
}
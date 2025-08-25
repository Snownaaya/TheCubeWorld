using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.GameStateMachine.States
{
    public class StartLevelState : BaseGameState
    {
        public StartLevelState(ISwitcher switcher, EntryPointState entryPoint) : base(switcher, entryPoint) { }

        public override void Enter()
        {
            base.Enter();

            EntryPoint.CharacterSpawnService?.SpawnAtStart();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
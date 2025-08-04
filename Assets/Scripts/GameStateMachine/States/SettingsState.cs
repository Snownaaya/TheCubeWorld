using Assets.Scripts.Interfaces;

namespace Assets.Scripts.GameStateMachine.States
{
    public class SettingsState : BaseGameState
    {
        public SettingsState(ISwitcher switcher, EntryPoint flow) : base(switcher, flow) { }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}

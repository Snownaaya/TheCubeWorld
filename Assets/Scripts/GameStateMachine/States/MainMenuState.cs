using Assets.Scripts.Interfaces;

namespace Assets.Scripts.GameStateMachine.States
{
    public class MainMenuState : BaseGameState
    {
        private const string MainMenu = nameof(MainMenu);

        public MainMenuState(ISwitcher switcher, GameFlow flow) : base(switcher, flow) { }

        public override void Enter()
        {
            base.Enter();

            GameFlow.LevelLoader.Load(MainMenu);
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}

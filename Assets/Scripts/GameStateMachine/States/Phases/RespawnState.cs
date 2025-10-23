﻿using Assets.Scripts.Service.LevelLoaderService.Loader;
using Assets.Scripts.GameStateMachine.States.Runtime;
using Assets.Scripts.Player.Inventory;
using Assets.Scripts.Service.Pause;
using Assets.Scripts.Player.Core;
using Assets.Scripts.Interfaces;
using Assets.Scripts.PluginYG;

namespace Assets.Scripts.GameStateMachine.States.Phases
{
    public class RespawnState : PhasesState
    {
        private PauseHandler _pauseHandler;
        private CharacterHolder _characterHolder;
        private RewardedVideoAds _rewarded;
        private ILevelLoader _levelLoader;

        public RespawnState(ISwitcher switcher,
            EntryPointState entryPoint,
            ILevelLoader levelLoader,
            PauseHandler pauseHandler,
            IInventory inventory,
            CharacterHolder characterHolder,
            RewardedVideoAds rewarded) : base(switcher, entryPoint, inventory)
        {
            _levelLoader = levelLoader;
            _pauseHandler = pauseHandler;
            _characterHolder = characterHolder;
            _rewarded = rewarded;
        }

        public override void Enter()
        {
            base.Enter();

            EntryPoint.LossScreen.Close();
            _levelLoader.Load(EntryPoint.LevelSelected.GetCurrentLevel());
            _pauseHandler.Remove(EntryPoint.LossScreen);
            _characterHolder.Character.CharacterModel.gameObject.SetActive(true);
            _characterHolder.Character.Health.ResetHealth();
            Switcher.SwitchState<StartLevelState>();
        }

        public override void Exit()
        {
            base.Exit();

        }
    }
}
using Assets.Scripts.GameStateMachine;
using Assets.Scripts.Interfaces;
using Cysharp.Threading.Tasks;
using Reflex.Attributes;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Service.LevelLoaderService
{
    public class BootstrapSceneLoader : MonoBehaviour
    {
        [SerializeField] private string Level_1 = nameof(Level_1);

        private CancellationTokenSource _cancellationTokenSource;

        private float _delay = 0f;

        private void Start()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            AwakeAsync(_cancellationTokenSource.Token).Forget();
        }

        private async UniTask AwakeAsync(CancellationToken cancellationToken)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_delay), cancellationToken: cancellationToken);

            if (cancellationToken.IsCancellationRequested)
                return;

            SceneManager.LoadScene(Level_1);
        }
    }
}

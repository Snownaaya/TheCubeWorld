using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using YG;

namespace Assets.Scripts.UI.Canvas
{
    public class CanvasSwitcher : MonoBehaviour
    {
        [SerializeField] private CanvasPortrait _canvasPortrait;
        [SerializeField] private CanvasLandscape _canvasLandscape;

        private void Start() => 
            InitializeAsync().Forget();

        private async UniTaskVoid InitializeAsync()
        {
            await UniTask.WaitUntil(() =>
                YG2.envir != null &&
                (YG2.envir.isDesktop || YG2.envir.isTablet || YG2.envir.isMobile)
            );

            ApplyCanvas();
        }

        private void ApplyCanvas()
        {
            bool isDesktop = YG2.envir.isDesktop;
            bool isMobile = YG2.envir.isTablet || YG2.envir.isMobile;

            _canvasLandscape.gameObject.SetActive(isDesktop);
            _canvasPortrait.gameObject.SetActive(isMobile);
        }
    }
}
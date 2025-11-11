using Cysharp.Threading.Tasks;
using UnityEngine;
using YG;

namespace Assets.Scripts.UI.Canvas
{
    public class CanvasSwitcher : MonoBehaviour
    {
        [SerializeField] private CanvasPortrait _canvasPortrait;
        [SerializeField] private CanvasLandscape _canvasLandscape;

        private void Start() =>
            ApplyCanvas();

        private void ApplyCanvas()
        {
            if(YG2.envir.device == YG2.Device.Desktop)
            {
                _canvasLandscape.gameObject.SetActive(true);
                _canvasPortrait.gameObject.SetActive(false);
            }
            else if(YG2.envir.device == YG2.Device.Mobile)
            {
                _canvasLandscape.gameObject.SetActive(false);
                _canvasPortrait.gameObject.SetActive(true);
            }
        }
    }
}
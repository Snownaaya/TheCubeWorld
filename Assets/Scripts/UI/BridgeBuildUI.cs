using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    internal class BridgeBuildUI : MonoBehaviour
    {
        [SerializeField] private Button[] _buttons;
        [SerializeField] private BridgeBuilder _bridgeBuilder;
        [SerializeField] private BridgeData[] _bridgeDatas;

        private void OnValidate()
        {
            if (_bridgeDatas == null || _bridgeBuilder == null)
            {
                Debug.LogError("Required fields not set in BridgeBuildUI.");
                enabled = false;
                return;
            }

            if (_bridgeDatas.Length == 0 || _buttons.Length == 0)
            {
                Debug.LogError("No BridgeData or buttons set in BridgeBuildUI");
                enabled = false;
                return;
            }
        }

        //private void OnEnable()
        //{
        //    for (int i = 0; i < _buttons.Length; i++)
        //    {
        //        int index = i;
        //        _buttons[i].onClick.AddListener(() => OnButtonBridgeBuild(_bridgeDatas[index].Type));
        //    }
        //}

        //private void OnDisable()
        //{
        //    for (int i = 0; i < _buttons.Length; i++)
        //    {
        //        int index = i;
        //        _buttons[i].onClick.RemoveListener(() => OnButtonBridgeBuild(_bridgeDatas[index].Type));
        //    }
        //}

        //private void OnButtonBridgeBuild(BridgeType bridgeType)
        //{
        //    _bridgeBuilder.TryBuild(_bridgeDatas[0]);
        //}
    }
}

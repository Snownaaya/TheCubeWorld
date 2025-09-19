using System.Collections.Generic;
using Assets.Scripts.Datas;

namespace Assets.Scripts.Service.BridgeService
{
    public class BridgeDataStorage
    {
        private readonly List<BridgeData> _bridgeDatas = new();

        public IReadOnlyList<BridgeData> BridgeDatas => _bridgeDatas;

        public void AddBridgeData(BridgeData bridgeData) =>
            _bridgeDatas.Add(bridgeData);

        public void Clear() =>
            _bridgeDatas.Clear();
    }
}
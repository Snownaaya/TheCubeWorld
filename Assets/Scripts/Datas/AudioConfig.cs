using Assets.Scripts.Service.Audio;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Datas
{
    [CreateAssetMenu(fileName = "Audio", menuName = "Audio/ScriptableObject")]
    public class AudioConfig : ScriptableObject
    {
        [field: SerializeField] public List<AudioData> AudioDatas;
    }
}
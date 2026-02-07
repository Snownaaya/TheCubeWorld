using System;
using System.Collections.Generic;
using Assets.Scripts.Service.Audio;
using UnityEngine;

namespace Assets.Scripts.Datas
{
    [CreateAssetMenu(fileName = "Audio", menuName = "Audio/ScriptableObject")]
    public class AudioConfig : ScriptableObject
    {
        [field: SerializeField] public List<AudioData> AudioDatas { get; private set; }

        [Serializable]
        public struct AudioData
        {
            [field: SerializeField] public List<AudioClip> AudioClip;
            [field: SerializeField] public AudioTypes AudioTypes;
            [field: SerializeField, Range(0f, 1f)] public float Volume;
        }
    }
}
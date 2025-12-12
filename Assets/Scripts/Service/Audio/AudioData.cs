using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Service.Audio
{
    [Serializable]
    public struct AudioData
    {
        [field: SerializeField] public List<AudioClip> AudioClip;
        [field: SerializeField] public AudioTypes AudioTypes;
        [field: SerializeField, Range(0, 1)] public float Volume;
    }
}
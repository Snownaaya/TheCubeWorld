using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Service.Audio
{
    public class BackgroundAudioService
    {
        private AudioSource _backgroundSource;

        private Dictionary<AudioTypes, AudioData> _audioData;

        public BackgroundAudioService(List<AudioData> audioData)
        {
            _audioData = new Dictionary<AudioTypes, AudioData>();

            foreach (AudioData data in audioData)
                _audioData.Add(data.AudioTypes, data);

            _backgroundSource = new GameObject("BackgroundAudioSource").AddComponent<AudioSource>();
            _backgroundSource.loop = true;

            Object.DontDestroyOnLoad(_backgroundSource.gameObject);
        }

        public void PlayBackground(AudioTypes audioTypes)
        {
            AudioData data = _audioData[audioTypes];
            AudioClip clip = data.AudioClip[Random.Range(0, data.AudioClip.Count)];

            _backgroundSource.clip = clip;
            _backgroundSource.volume = data.Volume;
            _backgroundSource.Play();
        }

        public async UniTask BackgroundSetVolume(float value = 0)
        {
            await UniTask.Yield();
            AudioData audioData = _audioData[AudioTypes.Background];
            float logVolume = Mathf.Log10(audioData.Volume) * 20;
            _backgroundSource.volume = Mathf.Lerp(logVolume, value, 1);
        }
    }
}
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts.Service.Audio
{
    public class ForegroundAudioService
    {
        private CompositeDisposable _compositeDisposable = new();
        private AudioSource _foregroundSource;

        private Dictionary<AudioTypes, AudioData> _audioData;
        private ObjectPool<AudioSource> _audioSourcePool;

        public ForegroundAudioService(Dictionary<AudioTypes, AudioData> audioData)
        {
            _audioData = audioData;

            GameObject gameObject = new GameObject("GameObject");
            _foregroundSource = new GameObject("AudioSource").AddComponent<AudioSource>();
            _audioSourcePool = new ObjectPool<AudioSource>(() => UnityEngine.Object.Instantiate(_foregroundSource, gameObject.transform));

            UnityEngine.Object.DontDestroyOnLoad(gameObject);
            UnityEngine.Object.DontDestroyOnLoad(_foregroundSource);
        }

        public void PlaySound(AudioTypes audioTypes)
        {
            AudioData audioData = _audioData[audioTypes];
            AudioClip audioClip = audioData.AudioClip[UnityEngine.Random.Range(0, audioData.AudioClip.Count)];

            AudioSource audioSource = _audioSourcePool.Get();
            audioSource.clip = audioClip;
            audioSource.volume = audioData.Volume = _foregroundSource.volume;
            audioSource.PlayOneShot(audioClip, audioData.Volume);

            Observable.Timer(TimeSpan.FromSeconds(audioClip.length + 1f))
                .Subscribe(_ =>
                {
                    if (audioSource != null && audioSource.gameObject != null)
                        _audioSourcePool.Release(audioSource);
                })
                .AddTo(_compositeDisposable);
        }

        public void ForegroundSetVolume(float value, AudioTypes audioTypes)
        {
            AudioData audioData = _audioData[audioTypes];
            _foregroundSource.volume = audioData.Volume * value;
        }
    }
}
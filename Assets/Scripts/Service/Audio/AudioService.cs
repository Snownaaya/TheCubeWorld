using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts.Service.Audio
{
    public class AudioService : IDisposable
    {
        private CompositeDisposable _compositeDisposable = new();
        private AudioSource _backgroundSource;

        private Dictionary<AudioTypes, AudioData> _audioData;
        private ObjectPool<AudioSource> _audioSourcePool;

        public AudioService(Dictionary<AudioTypes, AudioData> audioData)
        {
            _audioData = audioData;

            GameObject gameObject = new GameObject("GameObject");
            AudioSource audioSource = new GameObject("AudioSourse").AddComponent<AudioSource>();
            _audioSourcePool = new ObjectPool<AudioSource>(() => UnityEngine.Object.Instantiate(audioSource, gameObject.transform));

            _backgroundSource = new GameObject("BackgroundAudioSourse").AddComponent<AudioSource>();
            _backgroundSource.loop = true;

            UnityEngine.Object.DontDestroyOnLoad(gameObject);
            UnityEngine.Object.DontDestroyOnLoad(audioSource);
            UnityEngine.Object.DontDestroyOnLoad(_backgroundSource.gameObject);
        }

        public void PlaySound(AudioTypes audioTypes)
        {
            AudioData audioData = _audioData[audioTypes];
            AudioClip audioClip = audioData.AudioClip[UnityEngine.Random.Range(0, audioData.AudioClip.Count)];

            AudioSource audioSource = _audioSourcePool.Get();
            audioSource.clip = audioClip;
            audioSource.volume = audioData.Volume;
            audioSource.PlayOneShot(audioClip);

            Observable.Timer(TimeSpan.FromSeconds(audioClip.length + 1f))
                .Subscribe(_ =>
                {
                    if (audioSource != null && audioSource.gameObject != null)
                        _audioSourcePool.Release(audioSource);
                })
                .AddTo(_compositeDisposable);
        }
        
        public void PlayBackground(AudioTypes audioType)
        {
            var data = _audioData[audioType];
            var clip = data.AudioClip[UnityEngine.Random.Range(0, data.AudioClip.Count)];

            _backgroundSource.clip = clip;
            _backgroundSource.volume = data.Volume;
            _backgroundSource.Play();
        }

        public void Dispose() =>
            _compositeDisposable.Dispose();
    }
}
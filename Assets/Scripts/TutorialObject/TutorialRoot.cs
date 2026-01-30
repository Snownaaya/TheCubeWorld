using Assets.Scripts.Service.Json;
using Assets.Scripts.Service.Saves;
using Cysharp.Threading.Tasks;
using Reflex.Attributes;
using System;
using UnityEngine;
using YG;

namespace Assets.Scripts.TutorialObject
{
    [RequireComponent(typeof(MoveTutorialPC))]
    public class TutorialRoot : MonoBehaviour
    {
        private const string MoveTutorialKey = nameof(MoveTutorialKey);

        private float _delay = 10f;

        private MoveTutorialPC _tutorialPC;
        private ISaveService _saveService;
        private IJsonService _jsonService;

        private bool _isCompletedLoad;

        [Inject]
        private void Construct(
            ISaveService saveService,
            IJsonService jsonService)
        {
            _saveService = saveService;
            _jsonService = jsonService;
        }

        private void Awake()
        {
            _tutorialPC = GetComponent<MoveTutorialPC>();

            string json = _saveService.Load(MoveTutorialKey);

            if (string.IsNullOrEmpty(json) == false)
            {
                MoveTutorialData data = _jsonService.Deserialize<MoveTutorialData>(json);

                if (data != null && data.IsCompleted)
                {
                    _isCompletedLoad = true;
                    _tutorialPC.Disable();
                }
            }
        }

        private void Start()
        {
            if (_isCompletedLoad == false && YG2.envir.isDesktop)
            {
                _tutorialPC.Enable();
                StartWithDelay().Forget();
            }
            else if (_isCompletedLoad == false && YG2.envir.isDesktop == false)
            {
                _tutorialPC.Disable();
            }
        }

        private async UniTask StartWithDelay()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_delay));

            _tutorialPC.Disable();

            MoveTutorialData dataToSave = new MoveTutorialData
            {
                IsCompleted = true
            };

            string json = _jsonService.Serialize(dataToSave);
            _saveService.Save(MoveTutorialKey, json);
        }
    }
}
using Assets.Scripts.Player.Wallet;
using Assets.Scripts.Service.GameMessage;
using Assets.Scripts.Service.LevelLoaderService;
using Assets.Scripts.Service.LevelLoaderService.Loader;
using Assets.Scripts.UI.FinishedUI;
using Assets.Scripts.UseCase;
using Assets.Scripts.VictoryReward;
using Cysharp.Threading.Tasks;
using Reflex.Attributes;
using System.Threading;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Mediators.LevelCompletedMediator
{
    public class WinLevelWindowMediator : MonoBehaviour
    {
        [SerializeField] private AddDefaultCoin _addDefaultCoin;
        [SerializeField] private AdsCoinButton _adsCoinButton;
        [SerializeField] private LevelSelected _levelSelected;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private RewardStripArrow _arrow;
        [SerializeField] private RewardSlotView[] _slots;

        private SpinUseCase _spinUseCase;
        private CompositeDisposable _disposable = new CompositeDisposable();
        private CancellationTokenSource _cancellationTokenSource;
        private SceneTransitions _sceneTransitions;
        private RewardStripModel _rewardStripModel;
        private RewardStripFactory _rewardStripFactory;
        private GameMessageBus _messageBus;
        private ILevelLoader _levelLoader;
        private IWallet _wallet;

        private void Awake()
        {
            _sceneTransitions = new SceneTransitions(_levelLoader, _levelSelected);
            _rewardStripFactory = new RewardStripFactory();
            _cancellationTokenSource = new CancellationTokenSource();
            _spinUseCase = new SpinUseCase(_slots);

            _addDefaultCoin.Initialize(_messageBus);
            _rewardStripModel = _rewardStripFactory.Create();
        }

        [Inject]
        private void Construct(
            ILevelLoader levelLoader,
            IWallet wallet,
            GameMessageBus messageBus)
        {
            _levelLoader = levelLoader;
            _wallet = wallet;
            _messageBus = messageBus;
            _adsCoinButton.Initialize(_messageBus);
        }

        private void OnEnable()
        {
            _spinUseCase.OnSlotChanged += OnSlotChanged;
            _spinUseCase.OnPositionChanged += _arrow.MoveArrow;

            _spinUseCase.StartSpin(_cancellationTokenSource.Token).Forget();
            _adsCoinButton.OnClicked += StopAnimation;

            for (int i = 0; i < _slots.Length; i++)
                _slots[i].MultiplierText(_rewardStripModel.Multipliers[i]);
        }

        private void OnDisable()
        {
            _disposable.Dispose();
            _spinUseCase.OnPositionChanged -= _arrow.MoveArrow;
            _spinUseCase.OnSlotChanged -= OnSlotChanged;
            _adsCoinButton.OnClicked -= StopAnimation;
        }

        public void ProcessRewardWheelResult()
        {
            _messageBus.MessageBroker
                .Receive<RewardStripModel>()
                .Subscribe(model => OnRewardReceived(model))
                .AddTo(_disposable);
        }

        public void ProcessDefaultCoimResult()
        {
            _messageBus.MessageBroker
                .Receive<int>()
                .Subscribe(coins => OnDefaultCoinReceived(coins))
                .AddTo(_disposable);
        }

        public void Show() =>
            _canvas.gameObject.SetActive(true);

        private void OnDefaultCoinReceived(int coins)
        {
            _wallet.AddCoins(coins);
            _sceneTransitions.LoadNextLevel().Forget();
        }

        public void OnRewardReceived(RewardStripModel model)
        {
            _wallet.AddCoins(model.FinalCoins);
            _sceneTransitions.LoadNextLevel().Forget();
        }

        private void OnSlotChanged(int currentIndex)
        {
            _rewardStripModel.CurrentIndex = currentIndex;
            //_arrow.SetCurrentIndex(currentIndex);
            _adsCoinButton.UpdateCoinsText(_rewardStripModel.FinalCoins);
        }

        private void StopAnimation()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
            _adsCoinButton.UpdateCoinsText(_rewardStripModel.FinalCoins);
        }
    }
}
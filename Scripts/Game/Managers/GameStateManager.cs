using System;
using System.Threading;
using App.Scripts.Utils;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using Zenject;

namespace App.Game.Managers
{
    public class GameStateManager : MonoBehaviour, IGameStateManager
    {
        [Inject] private IPlayerProvider _playerProvider;
        public GameState GameState { get; private set; }
        public bool IsCleared { get; private set; }

        private void Start()
        {
            var token = this.GetCancellationTokenOnDestroy();
            GameLoopAsync(token).Forget();
        }

        private async UniTaskVoid GameLoopAsync(CancellationToken token = default)
        {
            GameState = GameState.Initialize;
            GameState = GameState.GameUpdate;
            
            var result = await UniTask.WhenAny(
                _playerProvider.GoalObservable.ToUniTask(cancellationToken: token),
                _playerProvider.GameOverObservable.ToUniTask(cancellationToken: token),
                _playerProvider.ObserveEveryValueChanged(x => x.PlayerHealth.HitPoint)
                    .Where(x => x < 0f || Mathf.Approximately(x, 0f))
                    .FirstOrDefault()
                    .ToUniTask(cancellationToken: token)
            );

            IsCleared = result.winArgumentIndex == 0;
            
            if(!IsCleared)
                SceneLoader.LoadScene("Title", container => { });

            GameState = GameState.Result;
        }
    }
}
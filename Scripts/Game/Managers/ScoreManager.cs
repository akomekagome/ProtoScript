using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace App.Game.Managers
{
    public class ScoreManager : MonoBehaviour
    {
        [Inject] private IGameStateManager _gameStateManager;
        public float Score { get; private set; }

        private void Start()
        {
            var startTime = Time.time;

            this.UpdateAsObservable()
                .TakeWhile(_ => _gameStateManager.GameState != GameState.Result)
                .Subscribe(_ => Score = Time.time - startTime);
        }
    }
}
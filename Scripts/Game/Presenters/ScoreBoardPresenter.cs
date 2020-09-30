using System;
using App.Game.Managers;
using App.Scripts.Game.Views;
using UnityEngine;
using Zenject;
using UniRx;

namespace App.Game.Presenters
{
	public class ScoreBoardPresenter : MonoBehaviour
	{
		[Inject] private IGameStateManager _gameStateManager;
		[Inject] private NetWorkProvider _netWorkProvider;
		[SerializeField] private ScoreBoard _scoreBoard;

		private void Start()
		{
			_scoreBoard.gameObject.SetActive(false);
			
			_gameStateManager.ObserveEveryValueChanged(x => x.GameState)
				.Where(x => x == GameState.Result)
				.FirstOrDefault()
				.Subscribe(_ => _scoreBoard.gameObject.SetActive(true))
				.AddTo(this);
			
			_netWorkProvider.ResRankingObservable
				.FirstOrDefault()
				.Subscribe(_scoreBoard.ShowRanking)
				.AddTo(this);
		}
	}
}
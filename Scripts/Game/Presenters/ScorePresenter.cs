using System;
using App.Game.Managers;
using TMPro;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;

namespace App.Game.Presenters
{
	public class ScorePresenter : MonoBehaviour
	{
		[Inject] private ScoreManager _scoreManager;
		[SerializeField] private TextMeshProUGUI scoreText;

		private void Start()
		{
			this.UpdateAsObservable()
				.Subscribe(_ => scoreText.text = _scoreManager.Score.ToString("f2"));
		}
	}
}
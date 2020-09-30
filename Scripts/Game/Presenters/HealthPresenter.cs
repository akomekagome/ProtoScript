using System;
using App.Game.Managers;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace App.Game.Presenters
{
    public class HealthPresenter : MonoBehaviour
    {
        [Inject] private IPlayerProvider _playerProvider;
        [SerializeField] private Image image;
        
        private void Start()
        {
            var health = _playerProvider.PlayerHealth;
            
            health.ObserveEveryValueChanged(x => x.HitPoint)
                .Subscribe(x => image.fillAmount = Mathf.Max(0, x / health.MaxHitPoint))
                .AddTo(this);
        }
    }
}
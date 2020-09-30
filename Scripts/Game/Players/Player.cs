using System;
using App.Game.Colors;
using App.Game.Damages;
using App.Game.Healths;
using App.Game.Players.Input;
using App.Game.Stages;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace App.Game.Players
{
    public class Player: MonoBehaviour, IColor, IHealth, IDamageable
    {
        [Inject] private Health _health;
        [Inject] private IPlayerInput _input;
        public ColorType ColorType { get; private set; }
        public float MaxHitPoint => _health.MaxHitPoint;
        public float HitPoint => _health.HitPoint;
        private Subject<Unit> _gameOveSubject = new Subject<Unit>();
        public IObservable<Unit> GameOverObservable => _gameOveSubject.AsObservable();
        private Subject<Unit> _goalSubject = new Subject<Unit>();
        public IObservable<Unit> GoalObservable => _goalSubject.AsObservable();
        public void ApplyDamage(Damage damage)
        {
            if (damage is ColorDamage colorDamage)
            {
                _health.ChangeHealth(colorDamage.DamageValue, ColorType, colorDamage.Color.ColorType);
            }
        }

        private void Start()
        {
            this.OnTriggerEnter2DAsObservable()
                .Select(x => x.GetComponent<GoalArea>())
                .Where(x => x != null)
                .FirstOrDefault()
                .Subscribe(_ =>
                {
                    _goalSubject.OnNext(Unit.Default);
                    _goalSubject.OnCompleted();
                });
            
            _input.ObserveEveryValueChanged(x => x.PushedChangeColor)
                .Where(x => x != ColorType.None)
                .Subscribe(x => ColorType = x)
                .AddTo(this);
            
            ColorType = ColorType.Red;
            
            this.ObserveEveryValueChanged(x => x.HitPoint)
                .Subscribe(x => Debug.Log(x))
                .AddTo(this);
        }
    }
}
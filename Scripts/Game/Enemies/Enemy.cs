using System;
using App.Game.Colors;
using App.Game.Damages;
using App.Game.Healths;
using App.Game.Players;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace App.Game.Enemies
{
    public abstract class Enemy : MonoBehaviour, IColor, IHealth, IDamageable
    {
        [Inject] private SpriteRendererColorChanger _spriteRendererColorChanger;
        [Inject] private Health _health;
        [SerializeField] protected ColorType colorType;
        public ColorType ColorType { get; protected set; }
        public float MaxHitPoint =>  _health.MaxHitPoint;
        public float HitPoint => _health.HitPoint;

        private void Awake()
        {
            ColorType = colorType;
            _spriteRendererColorChanger.ChangeColor(ColorType);
        }

        public void ApplyDamage(Damage damage)
        {
            if (damage is ColorDamage colorDamage)
            {
                Debug.Log(ColorType);
                Debug.Log(colorDamage.Color.ColorType);
                _health.ChangeHealth(colorDamage.DamageValue, ColorType, colorDamage.Color.ColorType);
            }
            Debug.Log(HitPoint);
        }
    }
}
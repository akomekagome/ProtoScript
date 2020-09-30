using System;
using App.Game.Colors;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace App.Game.Bullets
{
    public abstract class Bullet : MonoBehaviour
    {
        [Inject] private SpriteRendererColorChanger _spriteRendererColorChanger;
        [Inject] protected Rigidbody2D rb2d;
        [SerializeField] protected float speed;
        [SerializeField] protected float damageValue;
        [SerializeField] protected float invincibleTime;
        protected IColor color;

        public void Init(IColor color)
        {
            this.color = color;
            _spriteRendererColorChanger.ChangeColor(color.ColorType);
        }

        private void Awake()
        {
            this.OnTriggerEnter2DAsObservable()
                .Subscribe(OnAttack);
        }

        protected abstract void OnAttack(Collider2D collider2D);
    }
}
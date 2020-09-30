using System;
using App.Game.Damages;
using App.Game.Players;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace App.Game.Enemies
{
    public class Kuribou : Enemy
    {
        [SerializeField] public float damageValue;
        [SerializeField] private float invincibleTime;

        private void Start()
        {
            var damage = new ColorDamage(damageValue, invincibleTime, this);

            this.OnCollisionEnter2DAsObservable()
                .Select(x => x.collider.GetComponent<Player>())
                .Where(x => x != null)
                .ThrottleFirst(TimeSpan.FromSeconds(1f))
                .Subscribe(x => x.ApplyDamage(damage))
                .AddTo(this);
        }
    }
}
using App.Game.Damages;
using App.Game.Enemies;
using App.Game.Players;
using UnityEngine;

namespace App.Game.Bullets
{
    public class PlayerBullet : Bullet
    {
        void Start()
        {
            rb2d.velocity = transform.right * speed;
        }

        protected override void OnAttack(Collider2D collider2D)
        {
            var player = collider2D.GetComponent<Player>();
            if(player != null)
                return;
            var enemy = collider2D.GetComponent<Enemy>();
            if (enemy != null)
            {
                var damage = new ColorDamage(base.damageValue, base.invincibleTime, base.color);
                enemy.ApplyDamage(damage);
            }
            Destroy(this.gameObject);
        }
    }
}
using System;
using App.Game.Bullets;
using App.Game.Colors;
using App.Game.Damages;
using App.Game.Players.Input;
using UniRx;
using UnityEngine;
using Zenject;

namespace App.Game.Players
{
	public class PlayerGunner : MonoBehaviour
	{
		[Inject] private IPlayerInput _input;
		[Inject] private Player _player;
		[SerializeField] private float interval = 1f;
		[SerializeField] private Bullet bulletPrefab;
		
		private void Start()
		{
			_input.ObserveEveryValueChanged(x => x.PushedShoot)
				.Where(x => x)
				.ThrottleFirst(TimeSpan.FromSeconds(interval))
				.Subscribe(_ => CreateBullet(Vector3.right, _player));
		}

		private void CreateBullet(Vector3 direction, IColor color)
		{
			var bullet = Instantiate(bulletPrefab);
			bullet.transform.position = transform.position;
			// bullet.transform.LookAt((Vector3) transform.position + direction);
			// bullet.transform.eulerAngles = new Vector3(0, 0, 0f);
			bullet.Init(color);
		}
	}
}
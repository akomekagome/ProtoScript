using System;
using App.Game.Colors;
using App.Game.Players.Input;
using UniRx;
using UnityEngine;
using Zenject;

namespace App.Game.Players
{
	public class PlayerColorChanger : MonoBehaviour
	{
		[Inject] private IPlayerInput _input;
		[Inject] private SpriteRendererColorChanger _spriteRendererColorChanger;
		[Inject] private Player _player;

		private void Start()
		{
			_player.ObserveEveryValueChanged(x => x.ColorType)
				.Subscribe(_spriteRendererColorChanger.ChangeColor)
				.AddTo(this);
		}
	}
}


using System.Diagnostics;
using UnityEngine;

namespace App.Game.Colors
{
	public class SpriteRendererColorChanger
	{
		private SpriteRenderer _renderer;

		public SpriteRendererColorChanger(SpriteRenderer renderer)
		{
			_renderer = renderer;
		}

		public void ChangeColor(ColorType colorType)
		{
			switch (colorType)
			{
				case ColorType.Red:
					_renderer.color = Color.red;
					break;
				case ColorType.Blue:
					_renderer.color = Color.blue;
					break;
				case ColorType.Green:
					_renderer.color = Color.green;
					break;
			}
		}
	}
}
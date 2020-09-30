using App.Game.Colors;
using UnityEngine;
using Zenject;

namespace App.Game.Installers
{
	public class SpriteRendererColorChangerInstaller: MonoInstaller
	{
		public override void InstallBindings()
		{
			var spriteRenderer = GetComponent<SpriteRenderer>();
			var spriteRendererColorChanger = new SpriteRendererColorChanger(spriteRenderer);

			Container
				.Bind<SpriteRendererColorChanger>()
				.FromInstance(spriteRendererColorChanger)
				.AsTransient();
		}
	}
}
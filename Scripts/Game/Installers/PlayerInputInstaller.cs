using App.Game.Players.Input;
using Zenject;

namespace App.Game.Installers
{
	public class PlayerInputInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container
				.Bind<IPlayerInput>()
				.To<PlayerInput>()
				.FromNew()
				.AsTransient();
		}
	}
}
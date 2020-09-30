using System;
using UnityEngine;
using App.Game.Colors;
using App.Game.Healths;
using UniRx;

namespace App.Game.Managers
{
	public interface IPlayerProvider
	{
		IColor PlayerColor { get; }
		IHealth PlayerHealth { get; }
		Vector3 PlayerPosition { get; }
		IObservable<Unit> GoalObservable { get; }
		IObservable<Unit> GameOverObservable { get; }
	}
}
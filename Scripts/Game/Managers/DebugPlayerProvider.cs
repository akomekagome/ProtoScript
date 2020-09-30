using System;
using App.Game.Colors;
using App.Game.Healths;
using App.Game.Players;
using UniRx;
using UnityEngine;

namespace App.Game.Managers
{
    public class DebugPlayerProvider : MonoBehaviour, IPlayerProvider
    {
        [SerializeField] private Player player;
        public IColor PlayerColor => player;
        public IHealth PlayerHealth => player;
        public Vector3 PlayerPosition => player.transform.position;
        public IObservable<Unit> GoalObservable => player.GoalObservable;
        public IObservable<Unit> GameOverObservable => player.GameOverObservable;
    }
}
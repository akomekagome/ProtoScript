using App.Game.Colors;
using App.Game.Damages;
using UnityEngine;

namespace App.Game.Gimmicks
{
    public abstract class Gimmick : MonoBehaviour
    {
        public void ApplyDamage(Damage damage)
        {
            throw new System.NotImplementedException();
        }

        public ColorType ColorType { get; }
    }
}
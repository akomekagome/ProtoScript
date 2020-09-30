using System.Diagnostics;
using App.Game.Colors;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace App.Game.Healths
{
    public class Health
    {
        public float MaxHitPoint { get; private set; }
        public float HitPoint { get; private set; }

        public Health(float maxHitPoint)
        {
            MaxHitPoint = maxHitPoint;
            HitPoint = MaxHitPoint;
        }
        public void ChangeHealth(float damageValue, ColorType myColorType, ColorType otherColorType)
        {
            HitPoint = Mathf.Max(0, HitPoint - CalculationDamage(damageValue, myColorType, otherColorType));
        }

        private float CalculationDamage(float damageValue, ColorType myColorType, ColorType otherColorType)
        {
            if (myColorType == ColorType.Red && otherColorType == ColorType.Blue ||
                myColorType == ColorType.Green && otherColorType == ColorType.Red ||
                myColorType == ColorType.Blue && otherColorType == ColorType.Green)
                return damageValue * 2f;
            
            if (myColorType == ColorType.Blue && otherColorType == ColorType.Red ||
                myColorType == ColorType.Red && otherColorType == ColorType.Green ||
                myColorType == ColorType.Green && otherColorType == ColorType.Blue)
                return damageValue * 0.5f;

            return damageValue;
        }
    }
}
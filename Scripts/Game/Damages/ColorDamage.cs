using App.Game.Colors;

namespace App.Game.Damages
{
    public class ColorDamage : Damage
    {
        public IColor Color { get; }

        public ColorDamage(float damageValue, float invincibleTime, IColor color) : base(damageValue, invincibleTime)
        {
            Color = color;
        }
    }
}
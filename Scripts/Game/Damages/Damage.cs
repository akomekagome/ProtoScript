namespace App.Game.Damages
{
    public abstract class Damage
    {
        public float DamageValue { get; }
        public float InvincibleTime { get; }
        
        public Damage(float damageValue, float invincibleTime)
        {
            DamageValue = damageValue;
            InvincibleTime = invincibleTime;
        }
    }
}
using App.Game.Healths;
using UnityEngine;
using Zenject;

namespace App.Game.Installers
{
    
    public class HealthInstaller : MonoInstaller
    {
        [SerializeField] private float maxHitPoint = 100;

        public override void InstallBindings()
        {
            var health = new Health(maxHitPoint);
            
            Container
                .Bind<Health>()
                .FromInstance(health)
                .AsTransient();
        }
    }
}

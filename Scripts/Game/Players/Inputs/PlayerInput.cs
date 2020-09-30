using App.Game.Colors;

namespace App.Game.Players.Input
{
    using UnityEngine;
    
    public class PlayerInput : IPlayerInput
    {
        public float MoveDirection => Input.GetAxis("Horizontal");
        public bool PushedJump => Input.GetKeyDown(KeyCode.Space);
        public ColorType PushedChangeColor{
            get
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                    return ColorType.Red;
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                    return ColorType.Green;
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                    return ColorType.Blue;
                return ColorType.None;
            }
        }
        public bool PushedShoot => Input.GetKeyDown(KeyCode.Z);
    }
}
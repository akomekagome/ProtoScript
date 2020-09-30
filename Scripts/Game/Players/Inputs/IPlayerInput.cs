using App.Game.Colors;
using UnityEngine;

namespace App.Game.Players.Input

{
    public interface IPlayerInput
    {
        float MoveDirection {get;}
        bool PushedJump {get;}
        ColorType PushedChangeColor {get;}
        bool PushedShoot {get;}
    }
}
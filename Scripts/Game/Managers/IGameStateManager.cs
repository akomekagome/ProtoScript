namespace App.Game.Managers
{
    public interface IGameStateManager
    {
        GameState GameState { get; }
        bool IsCleared { get; }
    }
}
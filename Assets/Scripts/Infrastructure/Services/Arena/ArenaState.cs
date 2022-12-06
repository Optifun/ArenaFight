namespace Infrastructure.Services.Arena
{
    public enum ArenaState
    {
        Initial,
        LoadingMap,
        BuildingWorld,
        GameLoop,
        Paused,
        Wasted,
        Exit
    }
}
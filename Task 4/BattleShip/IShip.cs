namespace BattleShip
{
    public interface IShip
    {
        int Length { get; }
        int X { get; }
        int Y { get; }
        Direction Direction { get; }
    }
}

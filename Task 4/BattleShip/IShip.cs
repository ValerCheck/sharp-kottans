namespace BattleShip
{
    public interface IShip
    {
        int Length { get; }
        int X { get; }
        int Y { get; }
        Direction Direction { get; }
        bool FitsInSquare(byte height, byte width);
        bool OverlapsWith(IShip target);
        string GetNotation();
    }
}

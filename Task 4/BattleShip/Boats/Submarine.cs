namespace BattleShip
{
    public class Submarine:Ship
    {
        public Submarine(int x, int y) : base(x, y, length: 3) { }
        public Submarine(int x, int y, Direction direction) : base(x, y, direction, 3) { }
    }
}

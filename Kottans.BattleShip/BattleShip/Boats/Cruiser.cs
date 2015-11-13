namespace BattleShip
{
    public class Cruiser:Ship
    {
        public Cruiser(int x, int y) : base(x, y, length: 2) {}
        public Cruiser(int x, int y, Direction direction) : base(x, y, direction, 2) {}
    }
}

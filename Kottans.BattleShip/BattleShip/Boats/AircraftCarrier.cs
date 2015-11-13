namespace BattleShip
{
    public class AircraftCarrier : Ship
    {
        public AircraftCarrier(int x, int y) : base(x:x,y:y,length:4){ }
        public AircraftCarrier(int x, int y, Direction direction) : base(x, y, direction,4) { }
    }
}

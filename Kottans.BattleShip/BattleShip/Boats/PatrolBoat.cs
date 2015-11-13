namespace BattleShip
{
    public class PatrolBoat:Ship
    {
        public PatrolBoat(int x, int y) : base(x:x,y:y,length:1){}
        public PatrolBoat(int x, int y, Direction direction) : base(x, y, direction,1) {}
    }
}

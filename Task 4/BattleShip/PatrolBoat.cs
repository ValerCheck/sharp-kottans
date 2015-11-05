using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class PatrolBoat:BoatBase
    {
        public PatrolBoat(int x, int y) : base(x:x,y:y,length:1){}
        public PatrolBoat(int x, int y, Direction direction) : base(x, y, direction,1) {}
    }
}

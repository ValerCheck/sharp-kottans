using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Cruiser:BoatBase
    {
        public Cruiser(int x, int y) : base(x, y, length: 2) {}
        public Cruiser(int x, int y, Direction direction) : base(x, y, direction, 2) {}
    }
}

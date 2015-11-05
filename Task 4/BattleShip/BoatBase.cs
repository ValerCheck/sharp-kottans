using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public abstract class BoatBase
    {
        private readonly int _x;
        private readonly int _y;
        private readonly Direction _direction;
        private readonly int _length;

        protected BoatBase():this(0,0){}

        protected BoatBase(int x, int y, Direction direction = Direction.Horizontal, int length = 0)
        {
            _x = x;
            _y = y;
            _direction = direction;
            _length = length;
        }

        public override bool Equals(object obj)
        {
            var boat = (BoatBase)obj;
            if (boat == null || obj == null) return false;
            return Equals(boat);
        }

        protected bool Equals(BoatBase other)
        {
            var lengthEquality = _length == other._length;
            var directionEquality = _direction == other._direction;
            var coordsEquality = _x == other._x && _y == other._y;

            if (!lengthEquality) return false;

            if (_length == 1 && coordsEquality) return true;

            return coordsEquality && directionEquality;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_x * 397) ^ _y;
            }
        }
    }
}

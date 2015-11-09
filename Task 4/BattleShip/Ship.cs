using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BattleShip
{
    public abstract class Ship : IShip
    {
        private readonly int _x;
        private readonly int _y;
        private readonly Direction _direction;
        private readonly int _length;

        private static readonly Dictionary<int, Func<int,int,Direction,IShip>> ShipConstructor = 
            new Dictionary<int, Func<int,int,Direction,IShip>>
            {
                {1, (x,y, dir) => new PatrolBoat(x, y, dir)},
                {2, (x,y, dir) => new Cruiser(x, y, dir)},
                {3, (x,y, dir) => new Submarine(x, y, dir)},
                {4, (x,y, dir) => new AircraftCarrier(x, y, dir) }
            };

        protected Ship():this(0,0){}

        protected Ship(int x, int y, Direction direction = Direction.Horizontal, int length = 0)
        {
            _x = x;
            _y = y;
            _direction = direction;
            _length = length;
        }

        public static IShip Parse(string notation)
        {
            var shipFullNotation = Regex.Match(notation, @"[A-J]\d{1,2}(x\d)?(-|\|)?").Value;
            
            if (string.IsNullOrEmpty(shipFullNotation) || shipFullNotation.Length < notation.Length)
                throw new NotAShipException("Wrong ship notation");
            
            var yAndLength = Regex.Matches(shipFullNotation,@"\d");

            var y = int.Parse(yAndLength[0].Value);
            var length = yAndLength.Count > 1 ? int.Parse(yAndLength[1].Value) : 1;

            if (y > 10 || length > 4) throw new NotAShipException("Wrong ship notation");

            var x = shipFullNotation[0] - 'A' + 1;
            var direction = Regex.Match(shipFullNotation,@"(-|\|)").Value == @"|" ? 
                Direction.Vertical : 
                Direction.Horizontal;
            
            return ShipConstructor[length].Invoke(x,y,direction);
        }

        public int Length => _length;

        public int X => _x;

        public int Y => _y;

        public Direction Direction => _direction;

        public override bool Equals(object obj)
        {
            int b = 123;
            var boat = (Ship)obj;
            if (boat == null || obj == null) return false;
            return Equals(boat);
        }

        protected bool Equals(Ship other)
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

using System;

namespace BattleShip.BattleShipExceptions
{
    public class ShipOverlapException : ApplicationException
    {
        public ShipOverlapException() { }

        public ShipOverlapException(string message) : base(message) { }

        public ShipOverlapException(string message, Exception inner) : base(message, inner) { }
    }
}

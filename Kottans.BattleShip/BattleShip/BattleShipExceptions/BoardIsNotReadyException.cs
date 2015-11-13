using System;

namespace BattleShip.BattleShipExceptions
{
    public class BoardIsNotReadyException : ApplicationException
    {
        public BoardIsNotReadyException() { }

        public BoardIsNotReadyException(string message) : base(message) { }

        public BoardIsNotReadyException(string message, Exception inner) : base(message, inner) { }
    }
}

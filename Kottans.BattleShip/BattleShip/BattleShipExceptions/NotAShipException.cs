﻿using System;

namespace BattleShip.BattleShipExceptions
{
    public class NotAShipException : ApplicationException
    {
        public NotAShipException() { }

        public NotAShipException(string message) : base(message) { }

        public NotAShipException(string message, Exception inner) : base(message, inner) { }
    }
}

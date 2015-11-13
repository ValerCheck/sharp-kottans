using System;
using System.Collections.Generic;
using BattleShip.BattleShipExceptions;

namespace BattleShip
{
    public class Board
    {
        private const byte PatrolCount = 4;
        private const byte CruiserCount = 3;
        private const byte SubmarineCount = 2;
        private const byte AircraftCount = 1;

        private List<IShip> _shipsOnBoard;

        public Board()
        {
            _shipsOnBoard = new List<IShip>();
        }

        public void Add(IShip ship)
        {
            foreach (var shipOnBoard in _shipsOnBoard)
            {
                if (ship.OverlapsWith(shipOnBoard))
                    throw new ShipOverlapException($"Ship {ship.GetNotation()} overlaps with {shipOnBoard.GetNotation()}");
            }

            var endX = ship.Direction == Direction.Vertical ? 0 : ship.Length - 1;
            var endY = ship.Direction == Direction.Vertical ? ship.Length - 1 : 0;

            if (ship.X > 10 || ship.Y > 10 || ship.Y < 0 || ship.Y > 10)
                throw new ArgumentOutOfRangeException();
            if (ship.X + endX > 10 || ship.Y + endY > 10)
                throw new ArgumentOutOfRangeException();
            _shipsOnBoard.Add(ship);
        }

        public void Add(string notation)
        {
            var shipToAdd = Ship.Parse(notation);
            Add(shipToAdd);
        }

        public List<IShip> GetAll()
        {
            return _shipsOnBoard;
        }

        public void Validate()
        {
            var actualPatrols = 0;
            var actualCruisers = 0;
            var actualSubmarines = 0;
            var actualAircrafts = 0;
            foreach (var ship in _shipsOnBoard)
            {
                if (ship.GetType() == typeof (PatrolBoat)) actualPatrols++;
                else if (ship.GetType() == typeof (Cruiser)) actualCruisers++;
                else if (ship.GetType() == typeof (Submarine)) actualSubmarines++;
                else if (ship.GetType() == typeof (AircraftCarrier)) actualAircrafts++;
            }

            if (actualPatrols != PatrolCount || actualCruisers != CruiserCount ||
                actualSubmarines != SubmarineCount || actualAircrafts != AircraftCount)
                throw new BoardIsNotReadyException($@"There is not sufficient count of ships. 
                                                      We need: PatrolBoat ({PatrolCount - actualPatrols}), 
                                                      Cruiser ({CruiserCount - actualCruisers}), 
                                                      Submarine ({SubmarineCount - actualSubmarines}), 
                                                      AircraftCarrier ({AircraftCount - actualAircrafts})");
        }
    }
}

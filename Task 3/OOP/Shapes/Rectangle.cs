using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security;

namespace OOP.Shapes
{
    public class Rectangle : ShapeBase
    {
        private double _edge1, _edge2;

        public Rectangle(double edge1, double edge2) : this(new Dictionary<ParamKeys, object>
        {
            {ParamKeys.Edge1, edge1},
            {ParamKeys.Edge2, edge2},
            {ParamKeys.CoordX, 0 },
            {ParamKeys.CoordY, 0 }
        })
        { }

        public Rectangle(IDictionary<ParamKeys, object> parameters) : base(parameters)
        {
            _edge1 = (double) parameters[ParamKeys.Edge1];
            _edge2 = (double)parameters[ParamKeys.Edge2];
        }

        public override double GetPerimeter()
        {
            return 2*(_edge1 + _edge2) * Multiplier;
        }

        protected override double Area()
        {
            return _edge2*_edge1*Multiplier;
        }

        public override void Move(int deltaX, int deltaY)
        {
            CoordX += deltaX;
            CoordY += deltaY;
        }

        public override string ShapeName => GetType().Name;
    }
}
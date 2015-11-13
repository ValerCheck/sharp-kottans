using System;
using System.Collections.Generic;

namespace OOP.Shapes
{
    public class Triangle : ShapeBase
    {
        private double _edge1 = 0, _edge2 = 0, _edge3 = 0;

        public Triangle(double edge1, double edge2, double edge3) : this(new Dictionary<ParamKeys, object>
        {
            {ParamKeys.Edge1, edge1},
            {ParamKeys.Edge2, edge2},
            {ParamKeys.Edge3, edge3 },
            {ParamKeys.CoordX, 0 },
            {ParamKeys.CoordY, 0 }
        })
        { }

        public Triangle(IDictionary<ParamKeys, object> parameters) : base(parameters)
        {
            _edge1 = (double)parameters[ParamKeys.Edge1];
            _edge2 = (double)parameters[ParamKeys.Edge2];
            _edge3 = (double)parameters[ParamKeys.Edge3];
        }

        public override double GetPerimeter()
        {
            return (_edge1*Multiplier + _edge2*Multiplier + _edge3*Multiplier);
        }

        protected override double Area()
        {
            var p = (_edge1*Multiplier + _edge2*Multiplier + _edge3*Multiplier)/2;
            return Math.Sqrt(p*(p - _edge1*Multiplier)*(p - _edge2*Multiplier)*(p - _edge3*Multiplier));
        }
    }
}
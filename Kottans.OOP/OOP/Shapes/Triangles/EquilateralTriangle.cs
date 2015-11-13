using System;
using System.Collections.Generic;

namespace OOP.Shapes.Triangles
{
    /// <summary>
    /// triangle where all edges are equal
    /// </summary>
    public class EquilateralTriangle : Triangle
    {
        private double _edge;
        public EquilateralTriangle(double edge1) : base(edge1, edge1, edge1){}

        public EquilateralTriangle(IDictionary<ParamKeys, object> parameters) : base(parameters)
        {
            _edge = (double)parameters[ParamKeys.Edge1];
        }

        protected override double Area()
        {
            return Math.Pow(_edge*Multiplier, 2) * (Math.Sqrt(3)/4);
        }

        public override double GetPerimeter()
        {
            return 3 * _edge * Multiplier;
        }
    }
}
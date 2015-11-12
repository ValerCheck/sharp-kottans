using System;
using System.Collections.Generic;

namespace OOP.Shapes.Triangles
{
    /// <summary>
    /// Triangle with one 90 degrees corner
    /// </summary>
    public class RightTriangle : Triangle
    {
        private double _edge1, _edge2, _hypotenuze;

        public RightTriangle(double edge1, double edge2, double edge3) : base(edge1, edge2, edge3){}

        public RightTriangle(IDictionary<ParamKeys, object> parameters) : base(parameters)
        {
            _edge1 = (double)parameters[ParamKeys.Edge1];
            _edge2 = (double)parameters[ParamKeys.Edge2];
            _hypotenuze = (double)parameters[ParamKeys.Edge3];
        }

        protected override double Area()
        {
            return (_edge1*_edge2*Math.Pow(Multiplier,2))/2;
        }
    }
}
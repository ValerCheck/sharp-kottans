using System;
using System.Collections.Generic;
namespace OOP.Shapes
{
	public class Circle : ShapeBase
	{
        double _radius;

        public Circle(double radius)
            : this(new Dictionary<ParamKeys, object> { 
                {ParamKeys.Radius, radius},
                {ParamKeys.CoordX, 0},
                {ParamKeys.CoordY, 0}
            })
        {}

		public Circle(IDictionary<ParamKeys, object> parameters) : base(parameters)
		{
            _radius = (double) parameters[ParamKeys.Radius];
		}

	    public override double GetPerimeter()
	    {
	        return 2*Math.PI*_radius*Multiplier;
	    }

	    protected override double Area()
	    {
	        return Math.PI*Math.Pow(_radius, 2)* Math.Pow(Multiplier, 2);
	    }

	    public override void Move(int deltaX, int deltaY)
	    {
	        CoordX += deltaX;
	        CoordY += deltaY;
	    }

	    public override string ShapeName => GetType().Name;
	}
}
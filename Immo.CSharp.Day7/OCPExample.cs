using System;

namespace Immo.CSharp.Day7
{
    public abstract class Shapes
    {
        public abstract double CalculateArea();
    }

    public class Circle : Shapes
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    public class Rectangle : Shapes
    {
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double Width { get; set; }
        public double Height { get; set; }

        public override double CalculateArea()
        {
            return Width * Height;
        }
    }

    public class Triange : Shapes
    {
        public override double CalculateArea()
        {
            throw new NotImplementedException();
        }
    }

    //public class ShapeCalc
    //{
    //    public double Calculate(object obj)
    //    {
    //        double result = 0.0;
    //        if (obj is Circle circle)
    //        {
    //            // Circle circle = new Circle(10);
    //            result = Math.PI * circle.Radius * circle.Radius;
    //        }
    //        else if (obj is Rectangle rect)
    //        {
    //            result = rect.Width * rect.Height;
    //        }

    //        else if(obj is Triange tr)
    //        {

    //        }

    //        return result;
    //    }
    //}
}

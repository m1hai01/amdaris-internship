

namespace CsharpBasics
{
    class Circle : Shape
    {
        private double Radius { get; set; }

        //lambda
        //public double Area => Math.PI * Radius * Radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }

    }
}

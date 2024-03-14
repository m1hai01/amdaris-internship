namespace CsharpBasics
{
    class Triangle : Shape
    {
        private double side1, side2, side3;

        //three sides provided
        public Triangle(double side1, double side2, double side3)
        {
            if (!IsValidTriangle(side1, side2, side3))
                throw new ArgumentException("Invalid triangle sides");

            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;
        }

        //base and height provided
        public Triangle(double triangleBase, double height)
        {
            if (triangleBase <= 0 || height <= 0)
                throw new ArgumentException("Base and height must be positive");

            this.side1 = triangleBase;
            this.side2 = height;
            this.side3 = Math.Sqrt(Math.Pow(triangleBase / 2, 2) + Math.Pow(height, 2));
        }

        //check if given sides form a valid triangle
        private bool IsValidTriangle(double side1, double side2, double side3)
        {
            return side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1;
        }

        public override double Area()
        {
            double s = (side1 + side2 + side3) / 2;
            return Math.Sqrt(s * (s - side1) * (s - side2) * (s - side3));
        }
    }
}

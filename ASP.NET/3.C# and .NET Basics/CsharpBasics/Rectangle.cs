namespace CsharpBasics
{
    class Rectangle : Shape
    {
        //fields with properties
        private double Width { get; set; }
        public double Height { get; set; }

        //constructor
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double Area()
        {
            return Width * Height;
        }



    }
}

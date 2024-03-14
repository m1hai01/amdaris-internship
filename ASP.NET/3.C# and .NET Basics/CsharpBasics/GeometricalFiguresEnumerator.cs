

using System.Collections;

namespace CsharpBasics
{
    class GeometricalFiguresEnumerator : IEnumerator
    {
        private string[] shapes;
        private int position = -1;

        public GeometricalFiguresEnumerator(string[] shapes)
        {
            this.shapes = shapes;
        }
        public object Current
        {
            get
            {
                if (position == -1 || position >= shapes.Length)
                    throw new ArgumentException();
                return shapes[position];
            }
        }
        public bool MoveNext()
        {
            if (position < shapes.Length - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }
        public void Reset() => position = -1;
    }
}

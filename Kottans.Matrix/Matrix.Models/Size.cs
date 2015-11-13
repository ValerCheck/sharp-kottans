namespace Matrix.Models
{
    public class Size
    {
        public override int GetHashCode()
        {
            unchecked
            {
                return (Width*397) ^ Height;
            }
        }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public bool IsSquare
        {
            get { return Width == Height; }
        }

        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Size) obj);
        }

        protected bool Equals(Size obj)
        {
            return Width == obj.Width && Height == obj.Height;
        }

        public static bool operator ==(Size a, Size b)
        {
            if (ReferenceEquals(a, b)) return true;
            if ( ((object)a == null) || ((object)b == null))
            {
                return false;
            }
            return a.Height == b.Height && a.Width == b.Width;
        }

        public static bool operator !=(Size a, Size b)
        {
            return !(a == b);
        }
    }
}

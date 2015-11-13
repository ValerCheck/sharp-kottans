using System;

namespace Matrix.Models
{
    public class CoolMatrix
    {
        protected bool Equals(CoolMatrix other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CoolMatrix) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_matrix?.GetHashCode() ?? 0)*397) ^ (Size?.GetHashCode() ?? 0);
            }
        }

        public Size Size { get; }
        private readonly int[,] _matrix;

        public bool IsSquare => Size.IsSquare;

        public int this[int y,int x]
        {
            get
            {
                if (x >= Size.Height || y >= Size.Width)
                    throw new IndexOutOfRangeException();
                return _matrix[y, x];
            }
            private set { _matrix[y, x] = value; }
        }

        public CoolMatrix(int[,] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            Size = new Size(array.GetLength(0), array.GetLength(1));
            _matrix = array;
        }

        public CoolMatrix Transpose()
        {
            var arr = new int[Size.Height, Size.Width];

            for (var i = 0; i < Size.Width; i++)
            {
                for (var j = 0; j < Size.Height; j++)
                {
                    arr[j,i] = this[i,j];
                }
            }
            return arr;
        }

        public static implicit operator CoolMatrix(int[,] array)
        {
            return new CoolMatrix(array);
        }

        public override string ToString()
        {
            var result = "";
            for(var i=0;i<Size.Height;i++)
            {
                result += "[";
                for (var j = 0; j < Size.Width; j++)
                {
                    result += j == 0 ? "" : ", ";
                    result += _matrix[i, j];
                }
                result += "]";
                result += i == Size.Height - 1 ? "" : Environment.NewLine;
            }
            return result;
        }

        public static bool operator ==(CoolMatrix mrxA, CoolMatrix mrxB)
        {
            if ( (object)mrxA == null && (object)mrxB == null) return true;
            if ((object) mrxA == null || (object) mrxB == null) return false;
            if (mrxA.Size.Width != mrxB.Size.Width || mrxA.Size.Height != mrxB.Size.Height) return false;

            for (var i = 0; i < mrxA.Size.Width; i++)
            {
                for (var j = 0; j < mrxA.Size.Height; j++)
                {
                    if (mrxA[i, j] != mrxB[i, j]) return false;
                }
            }
                
            return true;
        }

        public static CoolMatrix operator +(CoolMatrix mrxA, CoolMatrix mrxB)
        {
            if ((object)mrxA == null || (object)mrxB == null) throw new ArgumentException($"{nameof(mrxA)} {nameof(mrxB)}");
            if (mrxA.Size.Width != mrxB.Size.Width || mrxA.Size.Height != mrxB.Size.Height) throw new ArgumentException($"{nameof(mrxA)} {nameof(mrxB)}");

            var arr = new int[mrxA.Size.Height,mrxA.Size.Width];

            for (var i = 0; i < mrxA.Size.Height; i++)
            {
                for (var j = 0; j < mrxA.Size.Width; j++)
                {
                    arr[j, i] = mrxA[j, i] + mrxB[j, i];
                }
            }

            return new CoolMatrix(arr);
        }

        public static bool operator !=(CoolMatrix mrxA, CoolMatrix mrxB)
        {
            return !(mrxA == mrxB);
        }

        public static CoolMatrix operator *(CoolMatrix matrix,int mul)
        {
            for (var i = 0; i < matrix.Size.Height; i++)
            {
                for (var j = 0; j < matrix.Size.Width; j++)
                {
                    matrix[j, i] *= mul;
                }
            }
            return matrix;
        }
    }
}

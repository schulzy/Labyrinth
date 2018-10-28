namespace Domain.Model
{
    internal struct Point
    {
        

        public int X;
        public int Y;

        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void SetX(int x)
        {
            X = x;
        }

        public void SetY(int y)
        {
            Y = y;
        }

        public override string ToString()
        {
            return $"X:{X} Y:{Y}";
        }

        public static bool operator ==(Point a, Point b)
        {
            if (a.Y == b.Y && a.X == b.X)
                return true;

            return false;
        }

        public static bool operator !=(Point a, Point b)
        {
            return !(a == b);
        }

        public bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Point && Equals((Point)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }
}
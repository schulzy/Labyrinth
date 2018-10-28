using System;

namespace Domain.Model
{
    internal class Map
    {
        private readonly bool[,] _field;
        private Point _finishPosition;
        private Point _startPosition;

        public Map(bool[,] field)
        {
            _field = field;
            Size = new Size(_field.GetLength(0), _field.GetLength(1));
        }

        public Size Size { get; }

        public Point StartPosition
        {
            get => _startPosition;
            set
            {
                if (GetPosition(value))
                    _startPosition = value;
                else
                    throw new ArgumentException(nameof(StartPosition));
            }
        }

        public Point FinishPosition
        {
            get => _finishPosition;
            set
            {
                if (GetPosition(value))
                    _finishPosition = value;
                else
                    throw new ArgumentException(nameof(FinishPosition));
            }
        }

        public bool GetPosition(Point positon)
        {
            if (!IsValid(positon))
                return false;

            return _field[positon.X, positon.Y];
        }

        private bool IsValid(Point positon)
        {
            if (positon.X < 0 || positon.X > Size.Column - 1)
                return false;
            if (positon.Y < 0 || positon.Y > Size.Row - 1)
                return false;

            return true;
        }
    }
}
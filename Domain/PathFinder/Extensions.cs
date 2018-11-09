using System;
using Domain.Model;

namespace Domain.PathFinder
{
    internal static class Extensions
    {
        public static Point GetNextPoint(this Point positon, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    positon.SetY(positon.Y - 1);
                    break;
                case Direction.Down:
                    positon.SetY(positon.Y + 1);
                    break;
                case Direction.Left:
                    positon.SetX(positon.X - 1);
                    break;
                case Direction.Right:
                    positon.SetX(positon.X + 1);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction));
            }

            return positon;
        }
    }
}

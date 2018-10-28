using System;
using System.Collections.Generic;
using System.IO;
using Domain.Interface;
using Domain.Model;

namespace Domain.PathFinder.SlowStrategy
{
    internal class SlowPathFinder : IPathFinder
    {
        private readonly HashSet<Point> _deadEnd = new HashSet<Point>();
        private readonly HashSet<Point> _pointsHash = new HashSet<Point>();
        private readonly Stack<Direction> _pointsStack = new Stack<Direction>();
        private Map _map;

        public void FindPath(IMapCreator creator)
        {
            _map = creator.CreateMap();

            StartSearching();
        }

        private void StartSearching()
        {
            _pointsHash.Add(_map.StartPosition);
            foreach (var direction in (Direction[]) Enum.GetValues(typeof(Direction)))
            {
                _pointsStack.Clear();
                _pointsHash.Clear();
                _deadEnd.Clear();
                StepThere(_map.StartPosition, direction);
            }
        }

        private void StepThere(Point positon, Direction direction)
        {
            var nextPoint = GetPoint(positon, direction);
            if (!_deadEnd.Contains(nextPoint) && _pointsHash.Add(nextPoint))
                if (_map.GetPosition(nextPoint))
                {
                    _pointsStack.Push(direction);
                    Console.WriteLine(nextPoint);
                    if (_map.FinishPosition == nextPoint)
                    {
                        WriteOutThePath();
                    }
                    else
                    {
                        foreach (var subDirection in (Direction[]) Enum.GetValues(typeof(Direction)))
                            StepThere(nextPoint, subDirection);
                        _pointsHash.Remove(nextPoint);
                        _pointsStack.Pop();
                        _deadEnd.Add(nextPoint);
                    }
                }
                else
                {
                    _deadEnd.Add(nextPoint);
                    _pointsHash.Remove(nextPoint);
                }
        }

        private void WriteOutThePath()
        {
            foreach (var element in _pointsStack)
                File.AppendAllText(
                    $@"d:\temp\ordered{DateTime.Now.Hour}.{DateTime.Now.Minute}.{DateTime.Now.Second}.txt",
                    element + " ");
        }

        private Point GetPoint(Point positon, Direction direction)
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
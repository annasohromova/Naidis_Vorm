using jalgpall;
using System;
using uss12;

namespace jagpall
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char sym { get; set; }

        public Point()
        {
        }

        public Point(int x, int y, char sym)
        {
            X = x;
            Y = y;
            this.sym = sym;
        }

        public Point(Point p)
        {
            X = p.X;
            Y = p.Y;
            sym = p.sym;
        }

        public void Move(int offset, Direction direction)
        {
            if (direction == Direction.RIGHT)
            {
                X += offset;
            }
            else if (direction == Direction.LEFT)
            {
                X -= offset;
            }
            else if (direction == Direction.UP)
            {
                Y -= offset;
            }
            else if (direction == Direction.DOWN)
            {
                Y += offset;
            }
        }

        public bool IsHit(Point p)
        {
            return X == p.X && Y == p.Y;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(sym);
        }

        public void Clear()
        {
            sym = ' ';
            Draw();
        }

        public override string ToString()
        {
            return X + ", " + Y + ", " + sym;
        }
    }
}
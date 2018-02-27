using System;
using System.Collections.Generic;
using System.Text;

namespace Triangles.Shapes
{
    /// <summary>
    /// Could have use System.Drawing instead, but keep it nice and clean
    /// </summary>
    public class Point

    {
        public Point() { }
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            bool results = false;
            if (obj is Point)
            {
                Point p = (Point)obj;
                if (p.X == this.X && p.Y == this.Y)
                {
                    results = true;
                }

            }
            return results;
        }

        /// <summary>
        /// This will return the same hash code for different objects occasionally
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return int.Parse(this.X.ToString() + this.Y.ToString());
        }
        public override string ToString()
        {
            return $"{this.X}, {this.Y}";
        }


    }
}

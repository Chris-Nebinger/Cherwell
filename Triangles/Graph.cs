using System;
using System.Collections.Generic;
using System.Text;
using Triangles.Shapes;
using System.Linq;
namespace Triangles
{
    public class Graph
    {

        public Graph()
        {
            //Set the default values, but that can be changed
            this.Rows = 6;
            this.Columnns = 12;
            this.Pixels = 10;
        }


        /// <summary>
        /// Initializes the graph based on Rows, Columns, and Pixels
        /// </summary>
        public void Initialize()
        {
            this.Triangles = new List<Triangle>();
            for (int r = 1; r <= this.Rows; r++)
            {
                for (int c = 1; c <= this.Columnns; c++)
                {
                    Triangle t = new Triangle(r, c, this.Pixels);
                    this.Triangles.Add(t);
                }
            }

        }




        public List<Triangle> Triangles { get; set; }
        /// <summary>
        /// How many rows to include in the graph
        /// </summary>
        public int Rows { get; set; }
        /// <summary>
        /// How many columns to include in the graph
        /// </summary>
        public int Columnns { get; set; }
        /// <summary>
        /// How many pixels tall it should be
        /// </summary>
        public int Pixels { get; set; }

        /// <summary>
        /// Finds a Triangle
        /// </summary>
        /// <param name="row">row to search</param>
        /// <param name="column">column to search</param>
        /// <returns>Matching Triangle</returns>
        public Triangle Find(string row, int column)
        {
            if (row.Length > 1) { throw new ArgumentException("Only 1 letter for the row, please"); }

            try
            {
                char charRow = row.ToCharArray()[0];
                int r = charRow - 64;
                if (r < 0 || r > this.Rows) { throw new ArgumentException($"I only have {this.Rows} rows, not {r}"); }
                if (column < 0 || column > this.Columnns * 2) { throw new ArgumentException($"I only have {this.Columnns * 2} columns, not {column}"); }
                Triangle tri = this.Triangles.FirstOrDefault(t => t.Row == r && t.Column == column);
                return tri;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>                                   
        /// Finds a Triangle
        /// </summary>
        /// <param name="p1">Point to check</param>
        /// <param name="p2">Point to check</param>
        /// <param name="p3">Point to check</param>
        /// <returns>Matching Triangle</returns>
        public Triangle Find(Point p1, Point p2, Point p3)
        {
            //A little complex, but it does compare all three points against all three in the list
            //No guarantee of performance!
            try
            {
                return this.Triangles.FirstOrDefault(t =>
                        (t.Points[0].Equals(p1) || t.Points[1].Equals(p1) || t.Points[2].Equals(p1)) &&
                        (t.Points[0].Equals(p2) || t.Points[1].Equals(p2) || t.Points[2].Equals(p2)) &&
                        (t.Points[0].Equals(p3) || t.Points[1].Equals(p3) || t.Points[2].Equals(p3))
                    );
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        ///   Finds a Triangle
        /// </summary>
        /// <param name="V1x">X location of first point</param>
        /// <param name="V1y">Y location of first point</param>
        /// <param name="V2x">X location of second point</param>
        /// <param name="V2y">Y location of second point</param>
        /// <param name="V3x">X location of third point</param>
        /// <param name="V3y">Y location of third point</param>
        /// <returns>Matching Triangle</returns>

        public Triangle Find(int V1x, int V1y, int V2x, int V2y, int V3x, int V3y)
        {
            return this.Find(new Point(V1x, V1y), new Point(V2x, V2y), new Point(V3x, V3y));
        }
    }
}

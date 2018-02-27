using System;
using System.Collections.Generic;
using System.Text;

namespace Triangles.Shapes
{
    public enum Location
    {
        Top, Bottom
    }
    public class Triangle
    {

        public Triangle()
        {
            this.Points = new List<Point>();
        }

        public Triangle(int row, int column, int pixels = 10)
        {
            this.Row = row;
            this.Column = column;
            //Add the points       
            this.Points = new List<Point>();
            //Set the starting place
            int startX = (this.Column - 1) / 2 * pixels;
            int startY = (this.Row - 1) * pixels;

            //if the column is even (remember, we are 1 based!) 
            if (column.IsOdd())
            {
                //Jump down by the number of pixels that we are using
                startY += pixels;
            }


            //Point 1 is easy, it's the start...                     
            this.Points.Add(new Point(startX, startY));
            //Point 2 goes out n pixels
            this.Points.Add(new Point(startX + pixels, startY));
            //For Point 3, if it is a odd number (remember, we are 1 based):
            if (column.IsOdd())
            {
                //It is n pixels higher (lower Y value) than P1, same X coordinates
                this.Points.Add(new Point(startX, startY - pixels));
            }
            else
            {
                ///it is n points lower (Higher X  value) than p2, same Y coordinates 
                this.Points.Add(new Point(startX + pixels, startY + pixels));
            }
        }

        //public Triangle(Point[] points)
        //{
        //    if (points.Length > 3)
        //    {
        //        throw new ArgumentOutOfRangeException("A triangle has, what, 3 points?");
        //    }
        //    this.Points = points;
        //}


        /// <summary>
        /// Another option here is an Array, but I like Lists.  I could add an  ObservableCollection(T), but for this we'll let it slide
        /// </summary>
        public List<Point> Points { get; set; }
        /// <summary>
        ///  defined as 0-n
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Columns defined as 0-n
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// Converts the 1 based row number to letter 'A' based row 
        /// </summary>
        /// <returns>A for first row, B for second, etc.</returns>
                        
        public string ToRowString() { return Char.ConvertFromUtf32(this.Row + 64); }

        public string ToShortString()
        {
            return $"{this.ToRowString()}{this.Column}";
        }
        public override string ToString()
        {
            return $"{this.ToRowString()}{this.Column} ******* {this.Corners}";
        }


        public string Corners
        {
            get
            {
                return $"{Points[0].ToString()}            {Points[1].ToString()}             {Points[2].ToString()}";
            }
        }
    }

}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Triangles;       
using System.Linq;
namespace Nebinger.Tests
{
    [TestClass]
    public class UnitTest1
    {

        private Graph graph;
        private int rows;
        private int columns;
        [TestInitialize]
        public void InitializeGraph()
        {
        
            rows = 6;
            columns =12;
            graph = new Graph() { Rows = rows, Columnns = columns, Pixels = 10 };
            graph.Initialize();
        }
        [TestMethod]
        public void TestGraphCreation()
        {
            Assert.AreEqual(rows * columns, graph.Triangles.Count);
        }


        [TestMethod]
        public void TestC5()
        {
            Triangles.Shapes.Triangle triangle = graph.Find("C", 5);
            Assert.AreEqual("C5", triangle.ToShortString());
            Assert.AreEqual(1, triangle.Points.Count(p => p.X == 20 && p.Y == 30));
            Assert.AreEqual(1, triangle.Points.Count(p => p.X == 20 && p.Y == 20));
            Assert.AreEqual(1, triangle.Points.Count(p => p.X == 30 && p.Y == 30));

        }   
        [TestMethod]
        public void TestC6()
        {
            Triangles.Shapes.Triangle triangle = graph.Find("C",6);
            Assert.AreEqual("C6", triangle.ToShortString());
            Assert.AreEqual(1, triangle.Points.Count(p => p.X == 30 && p.Y == 20));
            Assert.AreEqual(1, triangle.Points.Count(p => p.X == 20 && p.Y == 20));
            Assert.AreEqual(1, triangle.Points.Count(p => p.X == 30 && p.Y == 30));

        }

        [TestMethod]
        public void TestVertexes()
        {
            Triangles.Shapes.Triangle triangle = graph.Find(20, 40, 30, 40, 30, 50);
            Assert.AreEqual("E6", triangle.ToShortString());

        }

        [TestMethod]
        public void TestPoints()
        {       
            Triangles.Shapes.Point point1 = new Triangles.Shapes.Point(40,40);
            Triangles.Shapes.Point point2 = new Triangles.Shapes.Point(40,50);
            Triangles.Shapes.Point point3 = new Triangles.Shapes.Point(50,50);
            Triangles.Shapes.Triangle triangle = graph.Find(point1, point2, point3);
            Assert.AreEqual("E9", triangle.ToShortString());

        }
    }
}

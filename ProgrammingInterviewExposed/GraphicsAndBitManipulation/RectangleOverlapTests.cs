using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProgrammingInterviewExposed.GraphicsAndBitManipulation
{
    public class RectangleOverlapTests
    {
        [Fact]
        public void CalculatesOverlappingRight()
        {
            var r1 = new Rect(new Point(100, 300), new Point(200, 100));

            var r2left=new Rect(new Point(10, 200), new Point(90, 100));
            var r2leftIntersect = new Rect(new Point(10, 200), new Point(150, 100));
            var r2Inside = new Rect(new Point(110, 200), new Point(150, 120));
            var r2RightIntersect = new Rect(new Point(110, 200), new Point(250, 120));
            var r2Right = new Rect(new Point(210, 200), new Point(250, 120));


            Assert.False(RectangleOverlap.Overlap(r1, r2left));
            Assert.True(RectangleOverlap.Overlap(r1, r2leftIntersect));
            Assert.True(RectangleOverlap.Overlap(r1, r2Inside));
            Assert.True(RectangleOverlap.Overlap(r1, r2RightIntersect));
            Assert.False(RectangleOverlap.Overlap(r1, r2Right));
        }
    }
}

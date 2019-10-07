using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProgrammingInterviewExposed.TreesAndGraphs
{
    public class HeightOfATreeTests
    {
        [Fact]
        public void CalculateHeightRight()
        {
            var root = new Node()
            {
                Left = new Node()
                {
                    Left = new Node()
                    {
                        Left = new Node(),
                        Right = new Node()
                        {
                            Right = new Node()
                        },
                    },
                    Right = new Node(),
                },
                Right = new Node()
                {
                    Left = new Node(),
                    Right = new Node(),
                }
            };

            var calc = new HeightCalculator();
            Assert.Equal(5, calc.CalcTreeHeightBinaryTree(root));

        }
    }
}

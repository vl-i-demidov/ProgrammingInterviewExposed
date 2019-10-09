using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProgrammingInterviewExposed.TreesAndGraphs
{
    public class SixDegreesOfKevinBaconTests
    {
        [Fact]
        public void CalculatesDegreeRight()
        {
            var graph = new Dictionary<string, string[]>
            {
                { "A1", new []{"M1", "M2", "M3", "M4"}},
                { "A2", new []{"M1", "M4", "M5"}},
                { "A3", new []{"M3", "M4", "M5", "M6"}},
                { "Bacon", new []{ "M6" } }
            };

            var resolver = new BaconDegreeResolver();
            resolver.LoadData(graph);
            var degree = resolver.GetBaconDegree("A1");

            Assert.Equal(1, degree);
        }

    }
}

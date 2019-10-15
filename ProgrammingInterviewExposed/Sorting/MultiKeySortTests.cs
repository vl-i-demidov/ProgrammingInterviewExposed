using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;

namespace ProgrammingInterviewExposed.Sorting
{
    public class MultiKeySortTests
    {
        [Fact]
        public void SortsRight()
        {
            var data = new[]
            {
                new Employee
                {
                    Surname="S3",
                    GivenName="G2"
                },
                new Employee
                {
                    Surname="S3",
                    GivenName="G3"
                },
                new Employee
                {
                    Surname="S3",
                    GivenName="G1"
                },
                new Employee
                {
                    Surname="S2",
                    GivenName="G2"
                },
                new Employee
                {
                    Surname="S1",
                    GivenName="G1"
                },
            };

            MultiKeySort.Sort(data);

            var expSurnames = new[] { "S1", "S2", "S3", "S3", "S3" };
            var expGivenNames = new[] { "G1", "G2", "G1", "G2", "G3" };

            Assert.Equal(expSurnames, data.Select(e => e.Surname).ToArray());
            Assert.Equal(expGivenNames, data.Select(e => e.GivenName).ToArray());
        }

        [Fact]
        public void SortsRight2()
        {
            var data = new[]
            {
                new Employee
                {
                    Surname="S3",
                    GivenName="G2"
                },
                new Employee
                {
                    Surname="S3",
                    GivenName="G3"
                },
                new Employee
                {
                    Surname="S3",
                    GivenName="G1"
                },
                new Employee
                {
                    Surname="S2",
                    GivenName="G2"
                },
                new Employee
                {
                    Surname="S1",
                    GivenName="G1"
                },
            };

            MultiKeySort2.Sort(data);

            var expSurnames = new[] { "S1", "S2", "S3", "S3", "S3" };
            var expGivenNames = new[] { "G1", "G2", "G1", "G2", "G3" };

            Assert.Equal(expSurnames, data.Select(e => e.Surname).ToArray());
            Assert.Equal(expGivenNames, data.Select(e => e.GivenName).ToArray());
        }
    }
}

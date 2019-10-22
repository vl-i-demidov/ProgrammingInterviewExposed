using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ProgrammingInterviewExposed.Concurrency
{
    public class TheDiningPhilosophersTests
    {
        private readonly ITestOutputHelper _output;

        public TheDiningPhilosophersTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void NoDeadlockOccurs()
        {
            var dp = new TheDiningPhilosophers(5, _output.WriteLine);

            dp.StartEating();

            Task.Delay(5000).Wait();

            _output.WriteLine("Finish");
        }
    }
}

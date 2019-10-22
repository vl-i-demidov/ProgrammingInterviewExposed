using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ProgrammingInterviewExposed.Concurrency
{
    public class ProducerConsumerTests
    {
        [Fact]
        public void ConsumesAllProducedNums()
        {
            const int bufferSize = 100;
            const int numCount = bufferSize * 100000;
            var pc = new ProducerConsumer(bufferSize, numCount);

            pc.StartConsume();
            var produceTask = pc.StartProduce();

            produceTask.Wait();
            Task.Delay(1000).Wait();


            Assert.Equal(numCount, pc.Consumed.Count);
            Assert.Equal(numCount, pc.Consumed.Distinct().Count());
        }
    }
}

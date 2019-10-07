using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProgrammingInterviewExposed.LinkedList
{
    public class NullOrCycleTests
    {
        [Fact]
        public void NullDeterminedRight()
        {
            var n1 = new LinkedListElement<int>(1);
            var n2 = new LinkedListElement<int>(1);
            var n3 = new LinkedListElement<int>(1);
            var n4 = new LinkedListElement<int>(1);
            n1.SetNext(n2);
            n2.SetNext(n3);
            n3.SetNext(n4);

            var ncr = new NullOrCycleResolver();
            Assert.False(ncr.IsCyclicList(n1));
        }

        [Fact]
        public void CycleDeterminedRight()
        {
            var n1 = new LinkedListElement<int>(1);
            var n2 = new LinkedListElement<int>(1);
            var n3 = new LinkedListElement<int>(1);
            var n4 = new LinkedListElement<int>(1);
            n1.SetNext(n2);
            n2.SetNext(n3);
            n3.SetNext(n4);
            n4.SetNext(n2);

            var ncr = new NullOrCycleResolver();
            Assert.True(ncr.IsCyclicList(n1));
        }

        [Fact]
        public void NullDeterminedFloydRight()
        {
            var n1 = new LinkedListElement<int>(1);
            var n2 = new LinkedListElement<int>(1);
            var n3 = new LinkedListElement<int>(1);
            var n4 = new LinkedListElement<int>(1);
            n1.SetNext(n2);
            n2.SetNext(n3);
            n3.SetNext(n4);

            var ncr = new NullOrCycleResolver();
            Assert.False(ncr.IsCyclicListFloyd(n1));
        }

        [Fact]
        public void CycleDeterminedFloydRight()
        {
            var n1 = new LinkedListElement<int>(1);
            var n2 = new LinkedListElement<int>(1);
            var n3 = new LinkedListElement<int>(1);
            var n4 = new LinkedListElement<int>(1);
            n1.SetNext(n2);
            n2.SetNext(n3);
            n3.SetNext(n4);
            n4.SetNext(n2);

            var ncr = new NullOrCycleResolver();
            Assert.True(ncr.IsCyclicListFloyd(n1));
        }

    }
}

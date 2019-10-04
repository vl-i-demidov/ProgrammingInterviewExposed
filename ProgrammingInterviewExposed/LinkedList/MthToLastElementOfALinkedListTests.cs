using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProgrammingInterviewExposed.LinkedList
{
    public class MthToLastElementOfALinkedListEfficientTests : MthToLastElementOfALinkedListTests
    {
        protected override IMthToLastLinkedList<T> CreateArray<T>()
        {
            return new MthToLastLinkedListNoCounterEfficient<T>();
        }
    }

    public class MthToLastElementOfALinkedListTimeEfficientTests : MthToLastElementOfALinkedListTests
    {
        protected override IMthToLastLinkedList<T> CreateArray<T>()
        {
            return new MthToLastLinkedListTimeEfficient<T>();
        }
    }

    public class MthToLastElementOfALinkedListSpaceEfficientTests : MthToLastElementOfALinkedListTests
    {
        protected override IMthToLastLinkedList<T> CreateArray<T>()
        {
            return new MthToLastLinkedListSpaceEfficient<T>();
        }
    }

    public class MthToLastElementOfALinkedListNoCounterTests : MthToLastElementOfALinkedListTests
    {
        protected override IMthToLastLinkedList<T> CreateArray<T>()
        {
            return new MthToLastLinkedListNoCounter<T>();
        }
    }

    public abstract class MthToLastElementOfALinkedListTests
    {
        [Fact]
        public void WhenMIsZeroReturnsLast()
        {
            var list = CreateArray<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);

            Assert.Equal(3, list.FindMthToLast(0).Data);
        }

        [Fact]
        public void WhenMIsCountMinus1ReturnsHead()
        {
            var list = new MthToLastLinkedListSpaceEfficient<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);

            Assert.Equal(1, list.FindMthToLast(2).Data);
        }

        [Fact]
        public void WhenMIsInTheMiddleReturnsRightResult()
        {
            var list = new MthToLastLinkedListSpaceEfficient<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            Assert.Equal(3, list.FindMthToLast(2).Data);
        }

        protected abstract IMthToLastLinkedList<T> CreateArray<T>();
    }

}

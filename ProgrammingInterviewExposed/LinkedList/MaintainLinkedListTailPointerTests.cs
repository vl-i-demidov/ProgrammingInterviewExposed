using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProgrammingInterviewExposed.LinkedList
{
    public class MaintainLinkedListTailPointerTests
    {
        [Fact]
        public void HeadAndTailCorrectAfterAdd()
        {
            var list = new DeleteInsertAfterLinkedList<int>();

            var e1 = list.Add(1);
            var e2 = list.Add(2);
            var e3 = list.Add(3);

            Assert.Equal(e1.Data, list.Head.Data);
            Assert.Equal(e3.Data, list.Tail.Data);
        }

        [Fact]
        public void DeleteHeadChangesHead()
        {
            var list = new DeleteInsertAfterLinkedList<int>();

            var e1 = list.Add(1);
            var e2 = list.Add(2);
            var e3 = list.Add(3);

            list.Delete(e1);

            Assert.Equal(e2.Data, list.Head.Data);
        }

        [Fact]
        public void DeleteTailChangesTail()
        {
            var list = new DeleteInsertAfterLinkedList<int>();

            var e1 = list.Add(1);
            var e2 = list.Add(2);
            var e3 = list.Add(3);

            list.Delete(e3);
            
            Assert.Equal(e2.Data, list.Tail.Data);
        }

        [Fact]
        public void DeleteSingleElementResetsTailAndHead()
        {
            var list = new DeleteInsertAfterLinkedList<int>();

            var e1 = list.Add(1);

            list.Delete(e1);

            Assert.Null(list.Head);
            Assert.Null(list.Tail);
        }


        [Fact]
        public void InsertHeadChangesHead()
        {
            var list = new DeleteInsertAfterLinkedList<int>();

            var e1 = list.Add(1);
            var e2 = list.Add(2);
            var e3 = list.Add(3);

            var success = list.InsertAfter(null, 0);

            Assert.Equal(0, list.Head.Data);
        }

        [Fact]
        public void InsertTailChangesTail()
        {
            var list = new DeleteInsertAfterLinkedList<int>();

            var e1 = list.Add(1);
            var e2 = list.Add(2);
            var e3 = list.Add(3);

            var success = list.InsertAfter(e3, 4);

            Assert.Equal(4, list.Tail.Data);
        }

        [Fact]
        public void InsertMiddleChangesNext()
        {
            var list = new DeleteInsertAfterLinkedList<int>();

            var e1 = list.Add(1);
            var e2 = list.Add(2);
            var e4 = list.Add(4);

            var success = list.InsertAfter(e2, 3);

            Assert.Equal(3, e2.Next.Data);
            Assert.Equal(4, e2.Next.Next.Data);
        }
    }
}

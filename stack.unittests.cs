using System;
using Xunit;
using ConsoleApp7;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void CreateStack_IsEmpty_True()
        {
            Stack s = new Stack();
            Assert.True(s.isEmpty());
        }

        [Fact]
        public void CreateStack_PushIsEmpty_False()
        {
            Stack s = new Stack();
            s.Push("First Object");
            Assert.False(s.isEmpty());
        }

        [Fact]
        public void CreateStack_PushPoPIsEmpty_True()
        {
            Stack s = new Stack();
            s.Push("First Object");
            s.Pop();
            Assert.True(s.isEmpty());
        }

        [Fact]
        public void CreateStack_PushRemPopAreSame_Success()
        {
            Stack s = new Stack();
            s.Push("First Object");
            object result = s.Pop();
            Assert.Equal("First Object", result);
        }

        [Fact]
        public void CreateStack_PushIntRemPopAreSame_Success()
        {
            Stack s = new Stack();
            s.Push(10);
            object result = s.Pop();
            Assert.Equal(10, result);
        }

        [Fact]
        public void CreateStack_PushTwoRemPopAreSame_Success()
        {
            Stack s = new Stack();
            s.Push(10);
            s.Push(20);
            object result = s.Pop();
            Assert.Equal(20, result);
        }

        [Fact]
        public void CreateStack_PushTwoRemPopTwoAreSame_Success()
        {
            Stack s = new Stack();
            s.Push(10);
            s.Push(20);
            object result1 = s.Pop();
            object result2 = s.Pop();
            Assert.Equal(20, result1);
            Assert.Equal(10, result2);
        }

        [Fact]
        public void CreateStack_Pop_Exception()
        {
            Stack s = new Stack();

            Assert.Throws<InvalidOperationException>(() => s.Pop());
        }

        [Fact]
        public void CreateStack_PushTop_Match()
        {
            Stack s = new Stack();
            s.Push("a string");
            object topvalue = s.Top();
            Assert.Equal("a string", topvalue);

        }

        [Fact]
        public void CreateStack_Top_Exception()
        {
            Stack s = new Stack();

            Assert.Throws<InvalidOperationException>(() => s.Top());
        }



    }
}

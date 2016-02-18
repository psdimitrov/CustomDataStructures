namespace CustomDataStructuresTests
{
    using System;

    using CustomDataStructures;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CustomStackTests
    {
        private CustomStack<int> stack;

        [TestInitialize]
        public void TestInitiallize()
        {
            this.stack = new CustomStack<int>();
        }

        [TestMethod]
        public void PushTest_OneElementPushed_CountIsOne()
        {
            this.stack.Push(5);

            Assert.AreEqual(1, this.stack.Count);
        }

        [TestMethod]
        public void PushTest_TwoElementsPushed_CountIsTwo()
        {
            this.stack.Push(5);
            this.stack.Push(1);

            Assert.AreEqual(2, this.stack.Count);
        }

        [TestMethod]
        public void CountTest_NoElementsPushed_CountIsZero()
        {

            Assert.AreEqual(0, this.stack.Count);
        }

        [TestMethod]
        public void CustomStackTest_OneElementPusghedAndPopped_ElementPopped()
        {
            this.stack.Push(3);

            var element = this.stack.Pop();

            Assert.AreEqual(3, element, "Element is wrong");
        }

        [TestMethod]
        public void PopTest_PushedSeveralElementsPoppedTwoElements_PoppedElementBeforeLast()
        {
            this.stack.Push(9);
            this.stack.Push(99);
            this.stack.Push(1);

            this.stack.Pop();

            var element = this.stack.Pop();

            Assert.AreEqual(99, element, "Wrong element!");
        }

        [TestMethod]
        public void PopTest_PushedSixElementsPoppedThreeElements_CountIsThree()
        {
            this.stack.Push(9);
            this.stack.Push(99);
            this.stack.Push(1);
            this.stack.Push(100);
            this.stack.Push(19);
            this.stack.Push(1000);

            this.stack.Pop();
            this.stack.Pop();
            this.stack.Pop();

            Assert.AreEqual(3, this.stack.Count, "Wrong count!");
        }

        [TestMethod]
        public void ClearTest()
        {
            this.stack.Push(4);
            this.stack.Push(7);
            this.stack.Push(15);
            this.stack.Push(1);
            this.stack.Push(99);

            this.stack.Clear();
            Assert.AreEqual(0, this.stack.Count, "Wrong");
        }

        [TestMethod]
        public void PeekTest__PushedSeveralElementsPeekedOnce_PeekedLastElement()
        {
            this.stack.Push(1);
            this.stack.Push(4);
            this.stack.Push(7);
            this.stack.Push(15);
            this.stack.Push(1);
            this.stack.Push(99);

            var element = this.stack.Peek();
            Assert.AreEqual(99, element, "Wrong element peeked");
        }

        [TestMethod]
        public void PeekTest__PushedSeveralElementsPeekedOnce_CountIsSameAsCountElementsPushed()
        {
            this.stack.Push(1);
            this.stack.Push(4);
            this.stack.Push(7);
            this.stack.Push(15);
            this.stack.Push(1);
            this.stack.Push(99);

            var element = this.stack.Peek();
            Assert.AreEqual(6, this.stack.Count, "Wrong count after peek");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PeekTest_PeekOnEmptyStack_Exception()
        {
            this.stack.Peek();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopTest_PopOnEmptyStack_Exception()
        {
            this.stack.Pop();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PeekTest_PushedTwoPoppedTwoPeekOnEmptyStack_Exception()
        {
            this.stack.Push(1);
            this.stack.Push(2);
            this.stack.Pop();
            this.stack.Pop();
            this.stack.Peek();
        }

        [TestMethod]
        public void PushTest_PushedElevenItems_ElevenItemsInStack()
        {
            this.stack.Push(1);
            this.stack.Push(2);
            this.stack.Push(3);
            this.stack.Push(4);
            this.stack.Push(5);
            this.stack.Push(6);
            this.stack.Push(7);
            this.stack.Push(8);
            this.stack.Push(9);
            this.stack.Push(10);
            this.stack.Push(11);

            Assert.AreEqual(11, this.stack.Count);
        }

        [TestMethod]
        public void TestCtor_CustomStackCreatedWithCollection_StackCreated()
        {
            CustomStack<int> customStack = new CustomStack<int>(new[] { 1, 2, 3, 4, 5, 6 });

            Assert.AreEqual(6, customStack.Count);
        }
    }
}
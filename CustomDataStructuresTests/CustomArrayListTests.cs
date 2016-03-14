namespace CustomDataStructuresTests
{
    using CustomDataStructures;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CustomArrayListTests
    {
        private CustomArrayList<int> arrayList = new CustomArrayList<int>();

        [TestMethod]
        public void InsertTest()
        {
            this.arrayList = new CustomArrayList<int>(new[] { 1, 2, 3, 4, 5 });

            this.arrayList.Insert(3, 100);

            Assert.AreEqual(100, this.arrayList[3]);
        }

        [TestMethod]
        public void AddTest()
        {
            this.arrayList.Add(1);
            this.arrayList.Add(2);
            this.arrayList.Add(3);
            this.arrayList.Add(4);
            this.arrayList.Add(5);

            Assert.AreEqual(5, this.arrayList.Count);
        }

        [TestMethod]
        public void CustomListTest()
        {
            this.arrayList = new CustomArrayList<int>(new[] { 1, 2, 3, 4, 5, 6 });

            Assert.AreEqual(6, this.arrayList.Count);
        }

        [TestMethod]
        public void CustomListTest_CreatedCustomListWithCapacityFourAddedFiveElements_ListResized()
        {
            this.arrayList = new CustomArrayList<int>(4);

            this.arrayList.Add(1);
            this.arrayList.Add(2);
            this.arrayList.Add(3);
            this.arrayList.Add(4);
            this.arrayList.Add(5);

            Assert.AreEqual(5, this.arrayList.Count);
        }

        [TestMethod]
        public void ClearTest_CreatedAndCleared_ListCleared()
        {
            this.arrayList = new CustomArrayList<int>(new[] { 10, 20, 30, 40, 50 });

            this.arrayList.Clear();

            Assert.AreEqual(0, this.arrayList.Count);
        }

        [TestMethod]
        public void RemoveAtTest_RemoveElement_ElementRemoved()
        {
            this.arrayList = new CustomArrayList<int>(new[] { 10, 20, 30, 40, 50 });

            this.arrayList.RemoveAt(3);

            Assert.AreEqual(4, this.arrayList.Count);
        }

        [TestMethod]
        public void RemoveAtTest_RemoveElementAtIndex3_ElementThatWasIndex4NowIsAtIndex3()
        {
            this.arrayList = new CustomArrayList<int>(new[] { 10, 20, 30, 40, 50 });

            this.arrayList.RemoveAt(3);

            Assert.AreEqual(50, this.arrayList[3]);
        }

        [TestMethod]
        public void RemoveAtTest_RemoveElementAtIndex0_ElementThatWasIndex1NowIsAtIndex0()
        {
            this.arrayList = new CustomArrayList<int>(new[] { 10, 20, 30, 40, 50 });

            this.arrayList.RemoveAt(0);

            Assert.AreEqual(20, this.arrayList[0]);
        }

        [TestMethod]
        public void RemoveAtTest_RemoveElementAtLastIndex_ElementsAreOneLess()
        {
            this.arrayList = new CustomArrayList<int>(new[] { 10, 20, 30, 40, 50 });

            this.arrayList.RemoveAt(this.arrayList.Count - 1);

            Assert.AreEqual(4, this.arrayList.Count);
        }

        [TestMethod]
        public void RemoveTest_CreatedListRemovedElement_ElementRemoved()
        {
            this.arrayList = new CustomArrayList<int>(new[] { 10, 20, 30, 40, 50 });

            this.arrayList.Remove(10);

            Assert.AreEqual(20, this.arrayList[0]);
        }

        [TestMethod]
        public void RemoveTest_CreatedListRemoveElement_ElementRemovedThirdElementSecond()
        {
            this.arrayList = new CustomArrayList<int>(new[] { 10, 20, 30, 40, 50 });

            this.arrayList.Remove(10);

            Assert.AreEqual(30, this.arrayList[1]);
        }

        [TestMethod]
        public void CopyToTest_CopySixElementsFromIndex4_FirstElementIsAtIndexFour()
        {
            this.arrayList.Add(10);
            this.arrayList.Add(20);
            this.arrayList.Add(30);
            this.arrayList.Add(40);
            this.arrayList.Add(50);
            this.arrayList.Add(60);

            int[] array = new int[10];
            this.arrayList.CopyTo(array, 4);

            Assert.AreEqual(10, array[4]);
        }

        [TestMethod]
        public void CopyToTest_CopySixElementsFromIndex4_LastElementIsAtIndexNine()
        {
            this.arrayList.Add(10);
            this.arrayList.Add(20);
            this.arrayList.Add(30);
            this.arrayList.Add(40);
            this.arrayList.Add(50);
            this.arrayList.Add(60);

            int[] array = new int[10];
            this.arrayList.CopyTo(array, 4);

            Assert.AreEqual(60, array[9]);
        }
    }
}
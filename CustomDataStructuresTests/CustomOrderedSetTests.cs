namespace CustomDataStructuresTests
{
    using System.Collections.Generic;

    using CustomDataStructures;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CustomCustomOrderedSetTests
    {
        [TestMethod]
        public void BuildCustomOrderedSet_ForEachInOrder_ShouldWorkCorrectly()
        {
            // Arrange
            var orderedSet = new CustomOrderedSet<int>();
            orderedSet.Add(17);
            orderedSet.Add(9);
            orderedSet.Add(12);
            orderedSet.Add(19);
            orderedSet.Add(6);
            orderedSet.Add(25);

            // Act
            var nodes = new List<int>();
            foreach (var element in orderedSet)
            {
                nodes.Add(element);
            }

            // Assert
            var expectedNodes = new int[] { 6, 9, 12, 17, 19, 25 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
            Assert.AreEqual(nodes.Count, orderedSet.Count);
        }

        [TestMethod]
        public void TestAdd_SameElementsAdded_ShouldAddTheElementOnlyOnce()
        {
            // Arrange
            var orderedSet = new CustomOrderedSet<int>();
            orderedSet.Add(1);
            orderedSet.Add(1);
            orderedSet.Add(1);

            // Act
            var nodes = new List<int>();
            foreach (var element in orderedSet)
            {
                nodes.Add(element);
            }

            // Assert
            var expectedNodes = new int[] { 1 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
            Assert.AreEqual(nodes.Count, orderedSet.Count);
        }

        [TestMethod]
        public void TestCount_EmptyCustomOrderedSet_ShouldReturnCountZero()
        {
            // Arrange
            // Act
            var orderedSet = new CustomOrderedSet<int>();

            // Assert
            Assert.AreEqual(0, orderedSet.Count);
        }

        [TestMethod]
        public void TestCount_AddSeveralElements_ShouldReturnCorrectCount()
        {
            // Arrange
            var orderedSet = new CustomOrderedSet<int>();

            // Act
            int[] numbers = new[] { 4, -1, 0, 10, 25, 3, 6, 2, -3, 14 };
            for (int i = 0; i < numbers.Length; i++)
            {
                orderedSet.Add(numbers[i]);

                // Assert
                Assert.AreEqual(i + 1, orderedSet.Count);
            }
        }

        [TestMethod]
        public void TestContains_EmptyCustomOrderedSet_ShouldReturnFalse()
        {
            // Arrange
            var orderedSet = new CustomOrderedSet<int>();

            // Act
            var result = orderedSet.Contains(2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestContains_ElementNoAddedInCustomOrderedSet_ShouldReturnFalse()
        {
            // Arrange
            var orderedSet = new CustomOrderedSet<int>();
            orderedSet.Add(17);
            orderedSet.Add(9);
            orderedSet.Add(12);
            orderedSet.Add(19);
            orderedSet.Add(6);
            orderedSet.Add(25);

            // Act
            var result = orderedSet.Contains(2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestContains_ElementAddedInCustomOrderedSet_ShouldReturnTrue()
        {
            // Arrange
            var orderedSet = new CustomOrderedSet<int>();
            orderedSet.Add(17);
            orderedSet.Add(9);
            orderedSet.Add(12);
            orderedSet.Add(19);
            orderedSet.Add(6);
            orderedSet.Add(25);

            // Act
            var result = orderedSet.Contains(19);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestRemove_EmptyCustomOrderedSet_ShouldReturnFalse()
        {
            // Arrange
            var orderedSet = new CustomOrderedSet<int>();

            // Act
            var result = orderedSet.Remove(2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestRemove_ElementNotAddedInCustomOrderedSet_ShouldReturnFalse()
        {
            // Arrange
            var orderedSet = new CustomOrderedSet<int>();
            orderedSet.Add(17);
            orderedSet.Add(9);
            orderedSet.Add(12);
            orderedSet.Add(19);
            orderedSet.Add(6);
            orderedSet.Add(25);

            // Act
            var result = orderedSet.Remove(2);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(6, orderedSet.Count);
        }

        [TestMethod]
        public void TestRemove_ElementAddedInCustomOrderedSet_ShouldReturnTrueAndCorrectElementsCount()
        {
            // Arrange
            var orderedSet = new CustomOrderedSet<int>();
            orderedSet.Add(17);
            orderedSet.Add(9);
            orderedSet.Add(12);
            orderedSet.Add(19);
            orderedSet.Add(6);
            orderedSet.Add(25);

            // Act
            var result = orderedSet.Remove(12);
            var expectedNodes = new int[] { 6, 9, 17, 19, 25 };
            var nodes = new List<int>();
            foreach (var element in orderedSet)
            {
                nodes.Add(element);
            }

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(expectedNodes.Length, orderedSet.Count);
            Assert.AreEqual(expectedNodes.Length, nodes.Count);
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [TestMethod]
        public void TestForeach_EmptyCustomOrderedSet_ShouldReturnEmptyCollection()
        {
            // Arrange
            var orderedSet = new CustomOrderedSet<int>();

            // Act
            var expectedNodes = new int[] { };
            var nodes = new List<int>();
            foreach (var element in orderedSet)
            {
                nodes.Add(element);
            }

            // Assert
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }
    }
}

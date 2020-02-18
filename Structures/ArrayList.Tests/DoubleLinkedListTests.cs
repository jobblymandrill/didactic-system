using NUnit.Framework;
using System;
using System.Collections;
using System.Linq;

namespace Structures.Tests
{
    [TestFixture]
    class DoubleLinkedListTests
    {
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6}, new int[] { 1, 2, 3, 4, 5, 6})]
        public void ToArrayTestWithNotEmptyList(int [] array, int [] eArray)
        {
            DoubleLinkedList list = new DoubleLinkedList(array);
            int[] aArray = list.ToArray();
            Assert.AreEqual(eArray, aArray);
        }
        [TestCase(new int[] {})]
        public void ToArrayTestWithEmptyList(int[] eArray)
        {
            DoubleLinkedList list = new DoubleLinkedList();
            int[] aArray = list.ToArray();
            Assert.AreEqual(eArray, aArray);
        }
    }
}

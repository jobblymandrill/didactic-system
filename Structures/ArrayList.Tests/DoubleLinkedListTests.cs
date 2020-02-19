﻿using NUnit.Framework;
using System;
using System.Collections;
using System.Linq;

namespace Structures.Tests
{
    [TestFixture]
    public class DoubleLinkedListTests
    {
        [TestCase(5, new int[] { 7, 10 }, new int[] { 5, 7, 10 })]
        public void AddFirstTest(int value, int[] valSource, int[] valExpected)
        {
            DoubleLinkedList list = new DoubleLinkedList(valSource);
            list.AddFirst(value);
            int[] valActual = list.ToArray();
            Assert.AreEqual(valExpected, valActual);
        }
        [TestCase(5, new int[1] { 5 })]
        public void AddFirstTest1(int value, int[] valExpected)
        {
            DoubleLinkedList list = new DoubleLinkedList();
            list.AddFirst(value);
            int[] valActual = list.ToArray();
            Assert.AreEqual(valExpected, valActual);
        }

        [TestCase()]
        public void ToArrayTest()
        {
            DoubleLinkedList list = new DoubleLinkedList();
            list.AddFirst(5);
            list.AddFirst(6);
            list.AddFirst(7);
            list.AddFirst(8);
            int[] arrExpected = new int[4] { 8, 7, 6, 5 };
            int[] arrActual = list.ToArray();
            Assert.AreEqual(arrExpected, arrActual);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4 }, new int[] { 5, 6 }, new int[] { 6, 5, 0, 1, 2, 3, 4 })]
        public void AddFirstWithArray_With_Not_Empty_List(int[] valSource, int[] enterArray, int[] expectedArray)
        {
            DoubleLinkedList list = new DoubleLinkedList(valSource);
            list.AddFirst(enterArray);
            int[] actualArray = list.ToArray();
            Assert.AreEqual(expectedArray, actualArray);
        }

        [TestCase(new int[] { 5, 6 }, new int[] { 6, 5 })]
        public void AddFirstWithArray_With_Empty_List(int[] enterArray, int[] expectedArray)
        {
            DoubleLinkedList list = new DoubleLinkedList();
            list.AddFirst(enterArray);
            int[] actualArray = list.ToArray();
            Assert.AreEqual(expectedArray, actualArray);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4 }, 5, new int[] { 0, 1, 2, 3, 4, 5 })]
        public void AddLastTestWithValue_With_Not_Empty_List(int[] sourceArray, int addValue, int[] expArray)
        {
            DoubleLinkedList list = new DoubleLinkedList(sourceArray);
            list.AddLast(addValue);
            int[] actualArray = list.ToArray();
            Assert.AreEqual(expArray, actualArray);
        }

        [TestCase(5, new int[1] { 5 })]
        public void AddLastWithValue_With_Empty_List(int addValue, int[] expArray)
        {
            DoubleLinkedList list = new DoubleLinkedList();
            list.AddLast(addValue);
            int[] actualArray = list.ToArray();
            Assert.AreEqual(expArray, actualArray);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4 }, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4, 0, 1, 2, 3, 4, 5 })]
        public void AddLastWithArray_With_Not_Empty_List(int[] valSource, int[] enterArray, int[] expectedArray)
        {
            DoubleLinkedList list = new DoubleLinkedList(valSource);
            list.AddLast(enterArray);
            int[] actualArray = list.ToArray();
            Assert.AreEqual(expectedArray, actualArray);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4, 5 })]
        public void AddLastWithArray_With_Empty_List(int[] enterArray, int[] expectedArray)
        {
            DoubleLinkedList list = new DoubleLinkedList();
            list.AddLast(enterArray);
            int[] actualArray = list.ToArray();
            Assert.AreEqual(expectedArray, actualArray);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, 4, 5, new int[] { 0, 1, 2, 3, 5, 4, 5, 6 })]
        public void AddAtWithValue_WithCorrectIndex(int[] enterArr, int ind, int val, int[] expArr)
        {
            DoubleLinkedList list = new DoubleLinkedList(enterArr);
            list.AddAt(ind, val);
            int[] actualArr = list.ToArray();
            Assert.AreEqual(expArr, actualArr);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, 66, 5, -1)]
        public void AddAtWithValue_WithInCorrectIndex(int[] enterArr, int ind, int val, int exp)
        {
            DoubleLinkedList list = new DoubleLinkedList(enterArr);
            list.AddAt(ind, val);
            int act = list.Ex;
            Assert.AreEqual(exp, act);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, 66, new int[] { 1, 2, 3, 4 }, -1)]
        public void AddAtWithArray_WithInCorrectIndex(int[] enterArr, int ind, int[] newArr, int exp)
        {
            DoubleLinkedList list = new DoubleLinkedList(enterArr);
            list.AddAt(ind, newArr);
            int act = list.Ex;
            Assert.AreEqual(exp, act);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, 3, new int[] { 1, 2, 3, 4 }, new int[] { 0, 1, 2, 4, 3, 2, 1, 3, 4, 5, 6 })]
        public void AddAtWithArray_WithCorrectIndex(int[] enterArr, int ind, int[] newArr, int[] expArr)
        {
            DoubleLinkedList list = new DoubleLinkedList(enterArr);
            list.AddAt(ind, newArr);
            int[] act = list.ToArray();
            Assert.AreEqual(expArr, act);
        }

        [TestCase(new int[] { 1, 2, 3 }, 3)]
        public void GetSizeTest_WithNotEmptyList(int[] enterArr, int expected)
        {
            DoubleLinkedList list = new DoubleLinkedList(enterArr);
            int actual = list.GetSize();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(0)]
        public void GetSizeTest_WithEmptyList(int expected)
        {
            DoubleLinkedList list = new DoubleLinkedList();
            int actual = list.GetSize();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3 }, 33, 66, -1)]
        public void SetWithValue_WithIncorrectIndex(int[] enterArr, int addValue, int idx, int expected)
        {
            DoubleLinkedList list = new DoubleLinkedList(enterArr);
            list.Set(addValue, idx);
            int actual = list.Ex;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3 }, 33, 2, new int[] { 0, 1, 33, 3 })]
        [TestCase(new int[] { 0, 1, 2, 3 }, 33, 3, new int[] { 0, 1, 2, 33 })]
        public void SetWithValue_WithCorrentIndex(int[] enterArr, int addValue, int idx, int[] expectedArr)
        {
            DoubleLinkedList list = new DoubleLinkedList(enterArr);
            list.Set(idx, addValue);
            int[] actualArr = list.ToArray();
            Assert.AreEqual(expectedArr, actualArr);
        }

        [TestCase(-1)]
        public void RemoveFirst_WithAnEmptyList(int exp)
        {
            DoubleLinkedList list = new DoubleLinkedList();
            list.RemoveFirst();
            int act = list.Ex;
            Assert.AreEqual(exp, act);
        }

        [TestCase(new int[] { 0, 1, 2, 3 }, new int[] { 1, 2, 3 })]
        public void RemoveFirst_WithNotEmptyList(int[] enterArr, int[] expectedArr)
        {
            DoubleLinkedList list = new DoubleLinkedList(enterArr);
            list.RemoveFirst();
            int[] actualArr = list.ToArray();
            Assert.AreEqual(expectedArr, actualArr);
        }

        [TestCase(-1)]
        public void RemoveLast_WithEmptyList(int exp)
        {
            DoubleLinkedList list = new DoubleLinkedList();
            list.RemoveLast();
            int act = list.Ex;
            Assert.AreEqual(exp, act);
        }

        [TestCase(new int[] { 0, 1, 2, 3 }, new int[] { 0, 1, 2 })]
        public void RemoveLast_WithNotEmptyList(int[] enterArr, int[] expectedArr)
        {
            DoubleLinkedList list = new DoubleLinkedList(enterArr);
            list.RemoveLast();
            int[] actualArr = list.ToArray();
            Assert.AreEqual(expectedArr, actualArr);
        }

        [TestCase(new int[] { 0, 1, 2, 3 }, 4, -1)]
        [TestCase(new int[] { 0, 1, 2, 3 }, -1, -1)]
        [TestCase(new int[] { 0, 1, 2, 3 }, 10, -1)]
        public void RemoveAt_WithInCorrectIndex(int[] enterArr, int idx, int exp)
        {
            DoubleLinkedList list = new DoubleLinkedList(enterArr);
            list.RemoveAt(idx);
            int act = list.Ex;
            Assert.AreEqual(exp, act);
        }

        [TestCase(new int[] { 0, 1, 2, 3 }, 0, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 0, 1, 2, 3 }, 2, new int[] { 0, 1, 3 })]
        [TestCase(new int[] { 0, 1, 2, 3 }, 3, new int[] { 0, 1, 2 })]
        public void RemoveAt_WithCorrectIndex(int[] enterArr, int idx, int[] expArr)
        {
            DoubleLinkedList list = new DoubleLinkedList(enterArr);
            list.RemoveAt(idx);
            int[] actArr = list.ToArray();
            Assert.AreEqual(expArr, actArr);
        }

        [TestCase(10, false)]
        public void ContainsTest_WithAnEmptyList(int val, bool containsEx)
        {
            DoubleLinkedList list = new DoubleLinkedList();
            list.Contains(val);
            bool res = list.Contain;
            Assert.AreEqual(containsEx, res);
        }

        [TestCase(new int[] { 10, 11, 12, 13 }, 10, true)]
        [TestCase(new int[] { 10, 11, 12, 13 }, 11, true)]
        [TestCase(new int[] { 10, 11, 12, 13 }, 12, true)]
        [TestCase(new int[] { 10, 11, 12, 13 }, 13, true)]
        [TestCase(new int[] { 10, 11, 12, 13 }, 14, false)]
        public void ContainsTest_WintNotEmptyList(int[] entArr, int val, bool conEx)
        {
            DoubleLinkedList list = new DoubleLinkedList(entArr);
            list.Contains(val);
            bool res = list.Contain;
            Assert.AreEqual(conEx, res);
        }

        [TestCase(new int[] { 10, 11, 12, 13 }, 10, 0)]
        [TestCase(new int[] { 10, 11, 12, 13 }, 11, 1)]
        [TestCase(new int[] { 10, 11, 12, 13 }, 12, 2)]
        [TestCase(new int[] { 10, 11, 12, 13 }, 13, 3)]
        [TestCase(new int[] { 10, 11, 12, 13 }, 14, -1)]
        public void IndexOf_WithNotEmptyList(int[] arr, int val, int expectedIdx)
        {
            DoubleLinkedList list = new DoubleLinkedList(arr);
            list.IndexOf(val);
            int actualIndex = list.Index;
            Assert.AreEqual(expectedIdx, actualIndex);
        }

        [TestCase(10, -1)]
        public void IndexOf_WithEmptyList(int val, int expectedIdx)
        {
            DoubleLinkedList list = new DoubleLinkedList();
            list.IndexOf(val);
            int actualIndex = list.Index;
            Assert.AreEqual(expectedIdx, actualIndex);
        }

        [TestCase(new int[] { 10, 11, 12, 13 }, 10)]
        public void GetFirst_WithNotEmptyList(int[] arr, int expectedVal)
        {
            DoubleLinkedList list = new DoubleLinkedList(arr);
            list.GetFirst();
            int value = list.ValueOfFirstNode;
            Assert.AreEqual(expectedVal, value);
        }

        [TestCase(-1)]
        public void GetFirst_WithAnEmptyList(int expectedVal)
        {
            DoubleLinkedList list = new DoubleLinkedList();
            list.GetFirst();
            int actualVal = list.Ex;
            Assert.AreEqual(expectedVal, actualVal);
        }

        [TestCase(-1)]
        public void GetLast_WithAnEmptyList(int expectedVal)
        {
            DoubleLinkedList list = new DoubleLinkedList();
            list.GetLast();
            int actualVal = list.Ex;
            Assert.AreEqual(expectedVal, actualVal);
        }

        [TestCase(new int[] { 10, 11, 12, 13 }, 13)]
        public void GetLast_WithNotEmptyList(int[] arr, int expectedVal)
        {
            DoubleLinkedList list = new DoubleLinkedList(arr);
            list.GetLast();
            int value = list.ValueOfLastNode;
            Assert.AreEqual(expectedVal, value);
        }

        [TestCase(new int[] { 10, 11, 12, 13 }, 0, 10)]
        [TestCase(new int[] { 10, 11, 12, 13 }, 1, 11)]
        [TestCase(new int[] { 10, 11, 12, 13 }, 2, 12)]
        [TestCase(new int[] { 10, 11, 12, 13 }, 3, 13)]
        [TestCase(new int[] { 10, 11, 12, 13 }, 4, -1)]
        public void Get_WithNotEmptyList(int[] arr, int idx, int expectedValue)
        {
            DoubleLinkedList list = new DoubleLinkedList(arr);
            list.Get(idx);
        }

        [TestCase(5, -1)]
        public void Get_WithAnEmptyList(int idx, int expectedVal)
        {
            DoubleLinkedList list = new DoubleLinkedList();
            list.Get(idx);
            int actualVal = list.Ex;
            Assert.AreEqual(expectedVal, actualVal);
        }

        [TestCase(new int[] { 10, 11, 12, 13 }, new int[] { 13, 12, 11, 10 })]
        [TestCase(new int[] { 10, 11, 12, 13, 24 }, new int[] { 24, 13, 12, 11, 10 })]
        public void Reverse_WithNotEmptyList(int[] arr, int[] expectedArr)
        {
            DoubleLinkedList list = new DoubleLinkedList(arr);
            list.Reverse();
            int[] actualArr = list.ToArray();
            Assert.AreEqual(expectedArr, actualArr);
        }

        public void Reverse_WithEmptyList(int expected = -1)
        {
            DoubleLinkedList list = new DoubleLinkedList();
            list.Reverse();
            int actual = list.Ex;
            Assert.AreEqual(expected, actual);
        }
    }
}
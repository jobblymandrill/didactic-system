using NUnit.Framework;

namespace ArrayList.Tests
{
    public class ArrayListTests
    {
        [TestFixture]
        public class ArrayListTest
        {
            [TestCase(new int[] { 1 }, new int[] { 1 })]
            public void GetItemsTest(int[] array, int[] expected)
            {
                ArrayList al = new ArrayList(array);
                int[] actual = al.GetItems();
                Assert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { }, 6, new int[1] { 6 })]
            [TestCase(new int[10] { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6 }, 5, new int[11] { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 5 })]
            [TestCase(new int[10] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }, 7, new int[11] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 7 })]
            [TestCase(new int[10] { 5, 0, 0, 5, 5, 5, 5, 5, 5, 5 }, 7, new int[11] { 5, 0, 0, 5, 5, 5, 5, 5, 5, 5, 7 })]
            public void AddTest(int[] array, int value, int[] expected)
            {
                ArrayList al = new ArrayList(array);
                al.Add(value);
                int[] actual = al.GetItems();
                Assert.AreEqual(expected, actual);
            }

            [TestCase(0, true)]
            [TestCase(1, false)]
            public void ContainsTest(int value, bool expected)
            {
                ArrayList al = new ArrayList();
                bool actual = al.Contains(value);
                Assert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6, 1, new int[] { 1, 6, 2, 3, 4, 5 })]
            [TestCase(new int[] { 11, 23, 333, 4444, 544 }, 13, 3, new int[] { 11, 23, 333, 13, 4444, 544 })]
            [TestCase(new int[] { 111, 234, 3335, 4445, 546 }, 15, 2, new int[] { 111, 234, 15, 3335, 4445, 546 })]
            public void AddByIndexTest(int[] array, int value, int index, int[] expected)
            {
                ArrayList al = new ArrayList(array);
                al.AddByIndex(value, index);
                int[] actual = al.GetItems();
                Assert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { 45, 0, 0, 4, 3, 11, 0 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11 }, new int[] { 45, 0, 0, 4, 3, 11, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 11 })]
            [TestCase(new int[] { 87, 29, 93, 44, 50 }, new int[] { 1, 2, 3 }, new int[] { 87, 29, 93, 44, 50, 1, 2, 3 })]
            public void AddAllTest(int[] array, int[] arr, int[] expected)
            {
                ArrayList al = new ArrayList(array);
                al.AddAll(arr);
                int[] actual = al.GetItems();
                Assert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5 }, 1, new int[] { 1, 4, 5, 2, 3 })]
            public void AddAllByIndexTest(int[] array, int[] arr, int index, int[] expected)
            {
                ArrayList al = new ArrayList(array);
                al.AddAllByIndex(arr, index);
                int[] actual = al.GetItems();
                Assert.AreEqual(expected, actual);
            }
            [TestCase(new int[] { 1, 2, 3 }, 0, 6, new int[] { 6, 2, 3 })]
            public void SetTest(int[] array, int index, int value, int[] expected)
            {
                ArrayList al = new ArrayList(array);
                al.Set(index, value);
                int[] actual = al.GetItems();
                Assert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { 10, 230, 200, 50, 40, 88, 45, 55 }, 8)]//сам по себе метод бесполезен, так как мне и так без нулей уже массив из эррэй листа приходит через метод гет. 
            public void SizeTest(int[] array, int expected)
            {
                ArrayList al = new ArrayList(array);
                int actual = al.Size();
                Assert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { 10, 230, 200, 50, 40, 88, 45, 55 }, 55, 7)]
            [TestCase(new int[] { 10, 230, 200, 50, 40, 88, 45, 55 }, 100, -1)]
            public void IndexOfTest(int[] array, int value, int expected)
            {
                ArrayList al = new ArrayList(array);
                int actual = al.IndexOf(value);
                Assert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { 30, 40, 50, 60 }, 3, new int[] { 30, 40, 50 })]
            [TestCase(new int[] { 30, 40, 50, 60 }, 2, new int[] { 30, 40, 60 })]
            [TestCase(new int[] { 30, 40, 50, 60 }, 1, new int[] { 30, 50, 60 })]
            [TestCase(new int[] { 30, 40, 50, 60, 70, 80 }, 2, new int[] { 30, 40, 60, 70, 80 })]
            [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 1, new int[] { 1, 3, 4, 5, 6 })]
            public void RemoveByIndexTest(int[] array, int index, int[] expected)
            {
                ArrayList al = new ArrayList(array);
                al.RemoveByIndex(index);
                int[] actual = al.GetItems();
                Assert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { 300, 400, 500, 601 }, 500, new int[] { 300, 400, 601 })]
            [TestCase(new int[] { 30, 40, 50, 60 }, 40, new int[] { 30, 50, 60 })]
            public void RemoveByValueTest(int[] array, int value, int[] expected)
            {
                ArrayList al = new ArrayList(array);
                al.RemoveByValue(value);
                int[] actual = al.GetItems();
                Assert.AreEqual(expected, actual);
            }

            [TestCase(new int[] { 30, 40, 50, 60 }, new int[] { })]
            public void RemoveAllTest(int[] array, int[] expected)
            {
                ArrayList al = new ArrayList(array);
                al.RemoveAll();
                int[] actual = al.GetItems();
                Assert.AreEqual(expected, actual);
            }

            [TestCase(-1)]
            public void ReturnExceptionTest(int expected)
            {
                ArrayList al = new ArrayList();
                int actual = al.ReturnException();
                Assert.AreEqual(expected, actual);
            }

            //[TestCase(new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 5, new int[23] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 0 , 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0})]
            //public void EnlargeArrayTest(int [] array, int numberOfNewElements, int [] expected)
            //{
            //    ArrayList al = new ArrayList(array);
            //    al.EnlargeArray(numberOfNewElements);
            //    int[] actual = al.GetItems();
            //    Assert.AreEqual(expected, actual);
            //}
        }
    }
}
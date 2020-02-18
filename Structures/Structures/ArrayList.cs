using System;
using System.Collections.Generic;
using System.Text;

namespace Structures
{
    public class ArrayList
    {
        private int[] array;
        int actualSize;//это основные поля метода

        public ArrayList()//это конструктор, который можно вызвать с помощью (), он автоматический вставляет пустой массив на 10 элементов
        {
            array = new int[10];
            actualSize = 0;
        }

        public ArrayList(int[] array)//это конструктор, он придет, если в скобках указать какой-нибудь массив, и поставит указанный массив
        {
            this.array = array;
            actualSize = array.Length;//тут получается фигня, когда скидываешь массив с нулями, он думает у него 10 реальная длина, а по факту 0, но я, вроде как, решила эту проблему с помощью Get
        }

        private void EnlargeArray(int numberOfNewElements)//я делала егопубличным, тестировала, и он работал
        {
            int[] temp = new int[(actualSize + numberOfNewElements) * 3 / 2 + 1];
            for (int i = 0; i < array.Length; i++)
            {
                temp[i] = array[i];
            }
            array = temp;
        }

        public void Add(int value)
        {
            if (actualSize + value > array.Length)
            {
                EnlargeArray(1);
            }
            if (actualSize == 0)
            {
                array[0] = value;
                actualSize++;
            }
            else
            {
                array[actualSize] = value;
                actualSize++;
            }
        }

        public bool Contains(int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddByIndex(int value, int index)//тут надо обязательно научиться вбрасывать исключение!!!
        {
            if (actualSize + value > array.Length)
            {
                EnlargeArray(1);
            }
            for (int i = actualSize; i > index; i--)
            {
                array[i] = array[i - 1];
            }
            array[index] = value;
            actualSize++;
        }

        public int[] PrintArr()
        {
            return array;
        }

        public void AddAll(int[] addedArr)
        {
            if (actualSize + addedArr.Length > array.Length)
            {
                EnlargeArray(addedArr.Length);
            }
            for (int i = 0; i < addedArr.Length; i++)
            {
                array[actualSize + i] = addedArr[i];
            }
            actualSize += addedArr.Length;
        }

        public void AddAllByIndex(int[] addedArr, int index)//тут надо обязательно научиться вбрасывать исключение, хотя бы через минус единицу
        {
            if (actualSize + addedArr.Length > array.Length)
            {
                EnlargeArray(addedArr.Length);
            }
            for (int i = 0; i <= addedArr.Length; i++)
            {
                array[i + index + addedArr.Length] = array[i + index];
            }
            for (int i = 0; i < addedArr.Length; i++)
            {
                array[index + i] = addedArr[i];
            }
            actualSize += addedArr.Length;
        }

        public void Set(int index, int value)//заменяет значение по индексу
        {
            array[index] = value;
        }

        public int[] GetItems()//возвращает значение элементов приватного массива
        {
            int[] actualSizeArray = new int[actualSize];
            for (int i = 0; i < actualSize; i++)
            {
                actualSizeArray[i] = array[i];
            }
            return actualSizeArray;
        }

        public int Size()
        {
            return actualSize;
        }

        public int IndexOf(int value)
        {
            if (Contains(value))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == value)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public void RemoveByIndex(int index)//по-хорошему метод должен называться RemoveAt
        {
            //Добавь сюда проверку индекса!
            array[index] = 0;//это, скорее всего, вообще ненужная строка
            for (int i = 0; i < (actualSize - 1) - index; i++)
            {
                array[index + i] = array[index + i + 1];
            }
            actualSize -= 1;
        }
        public void RemoveByIndexFromAnton(int index)
        {
            for (int i = index; i < actualSize - 1; i++)
            {
                array[i] = array[i + 1];
            }
            array[actualSize - 1] = 0;
            actualSize--;
            //а здесь должна быть проверка на необходимость сужения массива, и сужение при наличии этой необходимости. 
        }
        //это нормальное решение, оно должно работать и намного лучше моей криворукой реализации.

        public void RemoveByValue(int value)//здесь по хорошему свести бы все к вызову методов, вот только как
        {
            int index = IndexOf(value);
            if (index == -1) return;

            RemoveByIndex(index);
        }

        public void RemoveAll()//тут тоже херь какая-то, сделай нормально!
        {
            actualSize = 0;
        }
        public void CorrectRemoveAll(int value)//есть еще некоторая медленная реализация, но тут будет нормальная, быстрая
        {
            int[] temp = new int[actualSize];
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != value)
                {
                    temp[i - counter] = array[i];
                }
                else
                {
                    counter++;
                }
            }
            array = temp;
            actualSize -= counter;
        }
        public int ReturnException()
        {
            int result = -1;
            return result;
        }
    }
}


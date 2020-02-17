using System;
using System.Collections.Generic;
using System.Text;

namespace DoubleLinkedList
{
    public interface IDoubleLinkedList
    {
        public void AddFirst(int val);//добавление в начало списка
        public void AddFirst(int[] val);//то же самое, но с массивом
        public void AddLast(int val);//добавление в конец списка
        public void AddLast(int[] val);//то же самое, но с массивом
        public void AddAt(int idx, int val); //вставка по указанному индексу
        public void AddAt(int idx, int[] val);//вставка по указанному индексу
        public void GetSize();//узнать кол-во элементов в списке
        public void Set(int idx, int val);//поменять значение элемента с указанным индексом 
        public void RemoveFirst();//удаление первого элемента 
        public void RemoveLast();//удаление последнего элемента
        public void RemoveAt(int idx);//удаление по индексу
        public void Contains(int val); //проверка, есть ли элемент в списке
        public void IndexOf(int val);//вернёт индекс первого найденного элемента, равного val (или -1, если элементов с таким значением в списке нет) 
        public void ToArray();//преобразовать список в массив
        public void GetFirst();//вернёт значение первого элемента списка
        public void GetLast();//вернёт значение последнего элемента списка
        public void Get(int idx);//вернёт значение элемента списка c указанным индексом
        public void Reverse();//изменение порядка элементов списка на обратный
    }
}
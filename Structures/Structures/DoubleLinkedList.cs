using System;
using System.Collections.Generic;
using System.Text;

namespace Structures
{
    public class DoubleLinkedList
    {
        public int Ex { get; private set; }
        public bool Contain { get; private set; }
        public int Index { get; private set; }
        public int ValueOfFirstNode { get; private set; }
        public int ValueOfLastNode { get; private set; }
        public int ValueOfConcreteNode { get; private set; }
        private void ReturnEx()
        {
            Ex = -1;
            return;
        }
        private int size;
        Node Head { get; set; }
        Node Tail { get; set; }
        public DoubleLinkedList()
        { }
        public DoubleLinkedList(int[] sourceArray)
        {
            if (sourceArray.Length == 0)
            { }
            else
            {
                Head = new Node(sourceArray[0]);
                size++;
                Node currentNode = Head;
                for (int i = 1; i < sourceArray.Length; i++)
                {
                    currentNode.Next = new Node(sourceArray[i]);
                    size++;
                    currentNode = currentNode.Next;
                }
                Tail = new Node(sourceArray[sourceArray.Length - 1]);
            }
        }
        public int[] ToArray()
        {
            if (size == 0)
            {
                return new int[] { };
            }
            else
            {
                int[] listArray = new int[size];
                Node next = Head;
                for (int i = 0; i < size; i++)
                {
                    listArray[i] = next.Value;
                    next = next.Next;
                }
                return listArray;
            }
        }

    }
}

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
            { return; }
            else
            {
                Head = new Node(sourceArray[0]);
                size++;
                Node currentNode = Head;
                Tail = Head;
                for (int i = 1; i < sourceArray.Length; i++)
                {
                    currentNode.Next = new Node(sourceArray[i]);
                    if (size == 1)
                    {
                        currentNode.Prev = null;
                    }
                    else
                    {
                        currentNode.Prev = new Node(sourceArray[i - 2]);
                    }
                    if (i == sourceArray.Length - 1)
                    {
                        Tail = currentNode.Next;
                        Tail.Prev = currentNode;
                    }
                    currentNode = currentNode.Next;
                    Tail = currentNode;
                    size++;
                }

            }
        }
        public int[] ToArray()
        {
            int[] arr = new int[size];
            Node currentNode = Head;
            int currentIndex = 0;
            while (currentNode != null)
            {
                arr[currentIndex] = currentNode.Value;
                currentNode = currentNode.Next;
                currentIndex++;
            }
            return arr;
        }
        public void AddFirst(int val)
        {
            Node node = new Node(val);
            if (Head == null && Tail == null)
            {
                Head = node;
                Tail = node;
                size++;
            }
            else
            {
                node.Prev = null;
                Head.Prev = node;
                node.Next = Head;
                Head = node;
                size++;
            }
        }
        public void AddFirst(int[] val)
        {
            for (int i = 0; i < val.Length; i++)
            {
                AddFirst(val[i]);
            }
        }
        public int GetSize()
        {
            return size;
        }
        public void AddLast(int val)
        {
            Node node = new Node(val);

            if (Head == null)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
                node.Prev = Tail;
            }
            Tail = node;
            size++;
        }
        public void AddLast(int[] val)
        {
            for (int i = 0; i < val.Length; i++)
            {
                AddLast(val[i]);
            }
        }
        public void AddAt(int idx, int val)
        {
            if (idx >= size || idx < 0)
            {
                ReturnEx();
            }
            else
            {
                Node node = new Node(val);
                Node currentNode = Head;
                for (int i = 0; i < idx - 1; i++)
                {
                    currentNode = currentNode.Next;
                }
                node.Next = currentNode.Next;
                node.Prev = currentNode.Prev;
                currentNode.Next = node;
                node.Prev = currentNode;
                size++;
            }
        }
        public void AddAt(int idx, int[] val)
        {
            if (idx >= size || idx < 0)
            {
                ReturnEx();
            }
            else
            {
                for (int i = 0; i < val.Length; i++)
                {
                    Node node = new Node(val[i]);
                    Node currentNode = Head;
                    for (int j = 0; j < idx - 1; j++)
                    {
                        currentNode = currentNode.Next;
                    }
                    node.Next = currentNode.Next;
                    node.Prev = currentNode.Prev;
                    currentNode.Next = node;
                    node.Prev = currentNode;
                    size++;
                }
            }
        }
        public void Set(int idx, int val)
        {
            Node node = new Node(val);
            if (idx >= size || idx < 0)
            {
                ReturnEx();
            }
            else
            {
                if (idx == 0)
                {
                    Head.Value = node.Value;
                }
                else
                {
                    Node currentNode = Head;
                    for (int i = 0; i < size; i++)
                    {
                        if (i == idx)
                        {
                            currentNode.Value = node.Value;
                        }

                        currentNode = currentNode.Next;
                    }
                }
            }
        }
        public void RemoveFirst()
        {
            if (Head == null)
            {
                ReturnEx();
            }
            else if (size == 1)
            {
                size--;
                Head = Head.Next;
                Tail = Head;
            }
            else
            {
                size--;
                Head = Head.Next;
            }
        }
        public void RemoveLast()
        {
            if (Head == null)
            {
                ReturnEx();
            }
            else if ( size == 1 )
            {
                size--;
                Head = Head.Prev;
                Tail = Head;
            }
            else
            {
                Tail = Tail.Prev;
                Tail.Next = null;
                size--;
            }
        }
        public void RemoveAt(int idx)
        {
            if (idx >= size || idx < 0 || Head == null)
            {
                ReturnEx();
            }
            else if (idx == 0)
            {
                size--;
                Head = Head.Next;
            }
            else
            {
                Node currentNode = Head;
                for (int i = 0; i < idx - 1; i++)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = currentNode.Next.Next;
                size--;
            }
        }
        public void Contains(int val)
        {
            Node node = new Node(val);
            Node currentnode = Head;
            Contain = false;
            while (currentnode != null)
            {
                if (currentnode.Value == node.Value)
                {
                    Contain = true;
                }
                currentnode = currentnode.Next;
            }
        }
        public void IndexOf(int val)
        {
            Index = -1;
            if (Head == null)
            {
                return;
            }
            else
            {
                Node currentNode = Head;
                for (int i = 0; i < size; i++)
                {
                    if (currentNode.Value == val)
                    {
                        Index = i;
                    }
                    currentNode = currentNode.Next;
                }
            }
        }
        public void GetFirst()
        {
            if (Head == null)
            {
                ReturnEx();
            }
            else
            {
                ValueOfFirstNode = Head.Value;
            }
        }
        public void GetLast()
        {
            if (Head == null)
            {
                ReturnEx();
            }
            else
            {
                ValueOfLastNode = Tail.Value;
            }
        }
        public void Get(int idx)
        {
            if (idx >= size || idx < 0)
            {
                ReturnEx();
            }
            else
            {
                Node currentnode = Head;
                if (idx == 0)
                {
                    ValueOfConcreteNode = currentnode.Value;
                }
                for (int i = 0; i < size; i++)
                {
                    if (i == idx)
                    {
                        ValueOfConcreteNode = currentnode.Value;
                    }
                    currentnode = currentnode.Next;
                }

            }
        }
        public void Reverse()
        {
            Node currentNode = Head;
            while (currentNode.Next != null)
            {
                Node nextNode = currentNode.Next;
                currentNode.Next = nextNode.Next;
                nextNode.Next = Head;
                Head = nextNode;
                Tail = currentNode;
            }
        }
    }
}

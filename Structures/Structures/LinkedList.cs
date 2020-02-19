using System;
using System.Collections.Generic;
using System.Text;

namespace Structures
{
    public class LinkedList
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
        public LinkedList()
        { }
        public LinkedList(int[] sourceArray)
        {
            if (sourceArray.Length == 0)
            {

            }
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
        public void AddFirst(int val)
        {
            Node node = new Node(val);
            if (Head == null)
            {
                Head = node;
            }
            else
            {
                node.Next = Head;
                Head = node;
            }
            size++;
        }
        public void AddFirst(int[] val)
        {
            if (Head == null)
            {
                Node node = new Node(val[0]);
                Head = node;
                size++;
                for (int i = 1; i < val.Length; i++)//добавить в конструкторе проверку на хэд налл
                {
                    Node node1 = new Node(val[i]);
                    node1.Next = Head;
                    Head = node1;
                    size++;
                }
            }
            else
            {
                for (int i = 0; i < val.Length; i++)
                {
                    Node node = new Node(val[i]);
                    node.Next = Head;
                    Head = node;
                    size++;
                }
            }
        }
        public int GetSize()
        {
            return this.size;
        }
        public void AddLast(int val)
        {
            if (Head == null)
            {
                Node node = new Node(val);
                Head = node;
            }
            else
            {
                Node node = new Node(val);
                Node currentNode = Head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = node;
            }
            size++;
        }
        public void AddLast(int[] val)
        {
            if (size == 0)
            {
                Node node = new Node(val[0]);
                Head = node;
                size++;
                for (int i = 1; i < val.Length; i++)
                {
                    Node node1 = new Node(val[i]);
                    Node currentNode = Head;
                    while (currentNode.Next != null)
                    {
                        currentNode = currentNode.Next;
                    }
                    currentNode.Next = node1;
                    size++;
                }
            }
            else
            {
                for (int i = 0; i < val.Length; i++)
                {
                    Node node = new Node(val[i]);
                    Node currentNode = Head;
                    while (currentNode.Next != null)
                    {
                        currentNode = currentNode.Next;
                    }
                    currentNode.Next = node;
                    size++;
                }
            }
        }
        public void AddAt(int idx, int val)
        {
            if (idx >= size)
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
                currentNode.Next = node;
                size++;
            }
        }
        public void AddAt(int idx, int[] val)
        {
            if (idx > size)
            {
                ReturnEx();
            }
            else
            {
                for (int i = 0; i < val.Length; i++)
                {
                    Node node = new Node(val[i]);
                    Node currentNode = Head;
                    for (int z = 0; z < idx - 1; z++)
                    {
                        currentNode = currentNode.Next;
                    }
                    node.Next = currentNode.Next;
                    currentNode.Next = node;
                    size++;
                }
            }
        }
        public void Set(int idx, int val)
        {
            if (idx > size)
            {
                Ex = -1;
                return;
            }
            else
            {
                Node node = new Node(val);
                Node currentNode = Head;
                for (int i = 0; i < idx; i++)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Value = node.Value;
            }
        }
        public void RemoveFirst()
        {
            if (Head == null)
            {
                ReturnEx();
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
            else
            {
                Node currentNode = Head;
                for (int i = 0; i < size - 1; i++)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = null;
                size--;
            }
        }
        public void RemoveAt(int idx)
        {
            if (idx < 0)
            {
                ReturnEx();
            }
            else if (idx >= size)
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
            Node currentNode = Head;
            for (int i = 0; i < size; i++)
            {
                if (currentNode.Value == val)
                {
                    Contain = true;
                }
                currentNode = currentNode.Next;
            }
            if (Contain != true) { Contain = false; }
        }
        public void IndexOf(int val)
        {
            Node currentNode = Head;
            Index = -1;
            for (int i = 0; i < size; i++)
            {
                if (currentNode.Value == val)
                {
                    if (Index == -1)
                    {
                        Index = i;
                    }
                }
                currentNode = currentNode.Next;
            }
        }
        public void GetFirst()
        {
            if (Head != null)
            {
                ValueOfFirstNode = Head.Value;
            }
            else
            {
                ReturnEx();
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
                Node currentNode = Head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                ValueOfLastNode = currentNode.Value;
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
                Node currentNode = Head;
                for (int i = 0; i < idx; i++)
                {
                    currentNode = currentNode.Next;
                }
                ValueOfConcreteNode = currentNode.Value;
            }
        }
        public void Reverse()
        {
            if (Head == null)
            {
                ReturnEx();
            }
            Node currentNode = Head;
            while (currentNode.Next != null)
            {
                Node nextNode = currentNode.Next;
                currentNode.Next = nextNode.Next;
                nextNode.Next = Head;
                Head = nextNode;
            }
        }
    }
}

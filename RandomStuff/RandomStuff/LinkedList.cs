using System;
namespace RandomStuff
{
    public class LinkedList
    {
        public static void Program()
        {
            //var list = new Node(4);
            //list.AddToEnd(3);
            //list.AddToEnd(9);
            //list.AddToEnd(2);
            //list.AddToStart(ref list, 1);
            //list.Print();
            //Console.WriteLine();
            //list.Delete(ref list, 1);
            //list.Print();

            var dList = new DNode(4);
            dList.Add(2);
            dList.Add(5);
            dList.Print();
            var x = dList.next.next.prev.data;
            Console.WriteLine(x);
        }
    }

    public class DNode
    {
        public int data;
        public DNode prev;
        public DNode next;

        public DNode(int value)
        {
            data = value;
            prev = null;
            next = null;
        }

        public void Add(int value)
        {
            if (next == null)
            {
                next = new DNode(value);
                next.prev = this;
            }
            else
                next.Add(value);
        }

        public void Print()
        {
            Console.WriteLine(data);
            if (next != null)
                next.Print();
        }
    }

    public class Node
    {
        public int data;
        public Node head;

        public Node(int value)
        {
            data = value;
        }

        public void AddToEnd(int value)
        {
            if (head == null)
                head = new Node(value);
            else
                head.AddToEnd(value);
        }

        public void AddToStart(ref Node list, int value)
        {
            if (head == null)
                head = new Node(value);
            else
            {
                var temp = new Node(value);
                temp.head = list;
                list = temp;
            }
        }

        public void Delete(ref Node list, int value)
        {
            if (head == null)
                Console.WriteLine("error");
            else if (data == value) // actual head 
            {
                // capture this node, deallocate
                list = head;
            }
            else if (head.data == value) // following nodes
            {
                head = head.head;
            }
            else
                list.Delete(ref list, value);
        }

        public void Print()
        {
            Console.WriteLine(data);
            if (head != null)
                head.Print();
        }
    }
}

using System;
namespace RandomStuff
{
    public class DataStructures
    {
        public static void Program()
        {
            //MyList list = new MyList();
            //list.AddSorted(9);
            //list.AddSorted(5);
            //list.AddSorted(7);
            //list.AddSorted(11);
            //list.Print();

        }
    }

    //public class MyList
    //{
    //    public Node headNode;

    //    public MyList()
    //    {
    //        headNode = null;
    //    }

    //    public void Add(int data)
    //    {
    //        if (headNode == null)
    //            headNode = new Node(data);
    //        else
    //            headNode.Add(data);
    //    }

    //    public void AddBeginning(int data)
    //    {
    //        if (headNode == null)
    //            headNode = new Node(data);
    //        else
    //        {
    //            var temp = new Node(data);
    //            temp.next = headNode;
    //            headNode = temp;
    //        }
            
    //    }

    //    public void AddSorted(int data)
    //    {
    //        if (headNode == null)
    //            headNode = new Node(data);
    //        else if (data < headNode.data)
    //        {
    //            AddBeginning(data);
    //        }
    //        else
    //        {
    //            headNode.AddSorted(data);
    //        }
                
    //    }

    //    public void Print()
    //    {
    //        if (headNode != null)
    //        {
    //            headNode.Print();
    //        }
    //    }
    //}

    //public class Node
    //{
    //    public int data;

    //    public Node next;

    //    public void Add(int value)
    //    {
    //        if (next == null)
    //            next = new Node(value);
    //        else
    //            next.Add(value);
    //    }

    //    public void AddSorted(int data)
    //    {
    //        if (next == null)
    //            next = new Node(data);
    //        else if (data < next.data)
    //        {
    //            Node temp = new Node(data);
    //            temp.next = this.next;
    //            this.next = temp;
    //        }
    //        else
    //        {
    //            next.AddSorted(data);
    //        }
    //    }

    //    /// <summary>
    //    /// Recursive print
    //    /// </summary>
    //    public void Print()
    //    {
    //        Console.WriteLine("|" + data + "|->");
    //        if (next != null)
    //        {
    //            next.Print();
    //        }
    //    }

    //    public Node(int value)
    //    {
    //        data = value;
    //        next = null;
    //    }

    //}
}

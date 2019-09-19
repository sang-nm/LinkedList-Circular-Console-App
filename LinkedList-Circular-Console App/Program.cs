using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList_Circular_Console_App
{
    class Node
    {
        public Node(object data, Node next)
        {
            this.data = data;
            this.next = next;
        }

        private object data;

        public object Data
        {
            get { return data; }
            set { data = value; }
        }

        private Node next;

        public Node Next
        {
            get { return next; }
            set { next = value; }
        }
    }
    class LinkedListCircular
    {
        Node Last;
        //Node newNode;

        public void InsertNode(object item)
        {
            //newNode = new Node(item, null);
            if (Last == null)
            {
                Last = new Node(item, null);
                Last.Next = Last;
            }
            else if (Convert.ToInt32(item) < Convert.ToInt32(Last.Next.Data))
            {
                Last.Next = new Node(item, Last.Next);
            }
            else
            {
                Node CurrentNode = Last.Next;
                Node PreviousNode = Last.Next;
                while (CurrentNode != Last && Convert.ToInt32(CurrentNode.Data) < Convert.ToInt32(item))
                {
                    PreviousNode = CurrentNode;
                    CurrentNode = CurrentNode.Next;
                }
                if (!PreviousNode.Data.Equals(item))
                {
                    if (CurrentNode == Last)
                    {
                        Last.Next = new Node(item, Last.Next);
                        Last = Last.Next;
                    }
                    else
                    {
                        PreviousNode.Next = new Node(item, CurrentNode);
                    }
                }
            }
        }

        public void DeleteNode(object item)
        {
            Node DelNode = new Node(item, null);
            DelNode.Data = item;
            if (Last == null)
            {
                Console.WriteLine("Nothing");
            }
            else
            {
                Node CurrentNode = Last.Next;
                Node PreviousNode = Last.Next;
                while (CurrentNode != Last && !CurrentNode.Data.Equals(item))
                {
                    PreviousNode = CurrentNode;
                    CurrentNode = CurrentNode.Next;
                }
                if (CurrentNode == Last && !CurrentNode.Data.Equals(item))
                {
                    Console.WriteLine("Nothing to del :" + item);
                }
                else
                {
                    PreviousNode.Next = CurrentNode.Next;
                }
            }
        }

        public void Traverse()
        {
            Node CurrentNode = Last.Next;
            while (CurrentNode != Last)
            {
                Console.WriteLine(CurrentNode.Data);
                CurrentNode = CurrentNode.Next;
            }
            Console.WriteLine(CurrentNode.Data);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            LinkedListCircular LLC = new LinkedListCircular();
            LLC.InsertNode(4);
            LLC.InsertNode(6);
            LLC.InsertNode(2);
            LLC.InsertNode(8);
            LLC.InsertNode(12);
            LLC.InsertNode(10);

            LLC.InsertNode(4);

            LLC.Traverse();

            LLC.DeleteNode(1);
            LLC.DeleteNode(4);
            LLC.DeleteNode(2);
            LLC.DeleteNode(12);

            LLC.InsertNode(12);

            Console.WriteLine("-------");
            LLC.Traverse();

            Console.ReadLine();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AlgorithmPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            // 3-> 5-> 8-> 5-> 10-> 2-> 1[partition = 5]


            Node node1 = new Node(3);
            Node node2 = new Node(5);
            Node node3 = new Node(8);
            Node node4 = new Node(5);
            Node node5 = new Node(10);
            Node node6 = new Node(2);
            Node node7 = new Node(1);
            //Node node8 = new Node(8);
            //Node node9 = new Node(9);

            node1.SetRightNode(node2);
            node2.SetRightNode(node3);
            node3.SetRightNode(node4);
            node4.SetRightNode(node5);
            node5.SetRightNode(node6);
            node6.SetRightNode(node7);
            //node7.SetRightNode(node8);
            //node8.SetRightNode(node9);

            //LinkedLists.TraverseNodes(node1);

            //Debug.WriteLine("          ");

            //LinkedLists.TraverseNodes(LinkedLists.RemoveDuplicates(node1));

            //LinkedLists.RemoveDuplicates(node1);

            LinkedLists.TraverseNodes(LinkedLists.Partion(node1, 5));

            //Debug.WriteLine(LinkedLists.Partion(node1, 5).RightNode.RightNode.ID);

        }
    }
}

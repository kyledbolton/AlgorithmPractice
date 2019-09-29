using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AlgorithmPractice
{
    class LinkedLists
    {
        public static void TraverseNodes(Node n)
        {
            Node currentNode = n;

            while (currentNode != null)
            {
                Debug.WriteLine(currentNode.ID);
                //Debug.WriteLine(currentNode.GetHashCode());
                currentNode = currentNode.RightNode;
            }
        }

        //2.1 Remove Duplicates
        public static Node RemoveDuplicates(Node n)
        {
            Node headNode = n;

            Hashtable uniqueValues = new Hashtable();

            while (n != null)
            {
                if (uniqueValues.ContainsKey(n.ID))
                {
                    uniqueValues[n.ID] = (int)uniqueValues[n.ID] + 1;
                }
                else
                {
                    uniqueValues.Add(n.ID, 1);
                }

                n = n.RightNode;
            }

            n = headNode;

            Node trackerNode = null;

            while (n != null)
            {
                if ((int)uniqueValues[n.ID] != 1)
                {
                    uniqueValues[n.ID] = (int)uniqueValues[n.ID] - 1;
                    
                    if (n == headNode)
                    {
                        headNode = n.RightNode;
                        trackerNode = headNode;
                        // n.Dispose();
                        n = n.RightNode;
                    }   
                    else
                    {
                        trackerNode.RightNode = n.RightNode;
                        // n.Dispose();
                        n = n.RightNode;
                    }
                }
                else
                {
                    trackerNode = n;
                    n = n.RightNode;
                }          
            }

            return headNode;
        }

        //2.2 Return Kth to Last
        public static int ReturnKthToLast(Node n, int k)
        {
            Node headNode = n;

            int counter = 0;

            while (n != null)
            {
                counter++;

                n = n.RightNode;
            }

            if (k > counter || k < 0)
            {
                return -1;
            }

            counter = counter - k;

            if (counter == 0)
            {
                return headNode.ID;
            }

            n = headNode;

            for(int i = 0; i < counter; i ++)
            {
                n = n.RightNode;
            }

            return n.ID;
        }

        // 2.4 Partition
        //// Write code to partition a linked list around a value x, such that all nodes less than x come before all nodes greater
        //// or equal to x. If x is contained within the list, the values of x only need to be after the elements less than x. The
        //// partition element x can appear anywhere in the "right partition"; it does not need to appear between the left an right
        //// partitions.
         
        //// EXAMPLE:
        //// Input:  3 -> 5 -> 8 -> 5 -> 10 -> 2 -> 1 [partition = 5]
        //// Output: 3 -> 1 -> 2 -> 10 -> 5 -> 5 -> 8
        public static Node Partion(Node n, int x)
        {
            bool leftPartitionStarted = false;
            Node leftPartitionStart = null;
            Node leftPartition = null;
            bool rightPartitionStarted = false;
            Node rightPartitionStart = null;
            Node rightPartition = null;

            while(n != null)
            {
                if (n.ID < x && leftPartitionStarted == false)
                {
                    leftPartitionStarted = true;
                    leftPartitionStart = n;
                    leftPartition = n;
                }
                else if (n.ID < x)
                {
                    leftPartition.RightNode = n;             
                    leftPartition = n;
                }
                else if (rightPartitionStarted == false)
                {
                    rightPartitionStarted = true;
                    rightPartitionStart = n;
                    rightPartition = n;
                }
                else
                {
                    rightPartition.RightNode = n;
                    rightPartition = n;
                }

                n = n.RightNode;
            }

            if(leftPartitionStarted == true && rightPartitionStarted == true)
            {
                leftPartition.RightNode = rightPartitionStart;
                rightPartition.RightNode = null;
            }
            else if (leftPartitionStarted == false)
            {
                return rightPartitionStart;
            }

            return leftPartitionStart;
        }
    }

    class Node
    {
        public Node(int number, Node LeftNode = null, Node RightNode = null)
        {
            this.ID = number;
            this.LeftNode = null;
            this.RightNode = null;
        }

        public void SetLeftNode(Node n)
        {
            this.LeftNode = n;
        }

        public void SetRightNode(Node n)
        {
            this.RightNode = n;
        }

        internal void Dispose()
        {
            this.Dispose();
        }

        public int ID { get; private set; }

        public Node LeftNode { get; set; }

        public Node RightNode { get; set; }
    }   
}

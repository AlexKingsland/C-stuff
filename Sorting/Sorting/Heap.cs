using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Heap
    {
        /**
	 * heap sort using Comparable, first converts array into a valid max heap by iterating over the maxHeapify method. 
	 * Then puts root into leaf position, put leaf into root, let it sink down in an array of size n-1 so the end of the array is finalized.
	 * Iterate over it until every node has been taken from the root position and put into the finalized portion of the array at which point the array is sorted in increasing order.
	 * @param x - the input array containing jobs that need to be sorted.
	 * @param n - the size of the input array
	 */
        public static void sortHeap(int[] x, int n)
        {

            int endParent = (n / 2) - 1;
            //Keep updating the last node to have a parent which has not been heapified yet
            while (endParent > -1)
            {
                sinkHeapify(x, endParent, n);
                endParent--;
            }

            int temp = 0;

            int N = n;
            //Put root into leaf position, put leaf into root, let it sink down in an array of size n-1 so the end of the array is finalized.
            //Iterate over it until every node has been taken from the root position and put into the finalized portion of the array at which
            //point the array is sorted in increasing order.
            while (N > 0)
            {
                N--;
                temp = x[0];
                x[0] = x[N];
                x[N] = temp;
                sinkHeapify(x, 0, N);
            }

            if (Compare.compareTo(x[1], x[0]) < 0)
            {
                Compare.swap(x, 0, 1);
            }


        }
        /**
         * Using the concept of the sink function this function is used to take an array and turn it into a heap recursively through each subtree.
         * The method is called iteratively from the last node in the array that has children all the way up to the root node.
         * To avoid creating a new array of size N+1 in order to shift the root to index 1, the left and right children are just offset by one in their calculation.
         * @param x - the input array containing jobs that need to be sorted.
         * @param index - the index of the root node where everything below it will be recursively reconfigured into a valid MaxHeap.
         * @param N - the size of the input array
         */
        public static void sinkHeapify(int[] x, int index, int N)
        {

            int left = index * 2 + 1;
            int right = index * 2 + 2;

            if (index < 0 || left > N - 1 || right > N - 1)
            {
                return;
            }

            if (Compare.compareTo(x[left], x[right]) < 0 && Compare.compareTo(x[index], x[right]) < 0)
            {
                Compare.swap(x, right, index);
                sinkHeapify(x, right, N);
            }
            else if (Compare.compareTo(x[index], x[left]) < 0)
            {
                Compare.swap(x, left, index);
                sinkHeapify(x, left, N);
            }

        }
        
        
    }
}

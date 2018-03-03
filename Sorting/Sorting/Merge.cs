using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Merge
    {

        public static void sortMerge(int[] x, int n)
        {
            partition(x, 0, n - 1);
        }
        /**
         * partition the array into two halves recursively until the leftmost index of the subarray is greater than or equal to the rightmost.
         * Then reassemble the subarrays back together from the lowest depth of recursion back up.
         * @param x - the input array containing jobs that need to be sorted.
         * @param low - the left most index of the left sub array
         * @param high - the right most index of the right sub array
         */
        private static void partition(int[] x, int low, int high)
        {
            if (low >= high)
            {
                return;
            }

            int mid = low + (high - low) / 2;
            partition(x, low, mid);
            partition(x, mid + 1, high);

            reassemble(x, low, high, mid);
        }
        /**
         * reassemble two subarraysback together by passing in the left most index of the left subarray and the rightmost index of the right subarray in
         * the main array. Since the subarrays will already be sorted since we are building back up from single elements, the subarrays are merged back
         * together by comparing the first index value of each subarray and moving the smaller one into the next open index in the main array and incrementing
         * the index of that subarray by one. Once all the elements of one of the subarrays have been iterated through, the remaining elements of the other
         * subarray are simply added to the remaining slots of the main array in the order that they are in.
         * @param x - the input array containing jobs that need to be sorted.
         * @param low - the left most index of the left sub array
         * @param high - the right most index of the right sub array
         * @param mid - the right most index of the left sub array (The index value where the two subarrays were partitioned from)
         */
        private static void reassemble(int[] x, int low, int high, int mid)
        {
            //When reassembling the subarrays back together, take the right subarray and left subarray, take the lowest initial value from the two and put it back into the original array in its appropriate spot, then once one array has been fully placed into the original array, put all the remaining elements from the other array back into the origina array in sequence

            int[] right = new int[high - mid];
            int[] left = new int[1 + mid - low];

            int countR = 0;
            int countL = 0;
            int z = 0;

            int c = 0;
            for (int i = low; i <= mid; i++)
            {
                left[c] = x[c + low];
                c++;
            }

            c = 0;

            for (int i = mid + 1; i <= high; i++)
            {
                right[c] = x[c + mid + 1];
                c++;
            }


            for (z = low; z <= high && countR < high - mid && countL < 1 + mid - low; z++)
            {

                if (Compare.compareTo(right[countR], left[countL]) < 0)
                {
                    x[z] = right[countR];
                    countR++;
                }
                else
                {
                    x[z] = left[countL];
                    countL++;
                }

            }


            if (countR != right.Length)
            {

                while (countR < right.Length)
                {
                    x[z] = right[countR];
                    countR++;
                    z++;
                }

            }
            else
            {

                while (countL < left.Length)
                {
                    x[z] = left[countL];
                    countL++;
                    z++;
                }

            }

        }

        
    }
}

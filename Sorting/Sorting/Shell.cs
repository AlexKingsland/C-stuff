using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Shell
    {
        /**
         * In place shellsort, does not use extra memory, iterates along specified interval
         * @param low - the left most index of the left sub array
         * @param high - the right most index of the right sub array
         * @param mid - the right most index of the left sub array (The index value where the two subarrays were partitioned from)
         */
        public static void shellSort(int[] a, int N)
        {
            int h = 1;
            while (h < N / 3)
            {
                h = 3 * h + 1;
            }
            while (h >= 1)
            {
                for (int i = h; i < N; i++)
                {
                    for (int j = i; j >= h && Compare.compareTo(a[j], a[j - h]) < 0; j -= h)
                    {
                        Compare.swap(a, j, j - h);
                    }
                }
                h = h / 3;
            }
        }
    }
}

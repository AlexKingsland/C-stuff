using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    //Goal of modularizing compare class is to generalize sorting to more than just one type
    class Compare
    {
        public static int compareTo(int x, int y)
        {
            return x - y;
        }

        /**
         * function used to swap the elements at two index points of an array
         * @param x - the input array containing Comparable types that need to be swapped.
         * @param i - index of the element that needs to be swapped
         * @param j - index of the other element that needs to be swapped
         */
        public static void swap(int[] x, int i, int j)
        {
            int temp = x[i];
            x[i] = x[j];
            x[j] = temp;
        }
    }
}

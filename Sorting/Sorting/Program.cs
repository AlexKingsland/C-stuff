using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int N = 1000;
            int[] A = new int[N];
            for (int i = 0; i < N; i++)
            {
                A[i] = rand.Next(1000);
            }

            //Merge.sortMerge(A, N);
            //Heap.sortHeap(A, N);
            Shell.shellSort(A, N);

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(A[i]);
            }
            Console.ReadKey();
        }
    }
}

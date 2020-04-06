using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static void InsertionSorting(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;
                // Move elements of arr[0..i-1] that are greater than key to one position ahead of their current position 
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
            Console.WriteLine("Using Insertion Sorting");
            PrintArray(arr, arr.Length);
        }
        static void LinearSorting(int[] arr)
        {
            int swap, temp;
            do
            {
                swap = 0; //flag to indicate if swap has occurred
                for (int count = 0; count < arr.Length - 1; count++)
                {
                    if (arr[count] > arr[count + 1])
                    {
                        temp = arr[count]; //Swap Method
                        arr[count] = arr[count + 1];
                        arr[count + 1] = temp;
                        swap = 1; //Set the flag
                    }
                }
            } while (swap != 0);
            Console.WriteLine("Using Linear Sorting");
            PrintArray(arr, arr.Length);
        }
        static void SelectionSorting(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int smallest = i;
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[j] < arr[smallest])
                    {
                        smallest = j;
                    }
                }
                int temp = arr[i];
                arr[i] = arr[smallest];
                arr[smallest] = temp;
            }
            Console.WriteLine("Using Selection Sorting");
            PrintArray(arr, arr.Length);
        }
        static void QuickSort(int[] arr, int first, int last)
        {
            if (first < last)
            {
                // pi is partitioning index, arr[pi] is now at right place 
                int pi = Partition(arr, first, last);
                // Recursively sort elements before partition and after partition 
                QuickSort(arr, first, pi - 1);
                QuickSort(arr, pi + 1, last);
            }
        }
        static int Partition(int[] arr, int first, int last)
        {
            int pivot = arr[last];
            int lastSmall = (first - 1);  // index of smaller element -1
            for (int i = first; i < last; i++)
            {
                if (arr[i] <= pivot) // If current element is smaller than or equal to pivot
                {
                    lastSmall++;
                    int temp = arr[lastSmall]; // swapping 
                    arr[lastSmall] = arr[i];
                    arr[i] = temp;
                }
            }
            // swap arr[i+1] and arr[high] (or pivot) 
            int temp1 = arr[lastSmall + 1];
            arr[lastSmall + 1] = arr[last];
            arr[last] = temp1;

            return lastSmall + 1;
        }
        static void PrintArray(int[] arr, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
        static void Main(string[] args)
        {
            var watch1 = new System.Diagnostics.Stopwatch();
            var watch2 = new System.Diagnostics.Stopwatch();
            var watch3 = new System.Diagnostics.Stopwatch();
            var watch4 = new System.Diagnostics.Stopwatch();
            //initialize array
            int n;
            Console.Write("Enter number of array : ");
            n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Element[{0}] : ", i+1);
                arr[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();
            watch1.Start();
            InsertionSorting(arr);
            Console.Write($" Execution Time: {watch1.ElapsedMilliseconds} ms\n");
            watch1.Stop();
            watch2.Start();
            LinearSorting(arr);
            Console.Write($" Execution Time: {watch2.ElapsedMilliseconds} ms\n");
            watch1.Stop();
            watch3.Start();
            SelectionSorting(arr);
            Console.Write($" Execution Time: {watch3.ElapsedMilliseconds} ms\n");
            watch1.Stop();
            watch4.Start();
            QuickSort(arr, 0, arr.Length - 1);
            Console.WriteLine("Using Quick Sorting");
            PrintArray(arr, arr.Length);
            Console.Write($" Execution Time: {watch4.ElapsedMilliseconds} ms\n");
            watch1.Stop();
            Console.ReadLine();
        }

    }
}


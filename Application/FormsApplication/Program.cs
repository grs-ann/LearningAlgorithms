using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using Algorithms.Algorithms_code;
using FormsApplication;

namespace FormsApplication
{
    static class Program
    {
        
        static void Main()
        {
            

            // Keeps names of algorithm instances.
            List<string> sortingsStash = new List<string>();
            // Timer for checking algorithms work time.
            Stopwatch sw = new Stopwatch();
            // Array Creator for creating array 
            // with a cetrain length and range.
            ArrayCreator ac = new ArrayCreator();
            int[] array = ac.GetRandomArray(20, 20);

            // Bubble sort.
            BubbleSort bubbleSort = new BubbleSort("Bubble sort");
            sortingsStash.Add(bubbleSort.Name);


            Form1 form = new Form1(sortingsStash);
            form.ShowDialog();

            sw.Start();
            bubbleSort.InitializeBubbleSort(array);
            sw.Stop();
            // Contains information how long time the algorithm took.
            var timeRes = sw.Elapsed;
        }
    }
    class ArrayCreator
    {
        internal int[] GetRandomArray(int arrayLength, int rangeOfNums)
        {
            int[] array = new int[arrayLength];
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (int)(rnd.NextDouble() * rangeOfNums);
            }
            return array;
        }
    }
}

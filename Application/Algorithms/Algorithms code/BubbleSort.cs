using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Algorithms_code
{
    // BubbleSort algorithm.
    public class BubbleSort : IAlgorithm
    {
        public string Name { get; private set; }
        /// <summary>
        /// Name of sort
        /// </summary>
        /// <param name="n"></param>
        public BubbleSort(string n)
        {
            Name = n;
        }
        public int[] InitializeBubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int helpfully = array[i];
                        array[i] = array[j];
                        array[j] = helpfully;
                    }
                }
            }
            return array;
        }
    }
}

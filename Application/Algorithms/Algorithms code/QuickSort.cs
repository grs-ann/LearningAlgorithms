using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Algorithms.Algorithms_code
{
    // QuickSort algorithm.
    public class QuickSort : IAlgorithm
    {
        public string Name { get; private set; }
        public QuickSort(string n)
        {
            Name = n;
        }
        public int[] InitializeSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }
            var pivotIndex = Partition(array, minIndex, maxIndex);
            InitializeSort(array, minIndex, pivotIndex - 1);
            InitializeSort(array, pivotIndex + 1, maxIndex);
            return array;
        }
        // Метод возвращает индекс опорного элемента.
        private int Partition(int[] array, int minIndex, int maxIndex)
        {
            int pivot = minIndex - 1;
            for (int i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[maxIndex]);
                }
            }
            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }
        // Метод свапает элементы массива.
        private void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
    }
}

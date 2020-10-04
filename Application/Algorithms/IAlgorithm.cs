using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public interface IAlgorithm
    {
        string Name { get; }
        // Из-за того, что некоторые алгоритмы
        // должны принимать не только массив,
        // но и другие параметры, появляется 
        // необходимость в перегрузке метода.
        int[] InitializeSort(int[] array)
        {
            return array;
        }
        int[] InitializeSort(int[] array, int a, int b)
        {
            return array;
        }
    }
    
}

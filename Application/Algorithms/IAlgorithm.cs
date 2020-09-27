using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public interface IAlgorithm
    {
        string Name { get; }
        public int[] InitializeSort(int[] array)
        {
            return array;
        }

    }
    
}

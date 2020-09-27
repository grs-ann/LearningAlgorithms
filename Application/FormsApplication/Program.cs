using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using Algorithms.Algorithms_code;
using FormsApplication;
using System.Collections;
using Algorithms;

namespace FormsApplication
{
    static class Program
    {
        
        static void Main()
        {
            // Keeps names of algorithm instances as keys
            // and IAlgorithm objects as values.
            Dictionary<string, IAlgorithm> algorithmsStash = new Dictionary<string, IAlgorithm>();  
            
           

            // Bubble sort.
            IAlgorithm bubbleSort = new BubbleSort("Bubble sort");
            string bubbleSortName = bubbleSort.Name;
            algorithmsStash.Add(bubbleSortName, bubbleSort);
            

            Form1 form = new Form1(algorithmsStash);
            form.ShowDialog();
            
        }
    }
    
    
}

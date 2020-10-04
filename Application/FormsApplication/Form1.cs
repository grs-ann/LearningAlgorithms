using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Algorithms;

namespace FormsApplication
{
    public partial class Form1 : Form
    {
        ArrayCreator ac = new ArrayCreator();
        TimeChecker tc = new TimeChecker();

        public List<string> container = new List<string>();
        public int ArrayLength { get; private set; }
        public int ArrayRange { get; private set; }
        public string Key { get; private set; }
        public Dictionary<string, IAlgorithm> algorithmsStash { get; private set; }
        public Form1(Dictionary<string, IAlgorithm> dict)
        {
            algorithmsStash = dict;
            foreach (var item in dict)
            {
                container.Add(item.Key);
            }
            InitializeComponent();
            comboBox1.DataSource = container;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Key = (string)comboBox1.SelectedItem;
            ArrayLength = Convert.ToInt32(textBox1.Text);
            ArrayRange = Convert.ToInt32(textBox2.Text);
            // Creating array with length and range from user input.
            //Stopwatch sw = new Stopwatch();
            tc.GetGeneratingTime(ArrayLength, ArrayRange, out int[] array, out TimeSpan genTime);
            //int[] array = ac.GetRandomArray(ArrayLength, ArrayRange);
            TimeSpan sortTime = tc.GetExecutionTime(algorithmsStash[Key], array);
            Form2 form2 = new Form2(Key, sortTime, genTime);
            form2.ShowDialog();
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
    class TimeChecker
    {
        ArrayCreator ac = new ArrayCreator();
        internal TimeSpan GetExecutionTime(IAlgorithm alg, int[] arr)
        {
            // Timer for checking algorithms work time.
            Stopwatch sw = new Stopwatch();
            sw.Start();
            // !!! Initialize sorting are here.
            alg.InitializeSort(arr);
            sw.Stop();
            // Contains information how long time the algorithm took.
            TimeSpan timeResult = sw.Elapsed;
            return timeResult;
        }
        internal void GetGeneratingTime(int ArrayLength, int rangeOfNums, 
            out int[] array, out TimeSpan genTime)
        {
            // Timer for checking array generating work time.
            Stopwatch sw = new Stopwatch();
            sw.Start();
            array = ac.GetRandomArray(ArrayLength, rangeOfNums);
            sw.Stop();
            // Contains information how long time the algorithm took.
            genTime = sw.Elapsed;
        }
    }
}

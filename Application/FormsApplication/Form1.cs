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
using Microsoft.WindowsAPICodePack.Dialogs;

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
        public List<string> timerResults = new List<string>();
        // Results from timers are here
        private int testsCounter { get; set; } = 1;
        public Form1(Dictionary<string, IAlgorithm> dict)
        {
            algorithmsStash = dict;
            foreach (var item in dict)
            {
                container.Add(item.Key);
            }
            InitializeComponent();
            textBox2.Text = "100";
            comboBox1.DataSource = container;
            string h = "1000";
            for (int i = 0; i < 3; i++)
            {
                dataGridView1.Rows.Add(testsCounter, null);
                dataGridView1[1, i].Value = h;
                h += "0";
                testsCounter++;
            }
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
            // new content 
            // В словаре хранятся значение из DataGrid1.
            Dictionary<string, int> gridValues = new Dictionary<string, int>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                gridValues.Add(dataGridView1[0, i].Value.ToString(), Convert.ToInt32(dataGridView1[1, i].Value));
            }
            ArrayRange = Convert.ToInt32(textBox2.Text);
            for (int i = 0; i < 10; i++)
            {
                foreach (var item in gridValues)
                {
                    ArrayLength = Convert.ToInt32(item.Value);
                    // Creating array and getting generating time.
                    tc.GetGeneratingTime(ArrayLength, ArrayRange, out int[] array, out TimeSpan genTime);
                    // Algorithm selected by user.
                    Key = (string)comboBox1.SelectedItem;
                    // Using selected sorting and getting sort time.
                    TimeSpan sortTime = tc.GetExecutionTime(algorithmsStash[Key], array);
                    // Adding to dictionary time results.
                    timerResults.Add($"{item.Key},{sortTime}");
                }
                
            }
            Form3 f3 = new Form3(timerResults);
            f3.ShowDialog();
            
            
            //Key = (string)comboBox1.SelectedItem;
            
            //ArrayRange = Convert.ToInt32(textBox2.Text);
            // Creating array with length and range from user input.
            //Stopwatch sw = new Stopwatch();
            //tc.GetGeneratingTime(ArrayLength, ArrayRange, out int[] array, out TimeSpan genTime);
            //int[] array = ac.GetRandomArray(ArrayLength, ArrayRange);
            //TimeSpan sortTime = tc.GetExecutionTime(algorithmsStash[Key], array);
            //Form2 form2 = new Form2(Key, sortTime, genTime);
            //form2.ShowDialog();
        }

        // Add button.
        private void button2_Click(object sender, EventArgs e)
        {
            // For table autoscroll.
            int firstDisplayed = dataGridView1.FirstDisplayedScrollingRowIndex;
            int displayed = dataGridView1.DisplayedRowCount(true);
            int lastVisible = (firstDisplayed + displayed) - 1;
            int lastIndex = dataGridView1.RowCount - 1;

            dataGridView1.Rows.Add(testsCounter, null);
            testsCounter += 1;
        }
        // Delete button
        private void button3_Click(object sender, EventArgs e)
        {
            var currentCell = dataGridView1.CurrentCell;
            if (currentCell != null)
            {
                var lastRowIndex = currentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(lastRowIndex);
            }
        }
        // Numeration refresh button.
        private void button4_Click(object sender, EventArgs e)
        {
            testsCounter = 1;
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

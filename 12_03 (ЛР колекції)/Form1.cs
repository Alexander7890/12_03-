using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _12_03__ЛР_колекції_
{
    public partial class Form1 : Form
    {
        List<int> collection1 = new List<int>();
        List<int> collection2 = new List<int>();
        List<Label> labels = new List<Label>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int number;
            if (int.TryParse(textBox1.Text, out number))
            {
                collection1.Add(number);
                listBox1.Items.Add(number);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int number;
            if (int.TryParse(textBox2.Text, out number))
            {
                collection2.Add(number);
                listBox2.Items.Add(number);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            collection1 = collection1.Except(collection2).ToList();
            listBox1.Items.Clear();
            foreach (var item in collection1)
            {
                listBox1.Items.Add(item);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            foreach (var index in collection2)
            {
                if (index >= 1 && index <= collection1.Count)
                {
                    listBox3.Items.Add(collection1[index - 1]);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Label label = new Label();
            label.Text = "Label " + (labels.Count + 1);
            label.Top = labels.Count * 20;
            this.Controls.Add(label);
            labels.Add(label);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int index;
            if (int.TryParse(textBox3.Text, out index) && index >= 0 && index < labels.Count)
            {
                labels[index].Text = textBox4.Text;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            List<int> array = new List<int> { random.Next(), random.Next(), random.Next() };
            collection1.Add(array.Sum());
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            var maxSumArray = collection1.OrderByDescending(x => x).First();
            MessageBox.Show("Масив з максимальною сумою елементів: " + maxSumArray);
        }
        //
        private void button9_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            var sortedIndices = collection2.Where(index => index > 0).OrderBy(index => index);
            foreach (var index in sortedIndices)
            {
                if (index >= 1 && index <= collection1.Count)
                {
                    listBox3.Items.Add(collection1[index - 1]);
                }
            }
        }
    }
}

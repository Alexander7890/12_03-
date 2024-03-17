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
        //Додає введене користувачем число до першої колекції.
        private void button1_Click(object sender, EventArgs e)
        {
            int number;
            if (int.TryParse(textBox1.Text, out number))
            {
                collection1.Add(number);
                listBox1.Items.Add(number);
            }
        }
        //Додає введене користувачем число до другої колекції.
        private void button2_Click(object sender, EventArgs e)
        {
            int number;
            if (int.TryParse(textBox2.Text, out number))
            {
                collection2.Add(number);
                listBox2.Items.Add(number);
            }
        }
        //Видаляє з першої колекції всі елементи, які є в другій колекції.
        private void button3_Click(object sender, EventArgs e)
        {
            collection1 = collection1.Except(collection2).ToList();
            listBox1.Items.Clear();
            foreach (var item in collection1)
            {
                listBox1.Items.Add(item);
            }
        }
        //Виводить елементи першої колекції, які відповідають індексам з другої колекції.
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
        //Додає новий елемент до колекції Label.
        private void button5_Click(object sender, EventArgs e)
        {
            Label label = new Label();
            label.Text = "Label " + (labels.Count + 1);
            label.Top = labels.Count * 30;
            this.Controls.Add(label);
            labels.Add(label);
        }
        //Змінює текст елемента колекції Label за вказаним індексом.
        private void button6_Click(object sender, EventArgs e)
        {
            int index;
            if (int.TryParse(textBox3.Text, out index) && index >= 0 && index < labels.Count)
            {
                labels[index].Text = textBox4.Text;
            }
        }
        //Створює масив з трьох випадкових чисел які окремо стоять і додає його до першої колекції 
        private void button7_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int[] array = new int[3];
            for (int i = 0; i < 3; i++)
            {
                array[i] = random.Next(1, 100);
            }
            collection1.Add(array[0]);
            collection1.Add(array[1]);
            collection1.Add(array[2]);
            listBox1.Items.Add(array[0]);
            listBox1.Items.Add(array[1]);
            listBox1.Items.Add(array[2]);
        }

        //Знаходить і показує масив з цієї колекції з максимальною сумою елементів.у колекції знайти масиви з макс і мін сумою, вивести їх номери у колекції і потім їх поміняти місцями
        private void button8_Click_1(object sender, EventArgs e)
        {
            if (collection1.Count < 3)
            {
                MessageBox.Show("Колекція має містити щонайменше 3 елементи.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int maxSum = int.MinValue;
            int minSum = int.MaxValue;
            int maxIndex = 0;
            int minIndex = 0;

            // Шукаємо максимальну та мінімальну суми
            for (int i = 0; i <= collection1.Count - 3; i += 3)
            {
                int sum = collection1[i] + collection1[i + 1] + collection1[i + 2];
                if (sum > maxSum)
                {
                    maxSum = sum;
                    maxIndex = i;
                }
                if (sum < minSum)
                {
                    minSum = sum;
                    minIndex = i;
                }
            }
            listBox3.Items.Clear();
            listBox3.Items.Add("Максимальна сума: " + maxSum);
            listBox3.Items.Add("Мінімальна сума: " + minSum);
            listBox3.Items.Add("Максимальна сума масиву: " + collection1[maxIndex] + ", " + collection1[maxIndex + 1] + ", " + collection1[maxIndex + 2]);
            listBox3.Items.Add("Мінімальна сума масиву: " + collection1[minIndex] + ", " + collection1[minIndex + 1] + ", " + collection1[minIndex + 2]);

            // Зміна місцями масиви з максимальною та мінімальною сумами
            SwapArrays(maxIndex, minIndex);

            UpdateListBox1();
        }
        // Метод для міняння місцями двох масивів у колекції
        private void SwapArrays(int index1, int index2)
        {
            int temp;
            for (int i = 0; i < 3; i++)
            {
                temp = collection1[index1 + i];
                collection1[index1 + i] = collection1[index2 + i];
                collection1[index2 + i] = temp;
            }
        }
        private void UpdateListBox1()
        {
            listBox1.Items.Clear();
            foreach (var item in collection1)
            {
                listBox1.Items.Add(item);
            }
        }
        //Виводить елементи першої колекції, які відповідають індексам з другої колекції, відсортовані за зростанням.
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

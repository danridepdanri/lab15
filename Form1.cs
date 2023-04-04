using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Lab15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0,0";

            
            textBox5.Text = "0,0";

            textBox6.Text = "0,0";
            label2.Text = "  ";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x = 0.0;

            if (Double.TryParse(textBox1.Text, out double result)) { x = Convert.ToDouble(textBox1.Text); }
            else { textBox3.Text = "Введіть число у змінну x"; }


            if (Double.TryParse(textBox1.Text, out double result2))
            { textBox3.Text = Convert.ToString(2 * Math.Cos(3 * x) - 1 / (12 * Math.Pow(x, 2) + 7 * x - 5)); }


        }

      

        private void button2_Click_1(object sender, EventArgs e)
        {
            double r, R;

            if (Double.TryParse(textBox5.Text, out double rr) &&
      Double.TryParse(textBox6.Text, out double RR) &&
      rr < RR)
            {
                r = rr;
                R = RR;
                // Обчисление площади кольца
                double area = Math.PI * (R * R - r * r);
                label2.Text = area.ToString("F2");
            }
            else
            {
                // Обработка ошибки ввода чисел
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double a, b, c;
            if (!double.TryParse(textBox8.Text, out a) || !double.TryParse(textBox9.Text, out b))
            {
                MessageBox.Show("Please enter valid numbers for A and B.");
                return;
            }

            c = (a + b) / 2;
            bool isAverage = c == b || c == a;

            label4.Text = isAverage ? "True" : "False";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double R, a;
            if (double.TryParse(textBox13.Text, out R) && double.TryParse(textBox14.Text, out a))
            {
                if (2 * a <= R * Math.Sqrt(3))
                {
                    label5.Text = string.Format("Правильний трикутник зі стороною {0} може поміститися в коло радіуса {1}", a, R);
                }
                else
                {
                    label5.Text = string.Format("Правильний трикутник зі стороною {0} не може поміститися в коло радіуса {1}", a, R);
                }
            }
            else
            {
                MessageBox.Show("Введіть числові значення");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int n = (int)numericUpDown1.Value; // кількість цифр в числі
            int M = (int)numericUpDown2.Value; // число, на яке має бути кратна сума квадратів цифр

            List<int> results = new List<int>(); // список для зберігання результатів

            // перебираємо всі n-значні числа
            for (int i = (int)Math.Pow(10, n - 1); i < Math.Pow(10, n); i++)
            {
                int sumOfSquares = 0;
                int num = i;

                // обчислюємо суму квадратів цифр
                while (num > 0)
                {
                    int digit = num % 10;
                    sumOfSquares += digit * digit;
                    num /= 10;
                }

                // перевіряємо, чи є сума квадратів цифр кратною M
                if (sumOfSquares % M == 0)
                {
                    results.Add(i);
                }
            }

            // виводимо результати на форму
            listBox1.Items.Clear();
            foreach (int result in results)
            {
                listBox1.Items.Add(result);
            }
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int[] cubes = new int[10]; // масив для зберігання значень на гранях кубиків

            // зчитуємо значення двох вже вставлених кубиків з текстових полів
            int cube1 = int.Parse(textBox21.Text);
            int cube2 = int.Parse(textBox22.Text);
            cubes[0] = cube1;
            cubes[1] = cube2;

            // розраховуємо значення на гранях для решти кубиків
            for (int i = 2; i < 10; i++)
            {
                cubes[i] = 10 - cubes[i - 1] - cubes[i - 2]; // сума трьох сусідніх граней завжди має бути 10
            }

            // виводимо отриманий код замка у текстове поле
            label6.Text = string.Join("", cubes);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string input = textBox26.Text; // отримати вхідний рядок з текстового поля

            string[] words = input.Split(';'); // розділити рядок на окремі слова

            int count = 0; // змінна для підрахунку слів, що закінчуються на "а"

            foreach (string word in words)
            {
                if (word.EndsWith("а")) // перевірити, чи закінчується слово на "а"
                {
                    count++; // якщо так, збільшити лічильник
                }
            }

            label7.Text = "Кількість слів, що закінчуються на 'а': " + count; // відобразити результат на мітці Label
        }
    }
    }


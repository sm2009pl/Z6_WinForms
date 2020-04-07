using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Z6_WinForms
{
    public partial class Form1 : Form
    {
        List<string> numbers = new List<string>();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = numbers;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            var dialog = (OpenFileDialog)sender;
            var path = dialog.FileName;
            var content = File.ReadAllText(path);
            //textBox1.Text = content;
            foreach(var item in content.Split(new[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries))
            {
                //numbers.Add(new Number() { value = item });
                flowLayoutPanel1.Controls.Add(GenerateNumberTextBox(Convert.ToInt32(item)));
            }

        }
        private TextBox GenerateNumberTextBox(int number)
        {
            return new TextBox()
            {
                Text = number.ToString(),
                ReadOnly = true,
                Width = 32
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            for(int i = 0; i < 100; i++)
            {
                var randomNumber = rnd.Next(100).ToString();
                textBox1.Text = randomNumber;
                flowLayoutPanel2.Controls.Add(GenerateNumberTextBox(randomNumber));
                Application.DoEvents();
            }
        }
    }
}

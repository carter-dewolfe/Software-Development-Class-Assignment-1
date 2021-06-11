using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Project01_Assignment01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader outFile;
            double sale;
            double total = 0;
            double average = 0;
            double max = Double.MinValue;
            double min = Double.MaxValue;
            int count = 0;

            try
            {
                outFile = File.OpenText("Sales.txt");

                while (!outFile.EndOfStream)
                {
                    sale = Convert.ToDouble(outFile.ReadLine());

                    total += sale;
                    count++;
                    if(sale > max)
                    {
                        max = sale;
                    }
                    if (sale < min)
                    {
                        min = sale;
                    }

                    listBox1.Items.Add(sale);
                }

                average = total / count;

                outFile.Close();
                totalLabel.Text = total.ToString();
                averageLabel.Text = average.ToString();
                maxLabel.Text = max.ToString();
                minLabel.Text = min.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

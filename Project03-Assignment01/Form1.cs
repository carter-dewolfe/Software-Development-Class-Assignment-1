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

namespace Project03_Assignment01
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
            int year = 1951;
            double total = 0;
            double average = 0;
            double max = Double.MinValue;
            int maxYear  = 0;
            double min = Double.MaxValue;
            int minYear = 0;
            double increase = 0;
            double currentPopulation = 0;
            double firstPopulation = 0;
            int count = 0;
            List<double> usPopulation = new List<double>();

            try
            {
                outFile = File.OpenText("USPopulation.txt");

                listBox1.Items.Add("Year   Increase");
                listBox1.Items.Add("---------------------------------------");
                firstPopulation = Convert.ToDouble(outFile.ReadLine());

                while (!outFile.EndOfStream)
                {
                    currentPopulation = Convert.ToDouble(outFile.ReadLine());
                    increase = currentPopulation - firstPopulation;
                    firstPopulation = currentPopulation;
                    total += increase;

                    if (increase > max)
                    {
                        max = increase;
                        maxYear = year;
                    }
                    if (increase < min)
                    {
                        min = increase;
                        minYear = year;
                    }

                    listBox1.Items.Add(year + "   " + increase);
                    year++;
                    count++;
                }


                average = total / count;

                outFile.Close();
                averageLabel.Text = average.ToString();
                greatestLabel.Text = maxYear.ToString();
                lowestLabel.Text = minYear.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

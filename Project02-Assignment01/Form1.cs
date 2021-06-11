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

namespace Project02_Assignment01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader outFile1;
            StreamReader outFile2;
            string answer;
            string studentAnswer;
            int correct;
            int incorrect;
            int questionNumber;

            try
            {
                outFile1 = File.OpenText("Answer Key.txt");
                outFile2 = File.OpenText("Test.txt");
                correct = 0;
                incorrect = 0;
                questionNumber = 0;

                while (!outFile1.EndOfStream)
                {
                    answer = outFile1.ReadLine();
                    studentAnswer = outFile2.ReadLine();

                    questionNumber++;
                    if(answer == studentAnswer)
                    {
                        correct++;
                    }
                    else
                    {
                        incorrect++;
                        listBox1.Items.Add("Question " + questionNumber);
                    }
                }

                correctLabel.Text = correct.ToString();
                incorrectLabel.Text = incorrect.ToString();
                if(correct >= 15)
                {
                    passFailLabel.Text = "You Passed!";
                }
                else
                {
                    passFailLabel.Text = "You Failed...";
                }
                outFile1.Close();
                outFile2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        StreamWriter outFile;
        private void Button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                outFile = File.AppendText(saveFileDialog1.FileName);
            }
        }
    }
}

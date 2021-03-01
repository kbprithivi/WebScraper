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

namespace WebScraper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // To do scrap the data from a website
        
        private async void Button1_Click(object sender, EventArgs e)
        {
           DataScrap data = new DataScrap();
           var link = textBox2.Text;// URl of the Website.
           bool check= Checkvalid(link);
            if(check== false) // If URL is not valid alert the user
            {
                MessageBox.Show("Enter a valid url", "Error");
                Console.WriteLine("hii");
                
            }
            if (check== true)// if valid url is provided then data will be scraped
            { 
                data.DataLink(link);
                Console.WriteLine(link);
                textBox1.Text = "please Wait Fetching Data from ebay.com.au";
                Task<List<string>> task = new Task<List<string>>(data.Scrapdata);
                task.Start();
                List<string> scrapeddata = new List<string>();
                scrapeddata = await task;
                Print_data(scrapeddata);// print the scraped data
                textBox1.Clear();
            }
        }
        //changing the visibility of the label and appending the contents.
        public void Print_data(List<String> scrapeddata)
        {
            LinkLabel1.Visible = true;
            LinkLabel1.Text = scrapeddata[0];
            pictureBox1.Visible = true;
            pictureBox1.ImageLocation = scrapeddata[3];
            label1.Visible = true;
            label2.Visible = true;
            label1.Text = scrapeddata[6];
            label3.Visible = true;
            label3.Text = scrapeddata[5];
            label4.Visible = true;
            label4.Text = scrapeddata[1];
            label5.Visible = true;
            label5.Text = scrapeddata[4];
            label6.Visible = true;
        }
        //Validating the URL
        public bool Checkvalid(string l)
        {
            if ( l == "")
            {
                return false;

            }
            
            if(l.Contains("ebay.com.au"))
            { 
            return true;
            }
            else
            {
                return false;
            }

        }
       
       
    }








}
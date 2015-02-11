using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/**
 *This the action class for a simple web browser form which has following operations:
 *
 * 1. Go -> Navigates to the desire web address given in Textbox(Address Bar)
 * 2. Stop -> Interrupts the process of look up after hitting the 'Go' button and before the response is loaded
 * 3. Refresh -> Refresh the current web page displayed in web browser layout
 * 4. Go Back -> Navigates backward to the previous page visited
 * 5. Go Forward -> Navigates forward to the latest page visited
 * 6. Home -> Navigates to the home page
 * 7.File-Exit -> Exits the browser application
 * 
 * 8. Encryption Decryption Function calling a thrid party Web Service
 * 
 * 9. Stock Quote Funciton calling a third party web service
 * 
 */

namespace BrowserMVM
{
    public partial class Form1 : Form
    {
        //This is the reference for Encryption Decrtyption Service
        BrowserMVM.encrypt_decrypt.Service en_dn = new BrowserMVM.encrypt_decrypt.Service();

        //This is the refernce for StockQuote Service
        BrowserMVM.Stockquote.Service stock = new BrowserMVM.Stockquote.Service();

        public Form1()
        {
            InitializeComponent();
        }

        //Go Foward operation
        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
            textBox1.ResetText();
        }

        //Go Home operation
        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        //Stop Operation
        private void button7_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();
        }

        //Go Operation
        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(textBox1.Text);
        }

        //Refresh Operation
        private void button5_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        //Go Back Operation
        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
            textBox1.ResetText();
        }

        //Exit Browser 
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {

        }


        //Encryption Function calling a third party web service
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Text = "Encrypted Text: " + en_dn.Encrypt(textBox2.Text);
            }
            catch (NullReferenceException ne)
            {
                label1.Text = "Enter Some Value in the Text Box";
                Console.WriteLine("Exception Occurred: " + ne.StackTrace);
            }
            catch (Exception ex)
            {
                label1.Text="Invalid String.. Try Again!!";
                Console.WriteLine("Exception : " + ex.StackTrace);
            }
        }

        //Decryption Function calling a third party wbe service
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Text = "Encrypted Text: " + en_dn.Decrypt(textBox2.Text);
            }
            catch (NullReferenceException ne)
            {
                label1.Text = "Enter Some Value in the Text Box";
                Console.WriteLine("Exception Occurred: " + ne.StackTrace);
            }
            catch (Exception ex)
            {
                label1.Text = "Invalid String.. Try Again!!";
                Console.WriteLine("Exception : " + ex.StackTrace);
            }
        }

        //clears the textbox of encrypt_decrypt funciton
        private void button9_Click(object sender, EventArgs e)
        {
            textBox2.ResetText();
            label1.ResetText();
        }


        //Returns the Stock Value of the given symbol by calling a thrid party stock quote web service
        private void button10_Click(object sender, EventArgs e)
        {
            label1.ResetText();
            try
            {
                label2.Text = "Stock Quote: " + stock.getStockquote(textBox3.Text);
            }

            catch (Exception ex)
            {
                label2.Text = "Enter a Valid Stock Symbol and Try Again!!";
                Console.WriteLine("Exception Occurred: " + ex.StackTrace);
            }

        }

        
    }
}
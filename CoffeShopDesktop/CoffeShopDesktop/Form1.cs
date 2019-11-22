using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeShopDesktop
{
    public partial class Form1 : Form
    {
        private string url = "https://heroku-patrik.herokuapp.com/api/";
        static HttpClient client = new HttpClient();


        public Form1()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(url);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int value;

            if (int.TryParse(textBox1.Text, out value))
            {

                    var responseTask = client.GetAsync($"manufacturer/{value}");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {

                        var readTask = result.Content.ReadAsAsync<Manufacturer>();
                        readTask.Wait();

                        var response = readTask.Result;

                        textBox2.Text = response.Name;
                        textBox3.Text = response.Country;
                        textBox4.Text = response.Address;
                        textBox5.Text = response.Phone;
                    } 
                    else 
                {
                    MessageBox.Show("Nincs ilyen ID vagy kommunikációs hiba");
                    textboxErase();
                }
            }
            else
            {

                    var responseTask = client.GetAsync("manufacturer");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {

                        var readTask = result.Content.ReadAsAsync<List<Manufacturer>>();
                        readTask.Wait();

                        var manufacturers = readTask.Result;

                        ManufactutersList mf = new ManufactutersList(manufacturers);
                        mf.Show();
                    }
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textboxErase();

        }

        private void textboxErase()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int value;

            if (int.TryParse(textBox1.Text, out value) && textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && textBox4.Text.Length > 0 && textBox5.Text.Length > 0)
            {
                Manufacturer mf = new Manufacturer();
                mf.Id = value;
                mf.Name = textBox2.Text;
                mf.Country = textBox3.Text;
                mf.Address = textBox4.Text;
                mf.Phone = textBox5.Text;

                var postTask = client.PostAsJsonAsync<Manufacturer>("manufacturer", mf);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<Manufacturer>();
                    readTask.Wait();

                    var insertedStudent = readTask.Result;

                    MessageBox.Show($"A {insertedStudent.Name} cég hozzáadva {insertedStudent.Id} ID-vel");
                    textboxErase();
                }
                else
                {
                    MessageBox.Show("Valami huba a feltöltéssel");
                    textboxErase();
                }

            }



        }
    }
}

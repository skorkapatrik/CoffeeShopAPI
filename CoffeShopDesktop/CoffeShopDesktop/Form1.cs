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
        private string url = "http://localhost:8080/";
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int value;

            if (int.TryParse(textBox1.Text, out value))
            {
                string urlParameters = $"manufacturer/{value}";
                var response = APICall.RunAsync<Manufacturer>(url, urlParameters).GetAwaiter().GetResult();

                textBox2.Text = response.Name;
                textBox3.Text = response.Country;
                textBox4.Text = response.Address;
                textBox5.Text = response.Phone;


            }
            else
            {
                string urlParameters = $"manufacturer/";
                var response = APICall.RunAsync<List<Manufacturer>>(url, urlParameters).GetAwaiter().GetResult();
                
            }
        }

    }
}

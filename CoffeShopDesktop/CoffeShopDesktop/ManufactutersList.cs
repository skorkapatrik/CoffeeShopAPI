using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeShopDesktop
{
    public partial class ManufactutersList : Form
    {

        public ManufactutersList(List<Manufacturer> mflist)
        {
            InitializeComponent();
            var ds = mflist.AsEnumerable();
            dataGridView1.DataSource = ds;
            dataGridView1.Columns["id"].HeaderText = "ID";
            dataGridView1.Columns["name"].HeaderText = "Cégnév";
            dataGridView1.Columns["country"].HeaderText = "Ország";
            dataGridView1.Columns["address"].HeaderText = "Cím";
            dataGridView1.Columns["phone"].HeaderText = "Telefonszám";

        }
    }
}

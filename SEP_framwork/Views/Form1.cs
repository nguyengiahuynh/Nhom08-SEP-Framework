using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SEP_framwork.Controllers.HandleController;
using SEP_framwork.Views.FormData;

namespace SEP_framwork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = @"Data Source=DESKTOP-BSMAOJ9;Initial Catalog=QuanLyKhachSan1;Integrated Security=True";
            BaseForm b = new AddForm(url,"HoaDon");
        }
    }
}

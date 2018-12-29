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
using SEP_framwork.Factory;

namespace SEP_framwork
{
    public partial class Form1 : Form
    {
        FormFactory formFactory = new FormFactory();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cnnString = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=MemberForum;Integrated Security=True";
            BaseForm addForm = formFactory.getForm(Factory.typeForm.READ, cnnString, "Member");
            addForm.ShowForm();
        }
    }
}

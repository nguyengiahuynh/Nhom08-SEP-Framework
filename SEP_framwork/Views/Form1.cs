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
        string cnnString = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=MemberForum;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BaseForm addForm = formFactory.getForm(Factory.typeForm.ADD, cnnString, "Member");
            addForm.SetPrimaryKey("ID");
            addForm.SetupForm();
            addForm.ShowForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BaseForm readForm = formFactory.getForm(Factory.typeForm.READ, cnnString, "Member");
            readForm.ExceptColumns(new string[] { "ID" });
            readForm.ChangeNameColumns(new Dictionary<string, string>() {
                { "Username", "Tên tài khoản" },
                { "Password", "Mật khẩu" },
                { "HoTen", "Họ và Tên" },
                { "GioiTinh", "Giới tính" }
            });
            readForm.SetupForm();
            readForm.ShowForm();
        }
    }
}

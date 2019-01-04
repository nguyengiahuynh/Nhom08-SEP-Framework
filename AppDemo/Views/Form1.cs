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

namespace AppDemo
{
    public partial class Form1 : Form
    {
        FormFactory formFactory = new FormFactory();
        string cnnString = @"Data Source=DESKTOP-GN3V8MM\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void Read_Click(object sender, EventArgs e)
        {
            BaseForm readForm = formFactory.getForm(SEP_framwork.Factory.typeForm.READ, cnnString, "HocSinh");
            readForm.ExceptColumns(new string[] { "isDelete" });
            //readForm.ChangeNameColumns(new Dictionary<string, string>() {
            //    { "Username", "Tên tài khoản" },
            //    { "Password", "Mật khẩu" },
            //    { "HoTen", "Họ và Tên" },
            //    { "GioiTinh", "Giới tính" }
            //});
            readForm.SetupForm();
            readForm.ShowForm();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            BaseForm addForm = formFactory.getForm(SEP_framwork.Factory.typeForm.ADD, cnnString, "HocSinh");
            addForm.SetPrimaryKey("id");
            addForm.SetupForm();
            addForm.ShowForm();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            BaseForm updateForm = formFactory.getForm(SEP_framwork.Factory.typeForm.UPDATE, cnnString, "HocSinh");
            updateForm.ExceptColumns(new string[] { "isDelete" });
            updateForm.SetPrimaryKey("id");
            updateForm.SetupForm();
            updateForm.ShowForm();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            BaseForm deleteForm = formFactory.getForm(SEP_framwork.Factory.typeForm.DELETE, cnnString, "HocSinh");
            deleteForm.ExceptColumns(new string[] { "isDelete" });
            deleteForm.SetPrimaryKey("id");
            deleteForm.SetupForm();
            deleteForm.ShowForm();
        }
    }
}

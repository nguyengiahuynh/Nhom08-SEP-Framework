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
using AppDemo.Views.FormData;
using AppDemo.Factory;
using AppDemo.Membership;

namespace AppDemo
{
    public partial class Form1 : Form
    {
        string cnnString = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=MemberForum;Integrated Security=True";
        FormFactory formFactory = new FormFactory();
        public Form1()
        {
            InitializeComponent();
            Member membership = new Member(cnnString);  //Apply membership cho login, register, logout
        }

        private void Read_Click(object sender, EventArgs e)
        {
            BaseForm readForm = formFactory.getForm(Factory.typeForm.READ, cnnString, "Member");
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
            BaseForm addForm = formFactory.getForm(Factory.typeForm.ADD, cnnString, "Member");
            addForm.SetPrimaryKey("id");
            addForm.SetupForm();
            addForm.ShowForm();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            BaseForm updateForm = formFactory.getForm(Factory.typeForm.UPDATE, cnnString, "Member");
            updateForm.ExceptColumns(new string[] { "isDelete" });
            updateForm.SetPrimaryKey("id");
            updateForm.SetupForm();
            updateForm.ShowForm();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            BaseForm deleteForm = formFactory.getForm(Factory.typeForm.DELETE, cnnString, "Member");
            deleteForm.ExceptColumns(new string[] { "isDelete" });
            deleteForm.SetPrimaryKey("id");
            deleteForm.SetupForm();
            deleteForm.ShowForm();
        }
    }
}

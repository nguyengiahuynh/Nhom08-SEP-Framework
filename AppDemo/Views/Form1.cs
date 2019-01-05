using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppDemo.Controllers.HandleController;
using AppDemo.Views.FormData;
using AppDemo.Factory;
using AppDemo.Membership;

namespace AppDemo
{
    public partial class Form1 : Form
    {
        FormFactory formFactory = new FormFactory();
        string cnnString = @"Data Source=DESKTOP-BSMAOJ9;Initial Catalog=QuanLyKhachSan1;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
            Member membership = new Member(cnnString);  //Apply membership cho login, register, logout
        }

        private void Read_Click(object sender, EventArgs e)
        {
            BaseForm readForm = formFactory.getForm(AppDemo.Factory.typeForm.READ, cnnString, "LoaiPhong");
            //readForm.ExceptColumns(new string[] { "isDelete" });
            //readForm.ChangeNameColumns(new Dictionary<string, string>() {
            //    { "Username", "Tên tài khoản" },
            //    { "Password", "Mật khẩu" },
            //    { "HoTen", "Họ và Tên" },
            //    { "GioiTinh", "Giới tính" }
            //});
            //readForm.SetupForm();
            readForm.ShowForm();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            BaseForm addForm = formFactory.getForm(AppDemo.Factory.typeForm.ADD, cnnString, "LoaiPhong");
            //addForm.SetPrimaryKey("id");
            //addForm.SetupForm();
            addForm.ShowForm();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            BaseForm updateForm = formFactory.getForm(AppDemo.Factory.typeForm.UPDATE, cnnString, "LoaiPhong");
            //updateForm.ExceptColumns(new string[] { "isDelete" });
            //updateForm.SetPrimaryKey("id");
            //updateForm.SetupForm();
            updateForm.ShowForm();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            BaseForm deleteForm = formFactory.getForm(AppDemo.Factory.typeForm.DELETE, cnnString, "LoaiPhong");
            //deleteForm.ExceptColumns(new string[] { "isDelete" });
            //deleteForm.SetPrimaryKey("id");
            //deleteForm.SetupForm();
            deleteForm.ShowForm();
        }
    }
}

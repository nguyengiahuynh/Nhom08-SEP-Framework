﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppDemo.Views.FormData;
using AppDemo.Factory;

namespace AppDemo.Views
{
    public partial class Home : Form
    {
        FormFactory formFactory = new FormFactory();
        string cnnString = @"Data Source=LAPTOP-L497P98H;Initial Catalog=QLTBDT;Integrated Security=True";

        public Home()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomDataGrid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            BaseForm readForm = formFactory.getForm(AppDemo.Factory.typeForm.READ, cnnString, "ThietBiDienTu", null);
            readForm.ShowForm();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            BaseForm addForm = formFactory.getForm(AppDemo.Factory.typeForm.ADD, cnnString, "ThietBiDienTu", null);
            addForm.ShowForm();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            BaseForm updateForm = formFactory.getForm(AppDemo.Factory.typeForm.UPDATE, cnnString, "ThietBiDienTu", null);
            updateForm.ShowForm();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            BaseForm deleteForm = formFactory.getForm(AppDemo.Factory.typeForm.DELETE, cnnString, "ThietBiDienTu", null);
            deleteForm.ShowForm();
        }
    }
}

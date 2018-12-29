using SEP_framwork.Controllers.HandleController;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEP_framwork.Views.FormData
{
    public class BaseForm
    {
        protected Dictionary<string, Label> labelList = new Dictionary<string, Label>();
        protected Dictionary<string, TextBox> textList = new Dictionary<string, TextBox>();
        protected Button save;
        protected Button cancel;
        protected Form form;
        protected string nameTable;
        protected HandleController controllerData;
        protected virtual void clickSave() { }
        public BaseForm(string cnnString, string nameTable)
        {
            this.form = new Form();
            form.Text = "SIMPLE ENTERPRISE FRAMWORK";
            this.nameTable = nameTable;
            this.controllerData = new HandleController(cnnString);
            this.InitializeForm();

            this.save.Click += Save_Click;
            this.cancel.Click += Cancel_Click;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.form.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            this.clickSave();
        }

        public void ShowForm()
        {
            this.AddTitle();
            this.form.Show();
        }

        protected virtual void InitializeForm() { }
        protected virtual void AddTitle() { }
    }
}

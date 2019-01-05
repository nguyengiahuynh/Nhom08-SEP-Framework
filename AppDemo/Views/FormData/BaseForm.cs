using SEP_framwork.Controllers.HandleController;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDemo.Views.FormData
{
    public class BaseForm
    {
        protected DataGridView gridView = new DataGridView();
        protected string nameTable;
        protected string primaryKey;
        protected Button save;
        protected Button cancel;
        protected Form form;
        protected HandleController controllerData;

        public BaseForm(string cnnString, string nameTable)
        {
            this.form = new Form();
            form.Text = "SIMPLE ENTERPRISE FRAMWORK";
            this.nameTable = nameTable;
            this.controllerData = new HandleController(cnnString);

            this.save = new Button();
            this.cancel = new Button();

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

        public void SetupForm()
        {
            this.InitializeForm();
        }

        public void SetPrimaryKey(string key)
        {
            primaryKey = key;
        }

        protected virtual void InitializeForm() { }
        protected virtual void AddTitle() { }
        protected virtual void clickSave() { } 
        public virtual void ExceptColumns(string[] cols) { }
        public virtual void ChangeNameColumns(Dictionary<string, string> listName) { }
    }
}

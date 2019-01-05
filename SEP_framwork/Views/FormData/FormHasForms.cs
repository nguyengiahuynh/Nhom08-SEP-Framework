using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEP_framwork.Views.FormData
{
    class FormHasForms : BaseForm
    {
        protected List<BaseForm> listForms = new List<BaseForm>();
        protected Button otherForm;
        protected BaseForm rootForm;
        protected ComboBox cb;
        
        public FormHasForms(string cnnString, string nameTable, BaseForm rootForm) : base(cnnString, nameTable)
        {
            this.form = rootForm.form;
            this.rootForm = rootForm;
            this.otherForm = new Button();
            this.cb = new ComboBox();
            this.otherForm.Click += OtherForm_Click; ;
        }

        private void OtherForm_Click(object sender, EventArgs e)
        {
            this.listForms[this.cb.SelectedIndex].ShowForm();
        }

        public override void InsertForm(BaseForm f)
        {
            listForms.Add(f);
        }

        public override void ShowForm()
        {
            this.rootForm.ShowForm();
            this.SetSizeAndAddButton(this.rootForm.form.Height, this.rootForm.form.Width);
        }

        public override void SetSizeAndAddButton(int height, int width)
        {
            this.otherForm.Text = "Open";
            this.otherForm.Location = new Point(width / 2 - 250, height - save.Height - 80);

            for (int i = 0; i < this.listForms.Count; i++)
            {
                this.cb.Items.Add(this.listForms[i].title);
            }

            this.cb.Location = new Point(width / 2 - 370, height - save.Height - 80);
            this.cb.Width = 115;
            if (this.listForms.Count > 0)
                this.cb.SelectedIndex = 0;
            else
                this.otherForm.Enabled = false;

            this.cb.DropDownStyle = ComboBoxStyle.DropDownList;
            form.Controls.Add(this.otherForm);
            form.Controls.Add(this.cb);
        }
    }
}

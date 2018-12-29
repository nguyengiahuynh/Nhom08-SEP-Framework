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
    class ReadForm : BaseForm
    {
        public ReadForm(string cnnString, string nameTable) : base(cnnString, nameTable)
        {
        }

        protected override void InitializeForm()
        {
            DataTable dt = controllerData.ReadData(nameTable);

            form.Width = 500;
            form.Height = labelList.ElementAt(labelList.Count - 1).Value.Location.Y + labelList.ElementAt(labelList.Count - 1).Value.Height + 50;

            this.cancel = new Button();
            this.cancel.Text = "Close";
            this.cancel.Location = new Point(260, form.Height - 20);

            form.Controls.Add(this.cancel);
            form.Height = cancel.Location.Y + cancel.Height + 80;
        }

        protected override void AddTitle()
        {
            Label title = new Label();
            title.Name = "Title Label";
            title.Text = "Form Read Data";
            title.AutoSize = true;
            title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title.Location = new System.Drawing.Point(form.Width / 2 - title.Width / 2 - 20, 10);
            form.Controls.Add(title);
        }

        private void InitDataGridView()
        {
            DataGridView gridView = new DataGridView();
            DataGridViewTextBoxColumn mahs = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn tenhs = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn gioitinh = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn diachi = new DataGridViewTextBoxColumn();
        }
    }
}

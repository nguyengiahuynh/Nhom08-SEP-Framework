using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEP_framwork.Views.FormData;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace SEP_framwork.Views.FormData
{
    public class AddForm: BaseForm
    {
        protected override void clickSave()
        {
            MessageBox.Show("trung");
        }
        public AddForm(string url, string nameTable) : base(url, nameTable)
        {
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        }

        protected override void InitializeForm()
        {
            int y = 0;
            foreach (DataColumn item in controllerData.ReadData(nameTable).Columns)
            {
                Label tmp = new Label();
                TextBox txt = new TextBox();
                txt.Name = item.ColumnName;
                txt.Width = 100;
                tmp.Text = item.ColumnName;
                labelList.Add("Label " + item.ColumnName, tmp);
                textList.Add("Text " + item.ColumnName, txt);
                tmp.Location = new Point(150, 60 + y * 30);
                txt.Location = new Point(250, 60 + y * 30);
                y++;
                form.Controls.Add(tmp);
                form.Controls.Add(txt);
            }

            form.Width = 500;
            form.Height = labelList.ElementAt(labelList.Count - 1).Value.Location.Y + labelList.ElementAt(labelList.Count - 1).Value.Height + 50;

            this.save = new Button();
            this.cancel = new Button();

            this.save.Text = "OK";
            this.save.Location = new Point(150, form.Height - 20);

            this.cancel.Text = "Cancel";
            this.cancel.Location = new Point(260, form.Height - 20);

            form.Controls.Add(this.save);
            form.Controls.Add(this.cancel);
            form.Height = save.Location.Y + save.Height + 80;
        }

        protected override void AddTitle()
        {
            Label title = new Label();
            title.Name = "Title Label";
            title.Text = "Form Add Data";
            title.AutoSize = true;
            title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title.Location = new System.Drawing.Point(form.Width / 2 - title.Width / 2 - 20, 10);
            form.Controls.Add(title);
        }
    }
}

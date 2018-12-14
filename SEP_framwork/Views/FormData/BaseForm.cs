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
        protected List<Label> label;
        protected List<TextBox> text;
        protected Button save;
        protected Button cancel;
        protected Form form;
        protected HandleController controllerData;
        protected virtual void clickSave() { }
        public BaseForm(string url, string nameTable)
        {
            this.form = new Form();

            this.controllerData = new HandleController(url);
            this.label = new List<Label>();
            this.text = new List<TextBox>();
            int y = 0;
            foreach (DataColumn item in controllerData.ReadData(nameTable).Columns)
            {
                Label tmp = new Label();
                TextBox txt = new TextBox();
                txt.Name = item.ColumnName;
                txt.Width = 100;
                tmp.Text = item.ColumnName;
                label.Add(tmp);
                text.Add(txt);
                tmp.Location = new Point(100, 20 + y * 30);
                txt.Location = new Point(200, 20 + y * 30);
                y++;
                form.Controls.Add(tmp);
                form.Controls.Add(txt);
            }
            form.Width = 500;
            form.Height = label[label.Count - 1].Location.Y + label[label.Count - 1].Height + 50;
            
            this.save = new Button();
            this.save.Click += Save_Click;
            this.cancel = new Button();
            this.cancel.Text = "Cancel";
            this.save.Text = "OK";
            this.save.Location = new Point(100, form.Height - 30);
            this.cancel.Location = new Point(200, form.Height - 30);
            form.Controls.Add(this.save);
            form.Controls.Add(this.cancel);
            form.Height = save.Location.Y + save.Height + 50;
            //form.Controls.Add(cancel);
            this.form.Show();
        }
        
        private void Save_Click(object sender, EventArgs e)
        {
            this.clickSave();
        }
    }
}

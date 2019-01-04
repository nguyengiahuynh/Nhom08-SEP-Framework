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
        private DataTable dt;
        private DataGridView gridView = new DataGridView();
        private Dictionary<string, string> listNameTable = new Dictionary<string, string>();
        private string[] exceptCols;
        public ReadForm(string cnnString, string nameTable) : base(cnnString, nameTable)
        {
            form.AutoSize = true;
            form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        protected override void InitializeForm()
        {
            if (!controllerData.ReadDataFirstTime(nameTable).Columns.Contains("isDelete"))
            {
                controllerData.InitData(nameTable);
            }
            form.Width = 1000;
            this.InitDataGridView();
            this.save.Text = "Refresh";
            this.save.Location = new Point(400, form.Height + 40);
            this.cancel.Text = "Close";
            this.cancel.Location = new Point(550, form.Height + 40);
            form.Controls.Add(this.save);
            form.Controls.Add(this.cancel);

            form.Height = cancel.Location.Y + cancel.Height + 60;
        }

        protected override void clickSave()
        {
            this.InitDataGridView();
        }

        protected override void AddTitle()
        {
            Label title = new Label();
            title.Name = "Title Label";
            title.Text = "Form Read Data";
            title.AutoSize = true;
            title.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            title.Location = new Point(form.Width / 2 - title.Width / 2 - 20, 10);
            form.Controls.Add(title);
        }

        private void InitDataGridView()
        {
            gridView.Columns.Clear();
            gridView.Refresh();
            dt = controllerData.ReadData(nameTable);
            DataGridViewColumn[] columns = { };
            List<string> tempCols = null;
            if (exceptCols != null)
            {
                tempCols = exceptCols.ToList();
            }

            foreach (DataColumn item in dt.Columns)
            {
                string res = "";
                if(tempCols != null)
                {
                    res = tempCols.Find((str) =>
                    {
                        return str == item.ColumnName;
                    });
                }

                if (String.IsNullOrEmpty(res))
                {
                    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    column.DataPropertyName = item.ColumnName;
                    column.HeaderText = listNameTable.ContainsKey(item.ColumnName) ? listNameTable[item.ColumnName] : item.ColumnName;
                    column.Name = item.ColumnName;
                    column.ReadOnly = true;
                    columns = columns.Concat(new DataGridViewColumn[] { column }).ToArray();
                }
            }

            gridView.Columns.AddRange(columns);
            if(tempCols != null)
            {
                foreach(string i in tempCols)
                {
                    dt.Columns.Remove(i);
                }
            }

            gridView.DataSource = dt;
            gridView.Location = new Point(0, 100);
            gridView.Size = new Size(1000, 200);
            gridView.Name = "Data Table";
            gridView.ReadOnly = true;
            form.Controls.Add(gridView);
        }

        public override void ChangeNameColumns(Dictionary<string, string> listName)
        {
            listNameTable = listName;
        }

        public override void ExceptColumns(string[] cols)
        {
            exceptCols = cols;
        }
    }
}

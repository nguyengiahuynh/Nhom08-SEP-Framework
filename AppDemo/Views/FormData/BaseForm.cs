using AppDemo.Controllers.HandleController;
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
        protected string SaveText = "Ok";
        protected string CancelText = "Cancel";
        public Form form;
        protected AbstractHandleController controllerData;
        protected Dictionary<string, string> listNameTable = new Dictionary<string, string>();
        protected string[] exceptCols;
        protected DataTable dt;
        protected Dictionary<string, Label> labelList = new Dictionary<string, Label>();
        protected Dictionary<string, TextBox> textList = new Dictionary<string, TextBox>();
        public string title = "Base Form";
        protected bool hasLabelList = false;

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

        public virtual void ShowForm()
        {
            this.SetupForm();
            this.AddTitle();
            this.form.Show();
        }

        private void SetupForm()
        {
            this.ExceptColumns(new string[] { "isDelete" });
            this.SetPrimaryKey(controllerData.GetPrimaryKey(nameTable));
            this.InitializeForm();
        }

        private void SetPrimaryKey(string key)
        {
            primaryKey = key;
        }

        protected void InitDataGridView()
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
                if (tempCols != null)
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
            if (tempCols != null)
            {
                foreach (string i in tempCols)
                {
                    dt.Columns.Remove(i);
                }
            }

            gridView.DataSource = dt;
            gridView.Location = hasLabelList ? new Point(0, labelList.ElementAt(labelList.Count - 1).Value.Location.Y + labelList.ElementAt(labelList.Count - 1).Value.Height + 50) : new Point(0, 100);
            gridView.Size = new Size(1000, 200);
            gridView.Name = "Data Table";
            gridView.ReadOnly = true;
            gridView.CellClick += Binding_Data;
            form.Controls.Add(gridView);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0, j = 0; i < textList.Count && j < gridView.ColumnCount; i++, j++)
                {
                    textList.ElementAt(i).Value.Text = dt.Rows[0].ItemArray[j].ToString();
                }
            }
        }

        private void Binding_Data(object sender, DataGridViewCellEventArgs e)
        {
            if (gridView.Rows.Count > -1)
            {
                for (int i = 0, j = 0; i < textList.Count && j < gridView.ColumnCount; i++, j++)
                {
                    textList.ElementAt(i).Value.Text = gridView.Rows[e.RowIndex].Cells[j].Value.ToString();
                }
            }
        }

        protected virtual void InitializeForm() { }

        protected void AddTitle()
        {
            Label title = new Label();
            title.Name = "Title Label";
            title.Text = this.title;
            title.AutoSize = true;
            title.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            title.Location = new Point(form.Width / 2 - title.Width / 2 - 20, 10);
            form.Controls.Add(title);
        }

        protected virtual void clickSave() { }

        public void ExceptColumns(string[] cols)
        {
            exceptCols = cols;
        }

        public virtual void ChangeNameColumns(Dictionary<string, string> listName) { }

        public virtual void SetSizeAndAddButton(int height, int width)
        {
            form.Width = width;
            form.Height = height;

            this.save.Text = this.SaveText;
            this.save.Location = new Point(form.Width / 2 - 100, form.Height - 20);

            this.cancel.Text = this.CancelText;
            this.cancel.Location = new Point(form.Width / 2 + 10, form.Height - 20);

            form.Controls.Add(this.save);
            form.Controls.Add(this.cancel);
            form.Height = save.Location.Y + save.Height + 80;
        }

        public virtual void InsertForm(BaseForm f) { }
    }
}

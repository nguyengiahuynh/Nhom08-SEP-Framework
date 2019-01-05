using AppDemo.Views.FormData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppDemo
{
    public class DeleteForm : BaseForm
    {
        public DeleteForm(string cnnString, string nameTable)
            : base(cnnString, nameTable)
        {
        }

        private DataTable dt;
        private Dictionary<string, string> listNameTable = new Dictionary<string, string>();
        private string[] exceptCols;
        private Dictionary<string, Label> labelList = new Dictionary<string, Label>();
        private Dictionary<string, TextBox> textList = new Dictionary<string, TextBox>();
        protected override void clickSave()
        {
            Dictionary<string, string> src = new Dictionary<string, string>();
            foreach (var i in textList)
            {
                if (i.Value.Text == "")
                {
                    MessageBox.Show("Trường dữ liệu " + i.Key + " còn trống!", "Lỗi");
                    return;
                }
                src.Add(i.Key, i.Value.Text);
            }
            try
            {
                controllerData.DeleteData(src, nameTable, primaryKey);
                foreach (var i in textList)
                {
                    i.Value.Text = "";
                }
                src.Clear();
                MessageBox.Show("Xóa dữ liệu thành công!");
                this.InitDataGridView();
                gridView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa dữ liệu thất bại!");
            }

        }

        protected override void InitializeForm()
        {
            if (!controllerData.ReadDataFirstTime(nameTable).Columns.Contains("isDelete"))
            {
                controllerData.InitData(nameTable);
            }
            int y = 0;
            foreach (DataColumn item in controllerData.ReadData(nameTable).Columns)
            {
                if(item.ColumnName != "isDelete")
                {
                    Label tmp = new Label();
                    TextBox txt = new TextBox();
                    txt.Name = item.ColumnName;
                    txt.Width = 100;
                    tmp.Text = item.ColumnName;
                    labelList.Add(item.ColumnName, tmp);
                    textList.Add(item.ColumnName, txt);
                    if (tmp.Text == primaryKey)
                        txt.Enabled = false;
                    tmp.Location = new Point(400, 60 + y * 30);
                    txt.Location = new Point(500, 60 + y * 30);
                    y++;
                    form.Controls.Add(tmp);
                    form.Controls.Add(txt);
                }
            }

            this.InitDataGridView();

            form.Width = 1000;
            form.Height = gridView.Location.Y + gridView.Height + 50;

            this.save.Text = "Delete";
            this.save.Location = new Point(400, form.Height - 20);

            this.cancel.Text = "Cancel";
            this.cancel.Location = new Point(500, form.Height - 20);

            form.Controls.Add(this.save);
            form.Controls.Add(this.cancel);
            form.Height = save.Location.Y + save.Height + 80;
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
            gridView.Location = new Point(0, labelList.ElementAt(labelList.Count - 1).Value.Location.Y + labelList.ElementAt(labelList.Count - 1).Value.Height + 50);
            gridView.Size = new Size(1000, 200);
            gridView.Name = "Data Table";
            gridView.ReadOnly = true;
            gridView.CellClick += Binding_Data;
            form.Controls.Add(gridView);
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

        protected override void AddTitle()
        {
            Label title = new Label();
            title.Name = "Title Label";
            title.Text = "Form Delete Data";
            title.AutoSize = true;
            title.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            title.Location = new Point(form.Width / 2 - title.Width / 2 - 20, 10);
            form.Controls.Add(title);
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
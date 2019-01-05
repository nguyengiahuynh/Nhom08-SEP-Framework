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
    class ReadForm : BaseForm
    {
        public ReadForm(string cnnString, string nameTable) : base(cnnString, nameTable)
        {
            form.AutoSize = true;
            form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.title = "Form Read Data";
            this.SaveText = "Refresh";
            this.CancelText = "Close";
        }

        protected override void InitializeForm()
        {
            if (!controllerData.ReadDataFirstTime(nameTable).Columns.Contains("isDelete"))
            {
                controllerData.InitData(nameTable);
            }

            this.InitDataGridView();

            this.SetSizeAndAddButton(form.Height, 1000);
        }

        protected override void clickSave()
        {
            this.InitDataGridView();
        }

        public override void ChangeNameColumns(Dictionary<string, string> listName)
        {
            listNameTable = listName;
        }
    }
}

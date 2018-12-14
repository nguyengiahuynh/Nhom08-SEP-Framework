using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEP_framwork.Views.FormData;
using System.Windows.Forms;

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
           
        }
    }
}

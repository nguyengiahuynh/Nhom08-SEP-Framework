using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEP_framwork.Utils
{
    class Router
    {
        private static Dictionary<string, bool> isShow = new Dictionary<string, bool>();

        public static void ChangeForm(Form currentForm, Form nextForm, bool turnBackAble = false)
        {
            nextForm.Location = currentForm.Location;
            nextForm.StartPosition = FormStartPosition.Manual;
            if (turnBackAble)
            {
                nextForm.FormClosing += delegate { currentForm.Show(); };
            }
            else
            {
                nextForm.FormClosing += delegate { currentForm.Close(); };
            }
            nextForm.Show();
            currentForm.Hide();
        }

        public static void ShowFormDialog(Form currentForm, Form frm)
        {
            string frmName = frm.Text;

            if (isShow.ContainsKey(frmName) && isShow[frmName])
            {
                MessageBox.Show("Form này đang được mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frm.Location = currentForm.Location;
                frm.StartPosition = FormStartPosition.CenterScreen;
                isShow[frmName] = true;
                frm.FormClosed += (o, e) => isShow[frmName] = false;
                frm.Show();
            }
        }
    }
}

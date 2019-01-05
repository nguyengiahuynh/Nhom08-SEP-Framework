using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppDemo.Membership;

namespace AppDemo.Views
{
    public partial class SignIn : Form
    {
        public Member menber;
        public SignIn()
        {
            InitializeComponent();
            string url = @"Data Source=LAPTOP-L497P98H;Initial Catalog=QLTBDT;Integrated Security=True";
            menber = new Member(url);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            var user = bunifuMetroTextbox1.Text;
            var pas = bunifuMetroTextbox2.Text;

            if (this.menber.Login(user, pas))
            {
                this.Hide();
                Home home = new Home();
                home.Show();
            }
            else
            {
                Label Mes = new Label();
                Mes.Text = "Tài khoản hoặc mật khẩu sai!";
                Mes.Location = new Point(103, 300);
                Mes.Font = new Font("Microsoft Sans Serif", 12f);
                Mes.Size = new System.Drawing.Size(215, 20);
                Mes.ForeColor = Color.White;
                this.Controls.Add(Mes);
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp signUp = new SignUp();
            signUp.Show();
        }
    }
}

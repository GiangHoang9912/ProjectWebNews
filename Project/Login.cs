using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project.Entity;
using System.Threading;

namespace Project
{
    public partial class Login : Form
    {
        public static bool language;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                language = true;
            }
            else
            {
                language = false;
            }

            List<Account> AccountLists = AccountList.GetAllAccount();
            foreach (Account acc in AccountLists)
            {
                if (textBox1.Text.Equals(acc.UserName) && textBox2.Text.Equals(acc.Pass) && acc.Rule == 1)
                {
                    AdminForm admin = new AdminForm("Admin : "+acc.UserName, this);
                    admin.Show();
                    break;
                }
                else 
                {
                    MessageBox.Show("UserName or Pass was wrong ! Please try again.");
                    break;
                }
            }

            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == false) 
            {
                label1.Text = "Tài Khoản :";
                label2.Text = "Mật Khẩu :";

                button1.Text = "Đăng Nhập";
            }
            else
            {
                label1.Text = "User Name :";
                label2.Text = "Password :";

                button1.Text = "Login";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else 
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}

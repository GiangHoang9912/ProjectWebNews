using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project
{
    public partial class DetailUser : Form
    {
        AdminForm a;

        public DetailUser(Entity.UserInfo user, AdminForm admin)
        {
            InitializeComponent();

            a = admin;
            a.Visible = false;
            txtFullName.Text = user.UserName;
            txtDOB.Text = user.Dob.ToString();
            txtEmail.Text = user.Email;
            txtPhone.Text = user.Phone;
            txtRule.Text = user.RuleName;

            pictureBox1.Image = Image.FromFile(@"C:\Users\giang\source\repos\Project\WebProject\AvatarUser\" + user.AvatarImg);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            if (Login.language == true) 
            {
                label1.Text = "Họ và tên :";
                label2.Text = "Ngày sinh :";
                label3.Text = "Email :";
                label4.Text = "Số điện Thoại: ";
                label5.Text = "Quyền :";

                button1.Text = "Đóng"; 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            a.Visible = true;
        }

        private void DetailUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            a.Visible = true;
        }
    }
}

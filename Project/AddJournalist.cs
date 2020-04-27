using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project.Entity;

namespace Project
{
    public partial class AddJournalist : Form
    {
        string fileAvataPath = "";
        AdminForm a;

        public AddJournalist(AdminForm admin)
        {
            InitializeComponent();

            a = admin;
            a.Visible = false;

            dateTimePicker1.MaxDate = new DateTime(DateTime.Now.Year - 18, DateTime.Now.Month, DateTime.Now.Day);
            textBox6.MaxLength = 15;
            textBox7.MaxLength = 15;

            if (Login.language == true) 
            {
                label1.Text = "Họ và tên :";
                label2.Text = "Ngày Sinh :";
                label3.Text = "Email :";
                label4.Text = "Số Điện Thoại :";
                label5.Text = "Tài Khoản :";
                label6.Text = "Mật Khẩu :";
                label7.Text = "Xác Nhận Mật Khẩu :";

                button1.Text = "Thêm Nhà Báo";
                button2.Text = "Ảnh Đại Diện";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string error = "";

            string FullName = textBox1.Text;
            DateTime DOB = dateTimePicker1.Value;
            string Email = textBox3.Text;
            string Phone = textBox4.Text;
            string AccountName = textBox5.Text;
            string Pass = textBox6.Text;
            string cofirmPass = textBox7.Text;

            //Full name
            if (FullName == null || FullName.Length == 0)
            {
                error = error + "Full Name cant blank.\n";
            }

            //email
            if (Email == null || Email.Length == 0)
            {
                error = error + "Full Email cant blank.\n";
            }
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match1 = emailRegex.Match(Email);
            if (!match1.Success)
            {
                error = error + "Email is incorrect.\n";
            }

            //phone
            if (Phone == null || Phone.Length == 0)
            {
                error = error + "Full Phone cant blank.\n";
            }
            Regex phoneRegex = new Regex(@"^[0]\d{9,10}");
            Match match2 = phoneRegex.Match(Phone);
            if (!match2.Success)
            {
                error = error + "Phone is incorrect.\n";
            }

            //account Name
            if (AccountName == null || AccountName.Length == 0)
            {
                error = error + "Full Account Name cant blank.\n";
            }
            if (AccountName.Length > 100)
            {
                error = error + "Account Name cant bigger than 150 character.\n";
            }

            //pass
            if (Pass == null || Pass.Length == 0)
            {
                error = error + "Full Password cant blank.\n";
            }
            if (cofirmPass == null || cofirmPass.Length == 0)
            {
                error = error + "Full Confirm cant blank.\n";
            }
            if (!(Pass.Equals(cofirmPass)))
            {
                error = error + "Confirm Password diffirent Password.\n";
            }

            foreach (Account acc in AccountList.GetAllAccount())
            {
                if (AccountName.Equals(acc.UserName)) 
                {
                    error = error + "Account Name is exits.\n";
                }
            }

            addJournalist(error, FullName, DOB, Email, Phone, AccountName, Pass);

        }

        private void addJournalist(string err, string fullname, DateTime dob, string email, string phone, string accountname, string pass)
        {
            if (err != null && err.Length != 0)
            {
                txtErr.Text = err;
            }
            else
            {
                string fileAvataName = Path.GetFileNameWithoutExtension(fileAvataPath)+".jpg";

                

                UserInfo.InsertUserIntoDB(fullname, dob, email, phone,fileAvataName);


                string id = Project.Data.AccountDAO.GetUserID().Rows[0][0].ToString();

                Account account = new Account(accountname, pass, 3, Convert.ToInt32(id));

                account.InsertAccount();

                txtErr.Text = "add successful";

                button3.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBox1.Image = new Bitmap(open.FileName);
                // image file path  
                fileAvataPath = open.FileName;
            }
        }
        public static bool closing;
        private void AddJournalist_FormClosing(object sender, FormClosingEventArgs e)
        {
            closing = true;
            a.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

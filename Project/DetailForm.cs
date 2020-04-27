using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project.Entity;

namespace Project
{
    public partial class DetailForm : Form
    {
        AdminForm Admin;

        public DetailForm(News news, AdminForm admin)
        {
           

            string title = news.NewTitle;
            string imgName = news.Imglink;

            Admin = admin;
            InitializeComponent();

            this.Text = news.TypeName;

            textBox2.Text = title;

            panel1.BackgroundImage = Image.FromFile(@"C:\Users\giang\source\repos\Project\WebProject\Logo\" + imgName);

            admin.Visible = false;

            string curDir = Directory.GetCurrentDirectory();
            this.webBrowser1.Url = new Uri(String.Format(@"C:\Users\giang\source\repos\Project\WebProject\HtmlNews\"+news.NewsDocx+".html", curDir));

            if (Login.language == true) 
            {
                button1.Text = "Đóng";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DetailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Admin.Visible = true;
        }
    }
}

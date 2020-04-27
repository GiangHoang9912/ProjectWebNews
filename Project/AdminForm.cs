using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{

    public partial class AdminForm : Form
    {
        public static bool isRuning = true;
        private bool Status = true;
        Login LoginForm;
        public AdminForm(string title, Login login)
        {
            LoginForm = login;
            login.Visible = false;
            isRuning = true;
            InitializeComponent();
            this.Text = title;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            LoadDataMember();
            if (Login.language == true)
            {
                button1.Text = "Thành Viên";
                button2.Text = "Bài Báo";
                button4.Text = "Thêm Nhà Báo";
                button3.Text = "Đăng Xuất";

                button5.Text = "Thống Kê";
            }
        }

        private void LoadDataMember()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add("UserID", "User ID");
            dataGridView1.Columns["UserID"].DataPropertyName = "UserID";

            dataGridView1.Columns.Add("UserName", "User Name");
            dataGridView1.Columns["UserName"].DataPropertyName = "userName";

            dataGridView1.Columns.Add("DOB", "Date Of Birth");
            dataGridView1.Columns["DOB"].DataPropertyName = "dob";

            dataGridView1.Columns.Add("Email", "Email");
            dataGridView1.Columns["Email"].DataPropertyName = "email";

            dataGridView1.Columns.Add("Phone", "Phone");
            dataGridView1.Columns["Phone"].DataPropertyName = "phone";

            dataGridView1.Columns.Add("RuleName", "Rule Name");
            dataGridView1.Columns["RuleName"].DataPropertyName = "ruleName";

            DataGridViewButtonColumn DeleteMemberCol = new DataGridViewButtonColumn();
            DeleteMemberCol.Name = "DeleteUser";
            if (Login.language == false)
            {
                DeleteMemberCol.Text = "Delete";
            } else
            {
                DeleteMemberCol.Text = "Xoá";
            }

            DeleteMemberCol.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(DeleteMemberCol);

            dataGridView1.DataSource = Project.Entity.UserInfoList.GetAllUser();
        }
        private void LoadDataNews()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add("NewID", "News ID");
            dataGridView1.Columns["NewID"].DataPropertyName = "NewID";

            dataGridView1.Columns.Add("NewsTitle", "Title");
            dataGridView1.Columns["NewsTitle"].DataPropertyName = "newTitle";

            dataGridView1.Columns.Add("Type", "Type Name");
            dataGridView1.Columns["Type"].DataPropertyName = "typeName";

            dataGridView1.Columns.Add("Status", "Status");
            dataGridView1.Columns["Status"].DataPropertyName = "Status";

            dataGridView1.Columns.Add("imgLink", "Image Link");
            dataGridView1.Columns["imgLink"].DataPropertyName = "imgLink";

            dataGridView1.Columns.Add("date", "Start Date");
            dataGridView1.Columns["date"].DataPropertyName = "startDate";

            dataGridView1.Columns.Add("journalist", "Journalist Name");
            dataGridView1.Columns["journalist"].DataPropertyName = "journalist";

            dataGridView1.Columns.Add("NewsDox", "News Docx");
            dataGridView1.Columns["NewsDox"].DataPropertyName = "NewsDocx";


            DataGridViewButtonColumn DeleteNewsCol = new DataGridViewButtonColumn();
            DeleteNewsCol.Name = "DeleteNews";
            if (Login.language == false)
            {
                DeleteNewsCol.Text = "Delete";
            }
            else
            {
                DeleteNewsCol.Text = "Xoá";
            }
            DeleteNewsCol.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(DeleteNewsCol);


            dataGridView1.DataSource = Project.Entity.NewList.GetAllNews();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Status = true;
            LoadDataMember();
            button4.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Status = false;
            LoadDataNews();
            button4.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try {
                if (Status) {
                    List<Project.Entity.UserInfo> Search = new List<Entity.UserInfo>();
                    foreach (Project.Entity.UserInfo user in Project.Entity.UserInfoList.GetAllUser())
                    {
                        if (user.UserName.ToLower().Contains(textBox1.Text.ToLower()))
                            Search.Add(user);
                    }
                    if (Search != null || Search.Count != 0)
                    {
                        LoadDataMember();
                        dataGridView1.DataSource = Search;
                    }
                    else
                        LoadDataMember();
                }
                if (!Status)
                {
                    List<Project.Entity.News> Search = new List<Entity.News>();
                    foreach (Project.Entity.News news in Project.Entity.NewList.GetAllNews())
                    {
                        if (news.NewTitle.ToLower().Contains(textBox1.Text.ToLower()))
                            Search.Add(news);
                    }
                    if (Search != null || Search.Count != 0)
                    {
                        LoadDataNews();
                        dataGridView1.DataSource = Search;
                    }
                    else
                        LoadDataNews();
                }
            } catch (Exception) { }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                int ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                if (dataGridView1.Columns[e.ColumnIndex].Name == "DeleteNews" && !Status)
                {
                    DialogResult result = MessageBox.Show("Do you want to delete this News?", "Confirm!", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Project.Data.NewDAO.DeleteNews(ID);
                        LoadDataNews();
                    }
                }
                else
                {
                    if (!Status)
                    {
                        Project.Entity.News GetNews = Project.Entity.NewList.GetNews(ID);
                        DetailForm detail = new DetailForm(GetNews, this);
                        detail.Show();
                    }
                }

                if (dataGridView1.Columns[e.ColumnIndex].Name == "DeleteUser")
                {
                    DialogResult result = MessageBox.Show("Do you want to delete this Member?", "Confirm!", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Project.Data.UserInfoDAO.DeleteUser(Convert.ToInt32(ID));
                        LoadDataMember();
                    }
                }
                else
                {
                    if (Status)
                    {
                        Project.Entity.UserInfo User = Project.Entity.UserInfoList.GetUserByID(ID);
                        DetailUser detail = new DetailUser(User, this);
                        detail.Show();
                    }
                }

            } catch (Exception) {}
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            isRuning = false;
            Visible = false;
            LoginForm.Visible = true;
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            isRuning = false;
            LoginForm.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddJournalist addForm = new AddJournalist(this);
            addForm.Show();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

                string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                MessageBox.Show(id);
        }

        private void AdminForm_Activated(object sender, EventArgs e)
        {
            if (AddJournalist.closing == true)
            {
                LoadDataMember();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            JournalistProcess chart = new JournalistProcess(this);
            chart.Show();
        }
    }
}

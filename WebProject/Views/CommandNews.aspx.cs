using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject.Views
{
    public partial class AddNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.QueryString["NewsID"] != null)
                {
                    Label1.Text = "Update News";

                    int NewsID = Convert.ToInt32(Request.QueryString["NewsID"]);

                    Project.Entity.News news = Project.Entity.NewList.GetNews(NewsID);

                    FileUpload1.Attributes.Add("onchange", "return checkFileExtension(this);");

                    StartDate.Text = news.StartDate.ToString();

                    TextBox1.Text = news.Imglink;

                    filename.Text = news.NewsDocx;

                    TitleNews.Text = news.NewTitle;

                    btnAddNews.Text = "Save";

                    listType.DataTextField = "TypeName";
                    listType.DataValueField = "TypeID";


                    listType.SelectedIndex = news.TypeID - 1;



                    listType.DataSource = Project.Data.TypeNewsDAO.GetAllType();
                    listType.DataBind();

                }
                else
                {
                    Label1.Text = "Add News"; 

                    FileUpload1.Attributes.Add("onchange", "return checkFileExtension(this);");

                    StartDate.Text = DateTime.Now.ToString();


                    listType.DataTextField = "TypeName";
                    listType.DataValueField = "TypeID";

                    listType.DataSource = Project.Data.TypeNewsDAO.GetAllType();
                    listType.DataBind();
                }
            }
        }

        private static string filterFile;

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                if (btnAddNews.Text.Equals("Save"))
                {
                    int NewsID = Convert.ToInt32(Request.QueryString["NewsID"]);

                    filterFile = NewsID + "_" + FileUpload1.FileName;

                }
                else if (btnAddNews.Text.Equals("Add")) 
                {
                    filterFile = (Convert.ToInt32(Project.Data.NewDAO.GetNewsInsert().Rows[0][0]) + 1) + "_" + FileUpload1.FileName;

                }

                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/File Upload/") + filterFile);
                filename.Text = filterFile;
            }

        }

        protected void btnAddNews_Click(object sender, EventArgs e)
        {

            string NewsTitle = TitleNews.Text;

            int typeID = Convert.ToInt32(listType.SelectedValue);

            string img = TextBox1.Text;

            String[] splitImgType = img.Split('.');

            string TypeFileImg = splitImgType[splitImgType.Length - 1];

          

            DateTime startdate = Convert.ToDateTime(StartDate.Text);

            int accountID = Convert.ToInt32(Session["accountID"]);

            string docx = filename.Text;
            string[] splitDocxType = docx.Split('.');
            string TypeFileDocx = splitDocxType[splitDocxType.Length - 1];

            if ((TypeFileDocx.Equals("docx") || TypeFileDocx.Equals("doc")) && TypeFileImg.Equals("jpg"))
            {
                if (btnAddNews.Text.Equals("Add"))
                {
                    int NewsID = Convert.ToInt32(Project.Data.NewDAO.GetNewsInsert().Rows[0][0]) + 1;

                    Project.Data.NewDAO.InsertNews(NewsID,NewsTitle, typeID, img, startdate, accountID, filterFile);

                    error.Text = "Add Succsesful.";
                }
                else if (btnAddNews.Text.Equals("Save"))
                {

                    int NewsID = Convert.ToInt32(Request.QueryString["NewsID"]);

                    Project.Data.NewDAO.UpdateNews(NewsTitle, typeID, img, filename.Text, NewsID);

                    error.Text = "Update Succsesful.";
                }
            }
            else
            {
                error.Text = "Types of file upload were wrong !!!";
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload2.HasFile)
            {
                TextBox1.Text = FileUpload2.FileName;
            }
        }
    }
}
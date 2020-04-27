using Spire.Doc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject.Views
{
    public partial class DowloadFileDocx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("File", typeof(string));
            dt.Columns.Add("Size", typeof(string));
            dt.Columns.Add("Type", typeof(string));

            DirectoryInfo di = new DirectoryInfo(@"C:\Users\giang\source\repos\Project\WebProject\File Upload\");
            FileSystemInfo[] files = di.GetFileSystemInfos();
            var orderedFiles = files.OrderBy(f => f.CreationTime);

            foreach (FileSystemInfo strFile in orderedFiles) 
            {
                FileInfo file = new FileInfo(strFile.FullName);
                dt.Rows.Add(file.Name,file.Length,file.Extension);    
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Download") 
            {
                Response.Clear();
                Response.ContentType = "application/octect-stream";
                Response.AppendHeader("content-disposition","filename="+e.CommandArgument);

                Response.TransmitFile(Server.MapPath("~/File Upload/") + e.CommandArgument);
                Response.End();
            }
            if (e.CommandName == "AddNews")
            {
                textName.Text = e.CommandArgument.ToString();
            }
        }

        protected void button1_Click(object sender, EventArgs e)
        {
            //Create word document
            Document document = new Document();

            string filePath = @"C:\Users\giang\source\repos\Project\WebProject\File Upload\" + textName.Text;

            document.LoadFromFile(filePath);


            //Save doc file to html
            document.SaveToFile(@"C:\Users\giang\source\repos\Project\WebProject\HtmlNews\" + textName.Text + ".html", FileFormat.Html);
            //WordDocViewer(@"C:\Users\giang\source\repos\Project\WebProject\HtmlNews\" + textName.Text + ".html");

            int NewsID = Convert.ToInt32(textName.Text.Split('_')[0]);

            Project.Data.NewDAO.UpdateStatusNews(NewsID);

            Label1.Text = "Generate succesful";
        }
    }
}
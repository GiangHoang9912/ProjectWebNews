using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject.Views
{
    public partial class Home : System.Web.UI.Page
    {

        Project.Entity.News newsSpec;
        protected void Page_Load(object sender, EventArgs e)
        {
            newsSpec = Project.Entity.NewList.GetTop1News();
            if (!IsPostBack)
            {

                NewsSpecs.ImageUrl = @"~\logo\" + newsSpec.Imglink;

                btnNewsSpecs.Text = newsSpec.NewTitle;

                dlNews.DataSource = Project.Data.NewDAO.GetTop10News();
                dlNews.DataBind();

                rpRandomNews.DataSource = Project.Data.NewDAO.GetLittleNewsHome();
                rpRandomNews.DataBind();
            }
        }

        protected void dlNews_ItemCommand(object source, DataListCommandEventArgs e)
        {
            doCommand(e.CommandName);
        }


        protected void btnNewsSpecs_Click(object sender, EventArgs e)
        {
            doCommand(newsSpec.NewID+"");
        }

        protected void rpRandomNews_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            doCommand(e.CommandName);
        }

        private void doCommand(string command) 
        {
            int id = 1;
            try
            {
                id = Convert.ToInt32(command);
                Response.Redirect("DetailNews.aspx?id=" + id);
            }
            catch (Exception)
            {
                Response.Redirect("DetailNews.aspx?id=" + id);
            }
        }
    }
}
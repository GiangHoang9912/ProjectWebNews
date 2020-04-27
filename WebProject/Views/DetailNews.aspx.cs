using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject.Views
{
    public partial class Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    int id = 1;
                    if (Request.QueryString["id"] != null)
                    {
                        id = Convert.ToInt32(Request.QueryString["id"]);
                    }
                    Project.Entity.News news = Project.Entity.NewList.GetNews(id);
                    contentNews.Src = @"~/HtmlNews/" + news.NewsDocx + ".html";

                    string text = news.NewTitle;

                    if (news.NewTitle == null) { Response.Redirect("ErrorPage.aspx"); }

                    List<Project.Entity.Banner> bannerList = Project.Entity.BannerList.GetAllBanner();

                    Random r = new Random();

                    int bannerid = r.Next(1, bannerList.Count - 1);

                    Label2.Text = news.StartDate.ToString();

                    banner.ImageUrl = @"~\Banner Vertical\" + bannerList[bannerid].AdvertisementImage;

                    dlNews.DataSource = Project.Data.NewDAO.GetRandomTop3(id);
                    dlNews.DataBind();

                    rpComment.DataSource = Project.Data.CommentDAO.GetCommentByNewsID(id);
                    rpComment.DataBind();
                }
                else 
                {
                    if (Request.QueryString["cmtID"] != null)
                    {
                       int  cmtID = Convert.ToInt32(Request.QueryString["cmtID"]);
                    }
                }
            }
            catch (Exception) 
            {
                Response.Redirect("ErrorPage.aspx");
            }
            
        }
        protected void dlNews_ItemCommand(object source, DataListCommandEventArgs e)
        {
            int id = 1;
            try
            {
                id = Convert.ToInt32(e.CommandName);
                Response.Redirect("DetailNews.aspx?id=" + id);
            }
            catch (Exception)
            {
                Response.Redirect("DetailNews.aspx?id=" + id);
            }

        }

        protected void Save_Click(object sender, EventArgs e)
        {
            try {
                int NewsID = 1;
                if (Request.QueryString["id"] != null)
                {
                    NewsID = Convert.ToInt32(Request.QueryString["id"]);
                }

                int AccountID = Convert.ToInt32(Session["accountID"].ToString());


                Project.Data.AccountDAO.SaveNews(AccountID, NewsID);
            }
            catch (Exception) { }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int NewsID = Convert.ToInt32(Request.QueryString["id"]);
            int AccountID = Convert.ToInt32(Session["accountID"].ToString());

            if (TextBox1.Text == null || TextBox1.Text.Length == 0)
            {
                Label1.Text = "Comment now is blank.";
            }
            else 
            {
                Label1.Text = "";
                Project.Data.CommentDAO.InsertComment(NewsID, AccountID, TextBox1.Text);
            }

            Response.Redirect("DetailNews.aspx?id="+NewsID);
        }

        protected void rpComment_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int NewsID = Convert.ToInt32(Request.QueryString["id"]);
            if (e.CommandName.Equals("DeleteCmt")) 
            {
                Project.Data.CommentDAO.deleteComment(Convert.ToInt32(e.CommandArgument));
            }
            Response.Redirect("DetailNews.aspx?id="+NewsID);
        }
    }
}
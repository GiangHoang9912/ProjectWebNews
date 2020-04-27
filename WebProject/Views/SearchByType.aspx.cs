using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject.Views
{
    public partial class SearchByType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData(1);

                List<Project.Entity.Banner> bannerList = Project.Entity.BannerList.GetAllBanner();

                Random r = new Random();

                int id = r.Next(1, bannerList.Count - 1);

                banner.ImageUrl = @"~\Banner Vertical\" + bannerList[id].AdvertisementImage;


            }
        }

        protected void dlNewsByType_ItemCommand(object source, DataListCommandEventArgs e)
        {
            int id = 0;
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

        public int PageNumber
        {
            get
            {
                if (ViewState["PageNumber"] == null) { return 1; }
                return (Int32)ViewState["PageNumber"];
            }
            set => ViewState["PageNumber"] = value;
        }

        void LoadData(int index)
        {
            try
            {
                int TypeID = 0;

                if (Request.QueryString["TypeID"] != null)
                {
                    TypeID = Convert.ToInt32(Request.QueryString["TypeID"]);
                }

                PageNumber = index;
                int countRow = Convert.ToInt32(Project.Data.NewDAO.getCountRow(TypeID).Rows[0][0]);

                int pageSize = 4;

                int maxPage = countRow / pageSize;

                if (countRow % pageSize != 0)
                {
                    maxPage++;
                }

                if (PageNumber > maxPage) { PageNumber = 1; }
                if (PageNumber < 1) { PageNumber = maxPage; }

                string[] paging = new string[maxPage];

                for (int i = 0; i < maxPage; i++)
                {
                    paging[i] = (i + 1) + "";
                }
                btnPage.DataSource = paging;
                btnPage.DataBind();

                dlNewsByType.DataSource = Project.Entity.NewList.GetNewsByType(TypeID, PageNumber, pageSize);
                dlNewsByType.DataBind();
                Label1.Text = PageNumber + "";

                if (Project.Entity.NewList.GetNewsByType(TypeID,PageNumber,pageSize).Count == 0) { Response.Redirect("ErrorPage.aspx"); }

                dlNews.DataSource = Project.Data.NewDAO.GetRandomTop10Type(TypeID);
                dlNews.DataBind();
            }
            catch (Exception) 
            {
                Response.Redirect("ErrorPage.aspx");
            }
        }

        protected void rpPage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                PageNumber = Convert.ToInt32(e.CommandName);
                LoadData(PageNumber);
            }
            catch (Exception) { }
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
    }
}
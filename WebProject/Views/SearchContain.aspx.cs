using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject.Views
{
    public partial class SearchContain : System.Web.UI.Page
    {
        public string NotFount = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData(1);

            List<Project.Entity.Banner> bannerList = Project.Entity.BannerList.GetAllBanner();

            Random r = new Random();

            int bannerid = r.Next(1, bannerList.Count - 1);

            banner.ImageUrl = @"~\Banner Vertical\" + bannerList[bannerid].AdvertisementImage;
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

            string txtSearch = "";

            if (Request.QueryString["TextSearch"] != null)
            {
                txtSearch = Request.QueryString["TextSearch"].ToString();
            }

            PageNumber = index;
            int countRow = Convert.ToInt32(Project.Data.NewDAO.getCountSearchTitleRow(txtSearch).Rows[0][0]);

            int pageSize = 5;

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

            if (Project.Entity.NewList.GetNewsByTitle(txtSearch, PageNumber, pageSize).Count == 0)
            {
                NotFount = "Not Found";
            }
            else 
            {
                NotFount = "";
            }

            dlNewsByTitleContain.DataSource = Project.Entity.NewList.GetNewsByTitle(txtSearch, PageNumber, pageSize);
            dlNewsByTitleContain.DataBind();
            Label1.Text = PageNumber + "";
        }

        protected void btnPage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                PageNumber = Convert.ToInt32(e.CommandName);
                LoadData(PageNumber);
            }
            catch (Exception) { }
        }

        protected void dlNewsByTitleContain_ItemCommand(object source, DataListCommandEventArgs e)
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
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity
{
    public class News
    {
        public static string imgSource = @"C:\Users\giang\source\repos\Project\Project\Image\";

        public News() { }

        public News(int newID, string newTitle, string typeName, bool status, string imglink, DateTime startDate, string journalist, string rule, string newsDocx)
        {
            NewID = newID;
            NewTitle = newTitle;
            TypeName = typeName;
            Status = status;
            Imglink = imglink;
            StartDate = startDate;
            Journalist = journalist;
            Rule = rule;
            NewsDocx = newsDocx;
        }

        public News(int newID, string newTitle, int typeID, bool status, string imglink, DateTime startDate, string journalist, string rule, string newsDocx)
        {
            NewID = newID;
            NewTitle = newTitle;
            TypeID = typeID;
            Status = status;
            Imglink = imglink;
            StartDate = startDate;
            Journalist = journalist;
            Rule = rule;
            NewsDocx = newsDocx;
        }

        public int NewID { get; set; }
        public string NewTitle { get; set; }
        public string TypeName { get; set; }

        public int TypeID { get; set; }
        public bool Status { get; set; }
        public string Imglink { get; set; }
        public DateTime StartDate { get; set; }
        public string Journalist { get; set; }
        public string Rule { get; set; }
        public string NewsDocx { get; set; }
    }
    public class NewList
    {

        public static List<News> GetAllNews()
        {
            List<News> NewsList = new List<News>();
            DataTable dt = Project.Data.NewDAO.GetAllNews();
            foreach (DataRow dr in dt.Rows)
            {
                int id = Convert.ToInt32(dr["NewsID"]);
                string title = dr["NewsTitle"].ToString();
                string typename = dr["TypeName"].ToString();
                DateTime startdate = Convert.ToDateTime(dr["StartDate"]);
                string userName = dr["UserName"].ToString();
                string rule = dr["RuleName"].ToString();
                string img = dr["NewsImage"].ToString().Trim();
                string NewsDocx = dr["NewsDox"].ToString();
                bool status = Convert.ToBoolean(dr["Status"]);

                News news = new News(id, title, typename, status, img, startdate, userName, rule, NewsDocx);

                NewsList.Add(news);
            }
            return NewsList;
        }

        public static List<News> GetNewsByAccount(int accountID)
        {
            List<News> NewsList = new List<News>();
            DataTable dt = Project.Data.NewDAO.GetNewsByAcount(accountID);
            foreach (DataRow dr in dt.Rows)
            {
                int id = Convert.ToInt32(dr["NewsID"]);
                string title = dr["NewsTitle"].ToString();
                string typename = dr["TypeName"].ToString();
                DateTime startdate = Convert.ToDateTime(dr["StartDate"]);
                string userName = dr["UserName"].ToString();
                string rule = dr["RuleName"].ToString();
                string img = dr["NewsImage"].ToString().Trim();
                string NewsDocx = dr["NewsDox"].ToString();
                bool status = Convert.ToBoolean(dr["Status"]);


                News news = new News(id, title, typename, status, img, startdate, userName, rule, NewsDocx);

                NewsList.Add(news);
            }
            return NewsList;
        }

        public static List<News> GetNewsByTitle(string TextSearch, int pageIndex, int pageSize)
        {
            List<News> NewsList = new List<News>();
            DataTable dt = Project.Data.NewDAO.GetNewsByTitle(TextSearch, pageIndex, pageSize);
            foreach (DataRow dr in dt.Rows)
            {
                int id = Convert.ToInt32(dr["NewsID"]);
                string title = dr["NewsTitle"].ToString();
                string typename = dr["TypeName"].ToString();
                DateTime startdate = Convert.ToDateTime(dr["StartDate"]);
                string userName = dr["UserName"].ToString();
                string rule = dr["RuleName"].ToString();
                string img = dr["NewsImage"].ToString().Trim();
                string NewsDocx = dr["NewsDox"].ToString();
                bool status = Convert.ToBoolean(dr["Status"]);

                News news = new News(id, title, typename, status, img, startdate, userName, rule, NewsDocx);

                NewsList.Add(news);
            }
            return NewsList;
        }

        public static News GetNews(int newsID)
        {
            News news = new News();
            DataTable dt = Project.Data.NewDAO.GetNewsByID(newsID);
            foreach (DataRow dr in dt.Rows)
            {
                int id = Convert.ToInt32(dr["NewsID"]);
                string title = dr["NewsTitle"].ToString();
                string typename = dr["TypeName"].ToString();
                DateTime startdate = Convert.ToDateTime(dr["StartDate"]);
                string userName = dr["UserName"].ToString();
                string rule = dr["RuleName"].ToString();
                string img = dr["NewsImage"].ToString().Trim();
                string NewsDocx = dr["NewsDox"].ToString();
                bool status = Convert.ToBoolean(dr["Status"]);

                if (dr["TypeID"] != null)
                {
                    int TypeID = Convert.ToInt32(dr["TypeID"]);

                    news = new News(id, title, TypeID, status, img, startdate, userName, rule, NewsDocx);
                }
                else
                {
                    news = new News(id, title, typename, status, img, startdate, userName, rule, NewsDocx);
                }
            }
            return news;
        }

        public static List<News> GetTop10News()
        {
            List<News> NewsList = new List<News>();
            DataTable dt = Project.Data.NewDAO.GetTop10News();
            foreach (DataRow dr in dt.Rows)
            {
                int id = Convert.ToInt32(dr["NewsID"]);
                string title = dr["NewsTitle"].ToString();
                string typename = dr["TypeName"].ToString();
                DateTime startdate = Convert.ToDateTime(dr["StartDate"]);
                string userName = dr["UserName"].ToString();
                string rule = dr["RuleName"].ToString();
                string img = dr["NewsImage"].ToString().Trim();
                string NewsDocx = dr["NewsDox"].ToString();
                bool status = Convert.ToBoolean(dr["Status"]);

                News news = new News(id, title, typename, status, img, startdate, userName, rule, NewsDocx);

                NewsList.Add(news);
            }
            return NewsList;
        }
        public static List<News> GetNewsByType(int TypeID, int pageIndex, int pageSize)
        {
            List<News> NewsList = new List<News>();
            DataTable dt = Project.Data.NewDAO.GetNewsByType(TypeID, pageIndex, pageSize);
            foreach (DataRow dr in dt.Rows)
            {
                int id = Convert.ToInt32(dr["NewsID"]);
                string title = dr["NewsTitle"].ToString();
                string typename = dr["TypeName"].ToString();
                DateTime startdate = Convert.ToDateTime(dr["StartDate"]);
                string userName = dr["UserName"].ToString();
                string rule = dr["RuleName"].ToString();
                string img = dr["NewsImage"].ToString().Trim();
                string NewsDocx = dr["NewsDox"].ToString();
                bool status = Convert.ToBoolean(dr["Status"]);

                News news = new News(id, title, typename, status, img, startdate, userName, rule, NewsDocx);

                NewsList.Add(news);
            }
            return NewsList;
        }

        public static News GetTop1News()
        {
            News News = new News();
            DataTable dt = Project.Data.NewDAO.GetTop1News();
            foreach (DataRow dr in dt.Rows)
            {
                int id = Convert.ToInt32(dr["NewsID"]);
                string title = dr["NewsTitle"].ToString();
                string typename = dr["TypeName"].ToString();
                DateTime startdate = Convert.ToDateTime(dr["StartDate"]);
                string userName = dr["UserName"].ToString();
                string rule = dr["RuleName"].ToString();
                string img = dr["NewsImage"].ToString().Trim();
                string NewsDocx = dr["NewsDox"].ToString();
                bool status = Convert.ToBoolean(dr["Status"]);

                News = new News(id, title, typename, status, img, startdate, userName, rule, NewsDocx);

            }
            return News;
        }


        public static News GetRandomTop3(int NewsID)
        {
            News News = new News();
            DataTable dt = Project.Data.NewDAO.GetRandomTop3(NewsID);
            foreach (DataRow dr in dt.Rows)
            {
                int id = Convert.ToInt32(dr["NewsID"]);
                string title = dr["NewsTitle"].ToString();
                string typename = dr["TypeName"].ToString();
                DateTime startdate = Convert.ToDateTime(dr["StartDate"]);
                string userName = dr["UserName"].ToString();
                string rule = dr["RuleName"].ToString();
                string img = dr["NewsImage"].ToString().Trim();
                string NewsDocx = dr["NewsDox"].ToString();
                bool status = Convert.ToBoolean(dr["Status"]);

                News = new News(id, title, typename, status, img, startdate, userName, rule, NewsDocx);

            }
            return News;
        }

    }
}

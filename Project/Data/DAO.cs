using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Project.Entity;
using System.Configuration;

namespace Project.Data
{
    #region DAO
    public class DAO
    {
        public static SqlConnection GetConnection()
        {
            string ConnectString = ConfigurationManager.ConnectionStrings["ProjectCStr"].ToString();
            SqlConnection Connection = new SqlConnection(ConnectString);
            return Connection;
        }

        public static DataTable GetDataBySQL(string sql)
        {
            SqlCommand Command = new SqlCommand(sql, GetConnection());
            DataTable dt = new DataTable();
            Command.Connection.Open();

            SqlDataReader Reader = Command.ExecuteReader();

            dt.Load(Reader);
            Command.Connection.Close();
            return dt;
        }

        public static DataTable GetDataBySQLWithParameters(string sql, params SqlParameter[] parameters)
        {
            SqlCommand Command = new SqlCommand(sql, GetConnection());
            DataTable dt = new DataTable();
            Command.Parameters.AddRange(parameters);
            Command.Connection.Open();

            SqlDataReader Reader = Command.ExecuteReader();

            dt.Load(Reader);
            Command.Connection.Close();
            return dt;
        }

        public static int ExecuteSQL(string sql)
        {
            SqlCommand Command = new SqlCommand(sql, GetConnection());
            Command.Connection.Open();
            int k = Command.ExecuteNonQuery();
            Command.Connection.Close();
            return k;
        }

        public static int ExecuteSQLWithParameters(string sql, params SqlParameter[] parameters)
        {
            SqlCommand Command = new SqlCommand(sql, GetConnection());
            Command.Connection.Open();
            Command.Parameters.AddRange(parameters);
            int k = Command.ExecuteNonQuery();
            Command.Connection.Close();
            return k;
        }
    }

    #endregion DAO

    #region AccountDAO
    public class AccountDAO
    {
        //get all account from database
        public static DataTable GetAllAccount()
        {
            string sql = @"select * from Account";

            return DAO.GetDataBySQL(sql);
        }

        //Delete News from User Save News
        public static int DeleteUserSave(int accID, int NewsID)
        {
            string sql = @" DELETE FROM [UserSaveNews] 
                            WHERE AccountID = @accID and NewsID = @NewsID ";

            SqlParameter param1 = new SqlParameter("@accID", SqlDbType.Int);
            param1.Value = accID;
            SqlParameter param2 = new SqlParameter("@NewsID", SqlDbType.Int);
            param2.Value = NewsID;

            return DAO.ExecuteSQLWithParameters(sql, param1, param2);
        }

        //Get account By account ID
        public static DataTable GetAccountByID(int accID)
        {
            string sql = @"select * from Account where AccountID = @accID";

            SqlParameter param1 = new SqlParameter("@accID", SqlDbType.Int);
            param1.Value = accID;

            return DAO.GetDataBySQLWithParameters(sql, param1);
        }
        //get top 1 user ID to add Account
        public static DataTable GetUserID()
        {
            string sql = @"select top 1 UserID from Users order by UserID desc";

            return DAO.GetDataBySQL(sql);
        }


        //Add Account to data base
        public static int AddAccount(Account a)
        {
            string sql = @"INSERT INTO [dbo].[Account]
                           ([AccountName]
                           ,[Passwords]
                           ,[RuleID]
                           ,[UserID])
                     VALUES
                           (@accountname
                           ,@pass
                           ,@rule
                           ,@userid)";

            SqlParameter param1 = new SqlParameter("@accountname", SqlDbType.NVarChar);
            param1.Value = a.UserName;
            SqlParameter param2 = new SqlParameter("@pass", SqlDbType.NVarChar);
            param2.Value = a.Pass;
            SqlParameter param3 = new SqlParameter("@rule", SqlDbType.Int);
            param3.Value = a.Rule;
            SqlParameter param4 = new SqlParameter("@userid", SqlDbType.Int);
            param4.Value = a.UserID;

            return DAO.ExecuteSQLWithParameters(sql, param1, param2, param3, param4);
        }

        //Update Account (change password)
        public static int updateAccount(int accountID, string newpass)
        {
            string sql = @"UPDATE [Account]
                         SET [Passwords] = @Pass
                         WHERE AccountID = @accountID";

            SqlParameter param1 = new SqlParameter("@Pass", SqlDbType.NVarChar);
            param1.Value = newpass;

            SqlParameter param2 = new SqlParameter("@accountID", SqlDbType.Int);
            param2.Value = accountID;

            return DAO.ExecuteSQLWithParameters(sql, param1, param2);
        }

        //Save news to account 
        public static int SaveNews(int accountID, int NewsID)
        {
            string sql = @"INSERT INTO [UserSaveNews] 
                           ([AccountID] 
                           ,[NewsID]) 
                     VALUES 
                           (@accountID 
                           ,@NewsID) ";

            SqlParameter param1 = new SqlParameter("@accountID", SqlDbType.Int);
            param1.Value = accountID;

            SqlParameter param2 = new SqlParameter("@NewsID", SqlDbType.Int);
            param2.Value = NewsID;

            return DAO.ExecuteSQLWithParameters(sql, param1, param2);
        }
    }

    #endregion AccountDAO

    #region UserInfoDAO
    public class UserInfoDAO
    {
        //get all user in database
        public static DataTable GetAllUser()
        {
            string sql = @" select Users.UserID,Users.UserName, "
                        + " Users.DOB, Users.Email,Users.Phone, "
                        + " Rules.RuleName "
                        + " from Users,Account,Rules "
                        + " where Users.UserID = Account.UserID "
                        + " and Account.RuleID = Rules.RuleID order by UserID asc ";

            return DAO.GetDataBySQL(sql);
        }
        //get user by id
        public static DataTable GetUserByID(int UserID)
        {
            string sql = @"select Users.*,Rules.RuleName from Users,Account,Rules where Users.UserID = Account.UserID and Account.RuleID = Rules.RuleID
                         and Users.UserID = @UserID";

            SqlParameter param1 = new SqlParameter("@UserID", SqlDbType.Int);
            param1.Value = UserID;

            return DAO.GetDataBySQLWithParameters(sql, param1);
        }
        //add user in to database
        public static int AddUsers(string username, DateTime dob, string email, string phone, string avatar)
        {
            string sql = @"INSERT INTO [Users]
                           ([UserName]
                           ,[DOB]
                           ,[Email]
                           ,[Phone]
                           ,[Avatar])
                     VALUES
                           (@username
                           ,@dob
                           ,@email
                           ,@phone
                           ,@Avatar )";

            SqlParameter param1 = new SqlParameter("@username", SqlDbType.NVarChar);
            param1.Value = username;
            SqlParameter param2 = new SqlParameter("@dob", SqlDbType.DateTime);
            param2.Value = dob;
            SqlParameter param3 = new SqlParameter("@email", SqlDbType.NVarChar);
            param3.Value = email;
            SqlParameter param4 = new SqlParameter("@phone", SqlDbType.NVarChar);
            param4.Value = phone;
            SqlParameter param5 = new SqlParameter("@Avatar", SqlDbType.NVarChar);
            param5.Value = avatar;

            return DAO.ExecuteSQLWithParameters(sql, param1, param2, param3, param4, param5);
        }

        // update user
        public static int UpdateUser(string username, DateTime dob, string email, string phone, string avatar, int userID)
        {
            string sql = @"UPDATE [Users] 
                           SET [UserName] = @UserName 
                              ,[DOB] = @DOB 
                              ,[Email] = @Email 
                              ,[Phone] = @Phone 
                              ,[Avatar] = @avatar
                              WHERE UserID = @UserID ";

            SqlParameter param1 = new SqlParameter("@UserName", SqlDbType.NVarChar);
            param1.Value = username;
            SqlParameter param2 = new SqlParameter("@DOB", SqlDbType.DateTime);
            param2.Value = dob;
            SqlParameter param3 = new SqlParameter("@Email", SqlDbType.NVarChar);
            param3.Value = email;
            SqlParameter param4 = new SqlParameter("@Phone", SqlDbType.NVarChar);
            param4.Value = phone;
            SqlParameter param5 = new SqlParameter("@avatar", SqlDbType.NVarChar);
            param5.Value = avatar;
            SqlParameter param6 = new SqlParameter("@UserID", SqlDbType.NVarChar);
            param6.Value = userID;

            return DAO.ExecuteSQLWithParameters(sql, param1, param2, param3, param4, param5, param6);
        }

        public static int DeleteUser(int UserID)
        {
            string sql = @"DELETE FROM [Users] WHERE UserID = @UserID ";

            SqlParameter param1 = new SqlParameter("@UserID", SqlDbType.Int);
            param1.Value = UserID;

            return DAO.ExecuteSQLWithParameters(sql, param1);
        }

    }

    #endregion UserInfoDAO

    #region NewsDAO
    public class NewDAO
    {

        //get all news in database
        public static DataTable GetAllNews()
        {
            string sql = @" select News.NewsID, News.NewsTitle,NewsType.TypeName, News.[Status], "
                        + " News.StartDate,Users.UserName,Rules.RuleName,News.NewsImage,News.NewsDox "
                        + " from News,Account,Users,NewsType,Rules "
                        + " where News.AccountID = Account.AccountID "
                        + " and Account.UserID = Users.UserID "
                        + " and NewsType.TypeID = News.TypeID "
                        + " and Account.RuleID = Rules.RuleID "
                        + " order by NewsID asc ";

            return DAO.GetDataBySQL(sql);
        }


        //get News by account id saving
        public static DataTable GetNewsUserSave(int accID)
        {
            string sql = @" select * from UserSaveNews,Account,News  
                            where Account.AccountID = UserSaveNews.AccountID  
                            and News.NewsID = UserSaveNews.NewsID and Account.AccountID = @accountID";

            SqlParameter param1 = new SqlParameter("@accountID", SqlDbType.Int);
            param1.Value = accID;

            return DAO.GetDataBySQLWithParameters(sql, param1);
        }


        //get news just insert to up status

        public static DataTable GetNewsInsert()
        {
            string sql = @" select top 1 NewsID from News order by NewsID desc ";

            return DAO.GetDataBySQL(sql);
        }

        //update status become true to add news
        public static int UpdateStatusNews(int NewsID)
        {
            string sql = @" UPDATE [News]
                               SET [Status] = 1 
                             WHERE NewsID = @NewsID ";

            SqlParameter param1 = new SqlParameter("@NewsID", SqlDbType.Int);
            param1.Value = NewsID;

            return DAO.ExecuteSQLWithParameters(sql, param1);
        }

        // get more News for home page must diffrent top 1 in content and top 10 and right content
        public static DataTable GetLittleNewsHome()
        {
            string sql = @"select top 12 News.NewsID, News.NewsTitle,NewsType.TypeName, News.[Status],  
                            News.StartDate,Users.UserName,Rules.RuleName,News.NewsImage,News.NewsDox   
                            from News,Account,Users,NewsType,Rules  
                            where News.AccountID = Account.AccountID  
                            and Account.UserID = Users.UserID  
                            and NewsType.TypeID = News.TypeID  
                            and Account.RuleID = Rules.RuleID  
                            and News.[Status] = 1  
                            and News.StartDate not in(select top 11   
                            News.StartDate 
                            from News,Account,Users,NewsType,Rules  
                            where News.AccountID = Account.AccountID  
                            and Account.UserID = Users.UserID  
                            and NewsType.TypeID = News.TypeID  
                            and Account.RuleID = Rules.RuleID 
                            order by News.StartDate desc)
                            order by News.StartDate desc ";

            return DAO.GetDataBySQL(sql);
        }

        //get random 3 news
        public static DataTable GetRandomTop3(int NewsID)
        {
            string sql = @" SELECT TOP 3 * 
                         FROM News where News.[Status] = 1 and News.NewsID != @NewsID 
                         ORDER BY CHECKSUM(NEWID()) ";

            SqlParameter param1 = new SqlParameter("@NewsID", SqlDbType.Int);
            param1.Value = NewsID;

            return DAO.GetDataBySQLWithParameters(sql, param1);
        }

        //get news by account juarnalist 
        public static DataTable GetNewsByAcount(int AccountID)
        {
            string sql = @" select NewsID,NewsTitle,TypeName, News.[Status] ,StartDate, Users.UserName,Rules.RuleName ,NewsImage,News.NewsDox  
                            from News,NewsType,Account,Users,Rules 
                            where News.TypeID = NewsType.TypeID 
                            and Account.RuleID = Rules.RuleID  
                            and Account.UserID = Users.UserID  
                            and News.AccountID = Account.AccountID 
                            and News.[Status] = 1 
                            and Account.AccountID = @accountID  ";

            SqlParameter param1 = new SqlParameter("@accountID", SqlDbType.Int);
            param1.Value = AccountID;

            return DAO.GetDataBySQLWithParameters(sql, param1);
        }

        //get random 10 news

        public static DataTable GetRandomTop10Type(int TypeID)
        {
            string sql = @" SELECT TOP 10 * 
                             FROM News where News.[Status] = 1 and News.TypeID != @TypeID 
                             ORDER BY CHECKSUM(NEWID()) ";

            SqlParameter param1 = new SqlParameter("@TypeID", SqlDbType.Int);
            param1.Value = TypeID;

            return DAO.GetDataBySQLWithParameters(sql, param1);
        }

        //get news by title content and paing

        public static DataTable GetNewsByTitle(string TextSearch, int pageIndex, int pageSize)
        {
            string sql = @"select * from (select ROW_NUMBER() over (order by News.NewsID ASC) as rn,
                            News.NewsID, News.NewsTitle,NewsType.TypeName,  News.[Status] , 
                            News.StartDate,Users.UserName,Rules.RuleName,News.NewsImage,News.NewsDox  
                            from News,Account,Users,NewsType,Rules  
                            where News.AccountID = Account.AccountID  
                            and Account.UserID = Users.UserID  
                            and NewsType.TypeID = News.TypeID  
                            and Account.RuleID = Rules.RuleID
                            and News.[Status] = 1 
                            and News.NewsTitle like '%" + TextSearch + "%') as x where rn between @pageIndex*@pageSize-(@pageSize-1) and @pageIndex*@pageSize ";

            SqlParameter param1 = new SqlParameter("@pageIndex", SqlDbType.Int);
            param1.Value = pageIndex;
            SqlParameter param2 = new SqlParameter("@pageSize", SqlDbType.Int);
            param2.Value = pageSize;

            return DAO.GetDataBySQLWithParameters(sql, param1, param2);
        }

        //get top 1 news write to homePage
        public static DataTable GetTop1News()
        {
            string sql = @"select top 1 News.NewsID, News.NewsTitle,NewsType.TypeName, News.[Status], 
                            News.StartDate,Users.UserName,Rules.RuleName,News.NewsImage,News.NewsDox  
                            from News,Account,Users,NewsType,Rules 
                            where News.AccountID = Account.AccountID 
                            and Account.UserID = Users.UserID 
                            and NewsType.TypeID = News.TypeID 
                            and Account.RuleID = Rules.RuleID
                            and News.[Status] = 1 
                            order by News.StartDate desc";

            return DAO.GetDataBySQL(sql);
        }

        //get news by type

        public static DataTable GetNewsByType(int TypeID, int pageIndex, int pageSize)
        {
            string sql = @"select * from (select ROW_NUMBER() over (order by News.NewsID ASC) as rn,
                            News.NewsID, News.NewsTitle,NewsType.TypeName,  News.[Status] , 
                            News.StartDate,Users.UserName,Rules.RuleName,News.NewsImage,News.NewsDox  
                            from News,Account,Users,NewsType,Rules  
                            where News.AccountID = Account.AccountID  
                            and Account.UserID = Users.UserID  
                            and NewsType.TypeID = News.TypeID  
                            and Account.RuleID = Rules.RuleID  
                            and News.[Status] = 1 
                            and NewsType.TypeID = @TypeID) as x where rn between @pageIndex*@pageSize-(@pageSize-1) and @pageIndex*@pageSize ";

            SqlParameter param1 = new SqlParameter("@TypeID", SqlDbType.Int);
            param1.Value = TypeID;
            SqlParameter param2 = new SqlParameter("@pageIndex", SqlDbType.Int);
            param2.Value = pageIndex;
            SqlParameter param3 = new SqlParameter("@pageSize", SqlDbType.Int);
            param3.Value = pageSize;

            return DAO.GetDataBySQLWithParameters(sql, param1, param2, param3);
        }

        //get top 10 News to home page
        public static DataTable GetTop10News()
        {
            string sql = @" select top 10 News.NewsID, News.NewsTitle,NewsType.TypeName, News.[Status], 
                            News.StartDate,Users.UserName,Rules.RuleName,News.NewsImage,News.NewsDox  
                            from News,Account,Users,NewsType,Rules 
                            where News.AccountID = Account.AccountID 
                            and Account.UserID = Users.UserID 
                            and NewsType.TypeID = News.TypeID 
                            and Account.RuleID = Rules.RuleID
                            and News.[Status] = 1 
                            and News.StartDate not in(
                            select max(News.StartDate) from News,Account,Users,NewsType,Rules 
                            where News.AccountID = Account.AccountID 
                            and Account.UserID = Users.UserID 
                            and NewsType.TypeID = News.TypeID 
                            and Account.RuleID = Rules.RuleID)
                            order by News.StartDate desc ";

            return DAO.GetDataBySQL(sql);
        }

        public static DataTable GetNewsByID(int newsID)
        {
            string sql = @" select News.NewsID, News.NewsTitle,NewsType.TypeID,NewsType.TypeName, News.[Status], "
                        + " News.StartDate,Users.UserName,Rules.RuleName,News.NewsImage,News.NewsDox  "
                        + " from News,Account,Users,NewsType,Rules "
                        + " where News.AccountID = Account.AccountID "
                        + " and Account.UserID = Users.UserID "
                        + " and NewsType.TypeID = News.TypeID "
                        + " and News.[Status] = 1 "
                        + " and Account.RuleID = Rules.RuleID and News.NewsID = @newsID ";

            SqlParameter param1 = new SqlParameter("@newsID", SqlDbType.Int);
            param1.Value = newsID;


            return DAO.GetDataBySQLWithParameters(sql, param1);
        }

        public static int DeleteNews(int id)
        {
            string sql = " DELETE FROM News "
                         + " WHERE NewsID = " + id;

            return DAO.ExecuteSQL(sql);
        }
        public static DataTable getCountRow(int TypeID)
        {
            String query = "Select count(News.NewsID) from News where News.[Status] = 1 and News.TypeID = @TypeID";

            SqlParameter param1 = new SqlParameter("@TypeID", SqlDbType.Int);
            param1.Value = TypeID;

            return DAO.GetDataBySQLWithParameters(query, param1);
        }

        public static DataTable getCountSearchTitleRow(string TextSearch)
        {
            String query = " select count(News.NewsID) "
                            + " from News, Account, Users, NewsType, Rules "
                            + " where News.AccountID = Account.AccountID "
                            + " and Account.UserID = Users.UserID "
                            + " and NewsType.TypeID = News.TypeID "
                            + " and Account.RuleID = Rules.RuleID "
                            + " and News.[Status] = 1 "
                            + " and News.NewsTitle like '%" + TextSearch + "%' ";

            return DAO.GetDataBySQL(query);
        }


        public static int InsertNews(int NewsID, string title, int typeID, string img, DateTime startdate, int accountID, string docx)
        {
            string sql = " INSERT INTO [News]"
                           + " ([NewsID]  "
                           + " ,[NewsTitle] "
                           + " ,[TypeID] "
                           + " ,[Status] "
                           + " ,[NewsImage] "
                           + " ,[StartDate] "
                           + " ,[AccountID] "
                           + " ,[NewsDox]) "
                     + " VALUES "
                           + " ( @newsID "
                           + " , @title "
                           + " , @typeID "
                           + " , 'false' "
                           + " , @imgNews "
                           + " , @startdate "
                           + " , @accountID "
                           + " , @newdocx) ";

            SqlParameter param7 = new SqlParameter("@newsID", SqlDbType.NVarChar);
            param7.Value = NewsID;
            SqlParameter param1 = new SqlParameter("@title", SqlDbType.NVarChar);
            param1.Value = title;
            SqlParameter param2 = new SqlParameter("@typeID", SqlDbType.NVarChar);
            param2.Value = typeID;
            SqlParameter param3 = new SqlParameter("@imgNews", SqlDbType.NVarChar);
            param3.Value = img;
            SqlParameter param4 = new SqlParameter("@startdate", SqlDbType.DateTime);
            param4.Value = startdate;
            SqlParameter param5 = new SqlParameter("@accountID", SqlDbType.Int);
            param5.Value = accountID;
            SqlParameter param6 = new SqlParameter("@newdocx", SqlDbType.NVarChar);
            param6.Value = docx;


            return DAO.ExecuteSQLWithParameters(sql, param7, param1, param2, param3, param4, param5, param6);
        }



        public static int UpdateNews(string title, int typeID, string img, string docx, int NewsID)
        {
            string sql = "UPDATE [News] "
                           + "SET[NewsTitle] = @title "
                            + "  ,[TypeID] = @typeID "
                            + " ,[NewsImage] = @NewsImg "
                            + " ,[NewsDox] = @NewsDocx "
                        + "WHERE News.NewsID = @NewsID ";

            SqlParameter param1 = new SqlParameter("@title", SqlDbType.NVarChar);
            param1.Value = title;
            SqlParameter param2 = new SqlParameter("@typeID", SqlDbType.Int);
            param2.Value = typeID;
            SqlParameter param3 = new SqlParameter("@NewsImg", SqlDbType.NVarChar);
            param3.Value = img;
            SqlParameter param4 = new SqlParameter("@NewsDocx", SqlDbType.NVarChar);
            param4.Value = docx;
            SqlParameter param5 = new SqlParameter("@NewsID", SqlDbType.Int);
            param5.Value = NewsID;


            return DAO.ExecuteSQLWithParameters(sql, param1, param2, param3, param4, param5);
        }

        public static DataTable getJournalistAccount()
        {
            string sql = " select AccountID,Users.UserName from Account,Users where Account.UserID = Users.UserID and RuleID = 3 ";

            return DAO.GetDataBySQL(sql);
        }

        public static DataTable getJournalistCountNewsWithMonth(int accID, DateTime from)
        {
            string sql = " select AccountID,(select count(News.NewsID) as count_number " +
                " from Users, Account, News " +
                " where Users.UserID = Account.UserID " +
                " and Account.AccountID = News.AccountID " +
                " and Account.AccountID = @accID ";

            sql = sql + " and News.StartDate between @from and @to ";
            sql = sql + " ) as newsCount " +
            " from Account where RuleID = 3 " +
            " and AccountID = @accID ";
            SqlParameter param2 = new SqlParameter("@from", SqlDbType.DateTime);
            param2.Value = from;

            DateTime to = new DateTime(from.Year, from.Month + 1, from.Day);

            SqlParameter param3 = new SqlParameter("@to", SqlDbType.DateTime);
            param3.Value = to;
            SqlParameter param1 = new SqlParameter("@accID", SqlDbType.Int);
            param1.Value = accID;
            return DAO.GetDataBySQLWithParameters(sql, param1, param2, param3);
        }
        public static DataTable getJournalistCountNews(int accID)
        {
            string sql = " select AccountID,(select count(News.NewsID) as count_number " +
                " from Users, Account, News " +
                " where Users.UserID = Account.UserID " +
                " and Account.AccountID = News.AccountID " +
                " and Account.AccountID = @accID " +
                " ) as newsCount " +
                " from Account where RuleID = 3 " +
                " and AccountID = @accID ";
            SqlParameter param1 = new SqlParameter("@accID", SqlDbType.Int);
            param1.Value = accID;
            return DAO.GetDataBySQLWithParameters(sql, param1);
        }

    }

    #endregion NewsDAO

    #region TypeNewsDAO
    public class TypeNewsDAO
    {
        public static DataTable GetAllType()
        {
            string sql = @"select * from NewsType";

            return DAO.GetDataBySQL(sql);
        }
    }

    #endregion TypeNewsDAO

    #region BannerDAO
    public class BannerDAO
    {
        public static DataTable GetAllBanner()
        {
            string sql = @"select * from advertisement";

            return DAO.GetDataBySQL(sql);
        }
    }
    #endregion BannerDAO

    #region CommentDAO
    public class CommentDAO
    {
        public static DataTable GetCommentByNewsID(int NewsID)
        {
            string sql = @"select CommentID,Account.AccountID, UserName,CommentContent from CommentNews,Account,Users  
                            where CommentNews.AccountID = Account.AccountID  
                            and Account.UserID = Users.UserID and CommentNews.NewsID = @NewsID ";

            SqlParameter param1 = new SqlParameter("@NewsID", SqlDbType.Int);
            param1.Value = NewsID;

            return DAO.GetDataBySQLWithParameters(sql, param1);
        }

        public static int deleteComment(int CmtID)
        {
            string sql = "DELETE FROM [CommentNews] WHERE CommentID = @cmtID ";

            SqlParameter param1 = new SqlParameter("@cmtID", SqlDbType.Int);
            param1.Value = CmtID;

            return DAO.ExecuteSQLWithParameters(sql, param1);
        }

        public static int InsertComment(int newsID, int accID, string content)
        {
            string sql = " INSERT INTO [CommentNews]" +
                " ([NewsID] " +
                " ,[AccountID] " +
                " ,[CommentContent]) " +
                " VALUES " +
                " (@NewsID " +
                " , @accID " +
                " , @cmtContent) ";

            SqlParameter param1 = new SqlParameter("@NewsID", SqlDbType.Int);
            param1.Value = newsID;
            SqlParameter param2 = new SqlParameter("@accID", SqlDbType.Int);
            param2.Value = accID;
            SqlParameter param3 = new SqlParameter("@cmtContent", SqlDbType.NVarChar);
            param3.Value = content;

            return DAO.ExecuteSQLWithParameters(sql, param1, param2, param3);
        }
    }
    #endregion CommentDAO

    #region ContactDAO
    public class ContactDAO
    {
        public static DataTable GetAllContact()
        {
            string sql = @" select top 1 * from Contact order by ContactID desc ";

            return DAO.GetDataBySQL(sql);
        }
    }
    #endregion ContactDAO

}

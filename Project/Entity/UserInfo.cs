using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity
{
    public class UserInfo
    {
        int userID;
        string userName;
        DateTime dob;
        string email;
        string phone;
        string ruleName;
        string avatarImg;

        public UserInfo() { }
        public UserInfo(int userID, string userName, DateTime dob, string email, string phone, string ruleName)
        {
            this.userID = userID;
            this.userName = userName;
            this.dob = dob;
            this.email = email;
            this.phone = phone;
            this.ruleName = ruleName;
        }

        public UserInfo(int userID, string userName, DateTime dob, string email, string phone, string ruleName, string avatarImg) : this(userID, userName, dob, email, phone, ruleName)
        {
            this.avatarImg = avatarImg;
        }

        public int UserID { get => userID; set => userID = value; }
        public string UserName { get => userName; set => userName = value; }
        public DateTime Dob { get => dob; set => dob = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string RuleName { get => ruleName; set => ruleName = value; }
        public string AvatarImg { get => avatarImg; set => avatarImg = value; }

        public static int InsertUserIntoDB(string username, DateTime dob, string email, string phone,string avatar)
        {
            return Project.Data.UserInfoDAO.AddUsers(username, dob, email, phone,avatar);
        }

        public static int UpdateUserIntoDB(string username, DateTime dob, string email, string phone,string avatar, int UserID)
        {
            return Project.Data.UserInfoDAO.UpdateUser(username, dob, email, phone, avatar, UserID);
        }
    }

    public class UserInfoList
    {
        public static List<UserInfo> GetAllUser()
        {
            List<UserInfo> userInfoList = new List<UserInfo>();
            DataTable dt = Project.Data.UserInfoDAO.GetAllUser();
            foreach (DataRow dr in dt.Rows)
            {
                UserInfo user = new UserInfo(
                        Convert.ToInt32(dr["UserID"]),
                        dr["UserName"].ToString(),
                        Convert.ToDateTime(dr["DOB"]),
                        dr["Email"].ToString(),
                        dr["Phone"].ToString(),
                        dr["RuleName"].ToString()
                    );
                userInfoList.Add(user);
            }
            return userInfoList;
        }
        public static UserInfo GetUserByID(int UserID)
        {
            UserInfo user = new UserInfo();
            DataTable dt = Project.Data.UserInfoDAO.GetUserByID(UserID);
            foreach (DataRow dr in dt.Rows)
            {
                user = new UserInfo(
                        Convert.ToInt32(dr["UserID"]),
                        dr["UserName"].ToString(),
                        Convert.ToDateTime(dr["DOB"]),
                        dr["Email"].ToString(),
                        dr["Phone"].ToString(),
                        dr["RuleName"].ToString(),
                        dr["Avatar"].ToString()
                    );
            }
            return user;
        }
    }
}

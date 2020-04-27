using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity
{
    public class Account
    {
        int accountid;
        string userName;
        string pass;
        int rule;
        int userID;

        public Account()
        {
        }

        public Account(string userName, string pass, int rule, int userID)
        {
            this.UserName = userName;
            this.Pass = pass;
            this.Rule = rule;
            this.UserID = userID;
        }

        public Account(int accountid, string userName, string pass, int rule, int userID)
        {
            this.accountid = accountid;
            this.userName = userName;
            this.pass = pass;
            this.rule = rule;
            this.userID = userID;
        }

        public string UserName { get => userName; set => userName = value; }
        public string Pass { get => pass; set => pass = value; }
        public int Rule { get => rule; set => rule = value; }
        public int UserID { get => userID; set => userID = value; }
        public int Accountid { get => accountid; set => accountid = value; }

        public int InsertAccount() 
        {
            return Project.Data.AccountDAO.AddAccount(this);
        }
    }
    public class AccountList
    {
        public static List<Account> GetAllAccount()
        {
            List<Account> AccList = new List<Account>();
            DataTable dt = Project.Data.AccountDAO.GetAllAccount();
            foreach (DataRow dr in dt.Rows)
            {
                Account acc = new Account(
                        Convert.ToInt32(dr["AccountID"]),
                        dr["AccountName"].ToString(),
                        dr["Passwords"].ToString(),
                        Convert.ToInt32(dr["RuleID"]),
                        Convert.ToInt32(dr["UserID"])
                    );
                AccList.Add(acc);
            }
            return AccList;
        }

        public static Account GetAccountByID(int accID)
        {
            Account acc = new Account();
            DataTable dt = Project.Data.AccountDAO.GetAccountByID(accID);
            foreach (DataRow dr in dt.Rows)
            {
                        acc = new Account(
                        Convert.ToInt32(dr["AccountID"]),
                        dr["AccountName"].ToString(),
                        dr["Passwords"].ToString(),
                        Convert.ToInt32(dr["RuleID"]),
                        Convert.ToInt32(dr["UserID"])
                    );
            }
            return acc;
        }
    }
}

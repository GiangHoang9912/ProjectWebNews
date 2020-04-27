using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject.Views
{
    public partial class Header : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int UserID = 1;
            if (Session["UserID"] != null)
            {
                UserID = Convert.ToInt32(Session["UserID"]);
                Project.Entity.UserInfo user = Project.Entity.UserInfoList.GetUserByID(UserID);

                User.Text = user.UserName;
                Register.Text = "Logout";
            }
            else
            {
                User.Text = "Login";
                Register.Text = "Register";
            }
            List<Project.Entity.NewsTypes> ListTypes = Project.Entity.TypeList.GetAllType();

            rpType.DataSource = ListTypes;
            rpType.DataBind();


        }

        protected void Register_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                Session.RemoveAll();
                Response.Redirect("Home.aspx");
            }
            else 
            {
                Response.Redirect("Register.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            bool isLogin = false;
            List<Project.Entity.Account> ListAcc = Project.Entity.AccountList.GetAllAccount();

            foreach (Project.Entity.Account acc in ListAcc)
            {
                if (acc.UserName.Equals(UserName.Text) && acc.Pass.Equals(Password.Text))
                {
                    isLogin = true;
                    Session["accountID"] = acc.Accountid;
                    Session["UserID"] = acc.UserID;
                    Session["UserName"] = acc.UserName;
                    Session["Pass"] = acc.Pass;
                    Session["rule"] = acc.Rule;
                    Response.Redirect("Home.aspx");
                }
            }

            if (!isLogin)
            {
                String csname1 = "PopupScript";
                Type cstype = this.GetType();
                ClientScriptManager cs = Page.ClientScript;
                if (!cs.IsStartupScriptRegistered(cstype, csname1))
                {
                    String cstext1 = "alert('UserName or Password wrong. Please try it again !!!');";
                    cs.RegisterStartupScript(cstype, csname1, cstext1, true);
                }
            }
        }

        protected void User_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] != null && Convert.ToInt32(Session["rule"].ToString()) == 1) 
            {
                Response.Redirect("DowloadFileDocx.aspx");
            }
            else if (Session["UserID"] != null && Convert.ToInt32(Session["rule"].ToString()) == 2)
            {
                Response.Redirect("DetailUser.aspx");
            }
            else if(Session["UserID"] != null && Convert.ToInt32(Session["rule"].ToString()) == 3)
            {
                //DetailJournalist.aspx
                Response.Redirect("DetailUser.aspx");
            }
        }

        protected void rpType_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int typeID = Convert.ToInt32(e.CommandName);
            Response.Redirect("SearchByType.aspx?TypeID=" + typeID);
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("SearchContain.aspx?TextSearch=" + TextSearch.Text);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contact.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}
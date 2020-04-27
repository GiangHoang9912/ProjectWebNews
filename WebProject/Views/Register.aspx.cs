using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject.Views
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Upload_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && FileUpload1.HasFile)
            {

                lblFile.Text = FileUpload1.FileName;
                avatar.ImageUrl = @"~\AvatarUser\" + FileUpload1.FileName;
            }

        }

        bool isAdd;

        void getError()
        {
            string error = "";

            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match1 = emailRegex.Match(Email.Text);
            if (!match1.Success)
            {
                error += " Email is incorrect.";
            }

            Regex phoneRegex = new Regex(@"^[0]\d{9,10}");
            Match match2 = phoneRegex.Match(Phone.Text);
            if (!match2.Success)
            {
                error += " Phone is incorrect.";
            }

            foreach (Project.Entity.Account acc in Project.Entity.AccountList.GetAllAccount()) 
            {
                if (Account.Text.Equals(acc.UserName)) 
                {
                    error += "Account Name is exits.";
                    break;
                }
            }

            if (!Password.Text.Equals(Confirm.Text)) 
            {
                error += "Confirm password was wrong !!";
            }

            if (error.Length != 0)
            {
                String csname1 = "PopupScript";
                Type cstype = this.GetType();
                ClientScriptManager cs = Page.ClientScript;

                if (!cs.IsStartupScriptRegistered(cstype, csname1))
                {
                    String cstext1 = "alert('" + error + "');";
                    cs.RegisterStartupScript(cstype, csname1, cstext1, true);
                    isAdd = false;
                }
            }
            else 
            {
                isAdd = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            getError();

            if (isAdd) 
            {
                Project.Data.UserInfoDAO.AddUsers(FullName.Text, Convert.ToDateTime(DateOfBirth.Text), Email.Text, Phone.Text,lblFile.Text);

                string id = Project.Data.AccountDAO.GetUserID().Rows[0][0].ToString();

                Project.Entity.Account account = new Project.Entity.Account(Account.Text, Password.Text, 2, Convert.ToInt32(id));

                account.InsertAccount();

                String csname1 = "PopupScript";
                Type cstype = this.GetType();
                ClientScriptManager cs = Page.ClientScript;

                if (!cs.IsStartupScriptRegistered(cstype, csname1))
                {
                    String cstext1 = "alert('Register succesful.You can login now');";
                    cs.RegisterStartupScript(cstype, csname1, cstext1, true);
                    Response.Redirect("Home.aspx");
                }
            }
        }
    }
}
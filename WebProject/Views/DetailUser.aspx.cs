using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject.Views
{
    public partial class DetailUser : System.Web.UI.Page
    {
        bool Save = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnSave.Text = "Edit";

                int UserID = Convert.ToInt32(Session["UserID"].ToString());

                Project.Entity.UserInfo user = Project.Entity.UserInfoList.GetUserByID(UserID);

                FullName.Text = user.UserName;
                FullName.Enabled = Save;

                DateOfBirth.Text = user.Dob.ToString("yyyy-MM-dd");
                DateOfBirth.Enabled = Save;

                Email.Text = user.Email;
                Email.Enabled = Save;

                Phone.Text = user.Phone;
                Phone.Enabled = Save;

                avata.ImageUrl = @"~\AvatarUser\" + user.AvatarImg;

                int accID = Convert.ToInt32(Session["accountID"].ToString());

                if (Session["rule"] != null && Convert.ToInt32(Session["rule"]) == 3) { rpEmp.DataSource = Project.Data.NewDAO.GetNewsByAcount(accID); rpEmp.DataBind(); }
                if (Session["rule"] != null && Convert.ToInt32(Session["rule"]) == 2) { rpDisplaySaveNews.DataSource = Project.Data.NewDAO.GetNewsUserSave(accID); rpDisplaySaveNews.DataBind(); }

                lblFile.Text = user.AvatarImg;
            }
        }

        void getError()
        {
            Save = true;
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


            if (error.Length != 0)
            {
                alert(error);

                Save = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {


            Save = true;

            FullName.Enabled = Save;
            DateOfBirth.Enabled = Save;
            Email.Enabled = Save;
            Phone.Enabled = Save;



            if (Save && btnSave.Text.Equals("Save") && lblFile.Text.Trim().Length != 0)
            {
                getError();

                if (Save)
                {
                    int UserID = Convert.ToInt32(Session["UserID"].ToString());

                    Project.Entity.UserInfo.UpdateUserIntoDB(FullName.Text, Convert.ToDateTime(DateOfBirth.Text), Email.Text, Phone.Text, lblFile.Text, UserID);

                    Label1.Text = "Update successful.";

                    btnSave.Text = "Edit";

                    FullName.Enabled = false;
                    DateOfBirth.Enabled = false;
                    Email.Enabled = false;
                    Phone.Enabled = false;

                }
            }
            btnSave.Text = "Save";
        }

        public void alert(string mess) 
        {
            String csname1 = "PopupScript";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;

            if (!cs.IsStartupScriptRegistered(cstype, csname1))
            {
                String cstext1 = "alert('" + mess + "');";
                cs.RegisterStartupScript(cstype, csname1, cstext1, true);
            }
        }

        protected void Change_Click(object sender, EventArgs e)
        {


            int accID = Convert.ToInt32(Session["accountID"].ToString());

            Project.Entity.Account acc = Project.Entity.AccountList.GetAccountByID(accID);

            if (btnSave.Text.Equals("Save") && lblFile.Text.Trim().Length != 0)
            {
                if (Session["Pass"].ToString() != null)
                {
                    if (OldPass.Text.Equals(acc.Pass) && NewPass.Text.Equals(confirmPass.Text))
                    {
                        getError();

                        if (Save)
                        {
                            Project.Data.AccountDAO.updateAccount(accID, NewPass.Text);

                            int UserID = Convert.ToInt32(Session["UserID"].ToString());
                            Project.Entity.UserInfo.UpdateUserIntoDB(FullName.Text, Convert.ToDateTime(DateOfBirth.Text), Email.Text, Phone.Text, lblFile.Text, UserID);

                            btnSave.Text = "Edit";

                            Label1.Text = "Update successful.";
                            FullName.Enabled = false;
                            DateOfBirth.Enabled = false;
                            Email.Enabled = false;
                            Phone.Enabled = false;
                        }
                    }
                    else
                    {
                        alert("Update Fail.");
                    }
                }

            }
            else
            {
                if (OldPass.Text.Equals(acc.Pass) && NewPass.Text.Equals(confirmPass.Text))
                {
                    accID = Convert.ToInt32(Session["accountID"].ToString());

                    Project.Data.AccountDAO.updateAccount(accID, NewPass.Text);

                    Label1.Text = "Update successful.";
                    FullName.Enabled = false;
                    DateOfBirth.Enabled = false;
                    Email.Enabled = false;
                    Phone.Enabled = false;
                }
                else if (!OldPass.Text.Equals(acc.Pass))
                {
                    //txtError.Text = "Old Pass incorect or Confirm Pass must be same new pass.";
                    alert("Old password was wrong.");
                }
                else 
                {
                    alert("New password and Confirm password not same.");
                }
            }
        }
        string fileName;
        protected void Upload_Click(object sender, EventArgs e)
        {

            if (Page.IsValid && FileUpload1.HasFile)
            {
                fileName = @"~\AvatarUser\" + FileUpload1.FileName;
                string filePath = MapPath(fileName);
                FileUpload1.SaveAs(filePath);
                avata.ImageUrl = fileName;
                lblFile.Text = FileUpload1.FileName;
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("CommandNews.aspx");
        }

        protected void rpEmp_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            //when click to Views
            if (e.CommandName.Equals("ViewNews"))
            {
                int NewsID = Convert.ToInt32(e.CommandArgument);

                Response.Redirect("DetailNews.aspx?id=" + NewsID);
            }
            //when click to edit
            if (e.CommandName.Equals("EditNews"))
            {
                int NewsID = Convert.ToInt32(e.CommandArgument);

                Response.Redirect("CommandNews.aspx?NewsId=" + NewsID);
            }
            //when click to Delete
            if (e.CommandName.Equals("DeleteNews"))
            {
                int NewsID = Convert.ToInt32(e.CommandArgument);

                Project.Data.NewDAO.DeleteNews(NewsID);

                Response.Redirect("DetailUser.aspx");
            }
        }

        protected void rpDisplaySaveNews_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("deleteSaveNews"))
            {
                int NewsID = Convert.ToInt32(e.CommandArgument);
                int accID = Convert.ToInt32(Session["accountID"].ToString());

                Project.Data.AccountDAO.DeleteUserSave(accID,NewsID);
                Response.Redirect("DetailUser.aspx");
            }
            else
            {
                Response.Redirect("DetailNews.aspx?id=" + e.CommandArgument);
            }
        }
    }
}
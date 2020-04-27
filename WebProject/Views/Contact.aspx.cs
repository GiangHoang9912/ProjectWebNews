using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject.Views
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Project.Entity.Contact con = Project.Entity.ContactList.GetContact();

            Label1.Text = con.CompanyName;
            Label2.Text = con.Address;
            Label3.Text = con.Email;
            Label4.Text = con.Phone;
            Label5.Text = con.Opening;
            Label6.Text = con.DayOpen;
        }
    }
}
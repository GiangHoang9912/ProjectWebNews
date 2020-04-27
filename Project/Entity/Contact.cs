using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Project.Entity
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Opening { get; set; }
        public string DayOpen { get; set; }

        public Contact()
        {
        }

        public Contact(int contactID, string companyName, string phone, string email, string address, string opening, string dayOpen)
        {
            ContactID = contactID;
            CompanyName = companyName;
            Phone = phone;
            Email = email;
            Address = address;
            Opening = opening;
            DayOpen = dayOpen;
        }
    }

    public class ContactList
    {
        public static Contact GetContact()
        {
            Contact ct = new Contact();
            DataTable dt = Project.Data.ContactDAO.GetAllContact();
            foreach (DataRow dr in dt.Rows)
            {
                        ct = new Contact(
                        Convert.ToInt32(dr["ContactID"]),
                        dr["CompanyName"].ToString(),
                        dr["Phone"].ToString(),
                        dr["Gmail"].ToString(),
                        dr["Address"].ToString(),
                        dr["Opening"].ToString(),
                        dr["DayOpen"].ToString()
                    );
            }
            return ct;
        }
    }
}

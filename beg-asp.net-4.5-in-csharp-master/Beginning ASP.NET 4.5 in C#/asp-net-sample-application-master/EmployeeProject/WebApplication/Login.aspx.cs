using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Convert.ToBoolean(Session["is_logged_in"]) == true) {
                Response.Redirect("Home.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string emailAddress = email.Text.Trim();
            string password = pwd.Text;
            if(emailAddress == "a@a.com" && password == "a@a.com") {
                Session["is_logged_in"] = 1;
                Session["user_id"] = 1;
                Session["user_email"] = emailAddress;
                Response.Redirect("Home.aspx");
            } else {
                RequiredFieldValidator1.ErrorMessage = "Invalid email or password";
                RequiredFieldValidator1.IsValid = false;
            }
        }
    }
}
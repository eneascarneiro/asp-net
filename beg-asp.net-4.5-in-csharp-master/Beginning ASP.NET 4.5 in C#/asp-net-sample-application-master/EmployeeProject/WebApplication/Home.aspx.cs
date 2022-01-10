using System;
using System.Data;
using WebApplication.employeeWS;

namespace WebApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public employeeWS.EmpWS webService;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["is_logged_in"]) != true) {
                Response.Redirect("Login.aspx");
            }

            Label1.Text = Session["user_email"].ToString() + "!";
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            if(Request.Form.AllKeys.Length > 0 && Request.HttpMethod == "POST") {
                // Create employee object
                this.webService = new EmpWS();
                Employee employee = new Employee();
                employee.title = "Mr.";
                employee.first_name = Request.Form["first_name"];
                employee.last_name = Request.Form["last_name"];
                employee.designation = Request.Form["designation"];
                employee.dob = Request.Form["dob"];
                employee.father_name = Request.Form["father_name"];
                employee.department = Request.Form["department"];
                employee.gender = Request.Form["gender"];
                employee.spouse_name = Request.Form["spouse_name"];
                employee.permanent_address = Request.Form["p_address"];
                employee.temporary_address = Request.Form["c_address"];
                employee.avatar_path = "";

                // Upload user avatar
                var file = Request.Files["avatar"];
                if (file.FileName != "") {
                    employee.avatar_path = System.IO.Path.GetFileName(file.FileName);
                    var fileBasePath = Server.MapPath(".\\") + "Avatar\\";
                    file.SaveAs(fileBasePath + employee.avatar_path);
                }
                
                // Save user record
                this.webService.Create(employee);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            Response.Redirect("Login.aspx");
    }
    }
}
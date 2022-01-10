using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using WebApplication.employeeWS;

namespace WebApplication
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public employeeWS.EmpWS webService;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["is_logged_in"]) != true) {
                Response.Redirect("Login.aspx");
            }

            Label1.Text = Session["user_email"].ToString() + "!";

            this.webService = new EmpWS();
            if (!Page.IsPostBack)
            {
                DataSet ds = this.webService.Get("", "");
                this.LoadData(ds);
                ViewState["dirState"] = ds;
                ViewState["sortdr"] = "Asc";
            }
        }

        private void LoadData(DataSet Employees)
        {
            // Fetch the data from table
            GridView1.DataSource = Employees.Tables[0].DefaultView;
            GridView1.DataBind();

            // Populate the column name list
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            String sql = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.Columns WHERE TABLE_NAME = 'employee'";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, conn);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            DropDownList1.Items.Clear();
            foreach (DataRow row in table.Rows) {
                string columnName = row[0].ToString();
                if (columnName != "created_at" || columnName != "updated_at") {
                    DropDownList1.Items.Add(columnName);
                }
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            string column = DropDownList1.SelectedValue;
            var query = search_query.Text;

            if (column != "" && query != "") {
                LoadData(webService.Get(column, query));
            }

            search_query.Text = query;
            DropDownList1.Text = column;
        }

        protected void GridView1_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            // Get the id of row
            string id = ((Label)GridView1.Rows[e.RowIndex]
                        .FindControl("ID")).Text;
            webService.Delete(id);

            LoadData(webService.Get("", ""));
        }

        protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            LoadData(webService.Get("", ""));
        }

        protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            string id = ((Label)GridView1.Rows[e.RowIndex]
                        .FindControl("ID")).Text;
            string first_name = ((TextBox) GridView1.Rows[e.RowIndex]
                        .FindControl("first_name")).Text;
            string last_name = ((TextBox)GridView1.Rows[e.RowIndex]
                                .FindControl("last_name")).Text;
            string gender = ((DropDownList)GridView1.Rows[e.RowIndex]
                                .FindControl("gender")).Text;
            string department = ((DropDownList)GridView1.Rows[e.RowIndex]
                                .FindControl("department")).Text;
            string dob = ((TextBox)GridView1.Rows[e.RowIndex]
                                .FindControl("dob")).Text;
            string permanent_address = ((TextBox)GridView1.Rows[e.RowIndex]
                                .FindControl("permanent_address")).Text;
            string designation = ((TextBox)GridView1.Rows[e.RowIndex]
                                .FindControl("designation")).Text;
            string father_name = ((TextBox)GridView1.Rows[e.RowIndex]
                                .FindControl("father_name")).Text;

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update employee set first_name=@first_name, last_name=@last_name, gender=@gender, " +
                "department=@department, dob=@dob, permanent_address=@permanent_address, designation=@designation," +
                " father_name=@father_name " +
                " where id=@id;";
            cmd.Parameters.Add("@first_name", SqlDbType.VarChar).Value = first_name;
            cmd.Parameters.Add("@last_name", SqlDbType.VarChar).Value = last_name;
            cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = gender;
            cmd.Parameters.Add("@dob", SqlDbType.DateTime).Value = dob;
            cmd.Parameters.Add("@department", SqlDbType.VarChar).Value = department;
            cmd.Parameters.Add("@designation", SqlDbType.VarChar).Value = designation;
            cmd.Parameters.Add("@father_name", SqlDbType.VarChar).Value = father_name;
            cmd.Parameters.Add("@permanent_address", SqlDbType.VarChar).Value = permanent_address;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            cmd.Connection = con;
            object obj = cmd.ExecuteNonQuery();
            con.Close();

            GridView1.EditIndex = -1;
            LoadData(webService.Get("", ""));
        }

        protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadData(webService.Get("", ""));
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataSet ds = (DataSet)ViewState["dirState"];
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0) {
                if (Convert.ToString(ViewState["sortdr"]) == "Asc") {
                    dt.DefaultView.Sort = e.SortExpression + " Desc";
                    ViewState["sortdr"] = "Desc";
                } else {
                    dt.DefaultView.Sort = e.SortExpression + " Asc";
                    ViewState["sortdr"] = "Asc";
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
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

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            LoadData(webService.Get("", ""));
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var a = e.CommandName;
            if (e.CommandName == "ClearAvatar")
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
               
                SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["DB"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update employee set avatar_path=''" +
                                    " where id=@id;";
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                cmd.Connection = con;
                object obj = cmd.ExecuteNonQuery();
                con.Close();

                GridView1.EditIndex = -1;
                LoadData(webService.Get("", ""));
            }
        }
    }
}
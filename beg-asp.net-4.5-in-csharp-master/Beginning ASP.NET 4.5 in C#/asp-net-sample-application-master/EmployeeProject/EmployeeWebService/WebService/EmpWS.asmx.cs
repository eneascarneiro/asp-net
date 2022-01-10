using System;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.Services.Protocols;
using WebService.Entity;

namespace WebService
{
    /// <summary>
    /// Summary description for EmpWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class EmpWS : System.Web.Services.WebService
    {
        private static string connectionString = WebConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        private static SqlConnection conn;
        
        /// <summary>
        /// Return the singleton object of database connection
        /// </summary>
        /// <returns>Return the database connection</returns>
        public static SqlConnection GetDBInstance()
        {
            if (EmpWS.conn is SqlConnection && EmpWS.conn.State != ConnectionState.Closed)
                return EmpWS.conn;

            EmpWS.conn = new SqlConnection(EmpWS.connectionString);

            return EmpWS.conn;
        }

        // [WebMethod, SoapHeader("AuthHeader", Direction = SoapHeaderDirection.InOut)]
        [WebMethod]
        public DataSet Get(string column, string value)
        {
            SqlConnection conn = EmpWS.GetDBInstance();
            DataSet ds = new DataSet();

            string query = "SELECT * from employee";
            if(column != "" && value != "") {
                query += " WHERE " + column + " LIKE '%" + value + "%'"; 
            }

            try {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(ds);
            } finally {
             conn.Close();
            }

            return ds;
        }

        [WebMethod]
        public DataSet Create(Employee employee)
        {
            DataSet ds = new DataSet();
            string message = "";
            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                SqlConnection conn = EmpWS.GetDBInstance();
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddEmployeeReturnID";

                cmd.Parameters.AddWithValue("@title", employee.title.ToString());
                cmd.Parameters.AddWithValue("@first_name", employee.first_name.ToString());
                cmd.Parameters.AddWithValue("@last_name", employee.last_name.ToString());
                cmd.Parameters.AddWithValue("@designation", employee.designation.ToString());
                cmd.Parameters.AddWithValue("@dob", Convert.ToDateTime(employee.dob));
                cmd.Parameters.AddWithValue("@father_name", employee.father_name.ToString());
                cmd.Parameters.AddWithValue("@department", employee.department.ToString());
                cmd.Parameters.AddWithValue("@gender", employee.gender.ToString());
                cmd.Parameters.AddWithValue("@spouse_name", employee.spouse_name.ToString());
                cmd.Parameters.AddWithValue("@permanent_address", employee.permanent_address.ToString());
                cmd.Parameters.AddWithValue("@temporary_address", employee.temporary_address.ToString());
                cmd.Parameters.AddWithValue("@avatar_path", employee.avatar_path);
                cmd.Parameters.AddWithValue("@created_at", DateTime.Now);
                cmd.Connection = conn;

                try {
                    object obj = cmd.ExecuteNonQuery();
                    message = "Record inserted successfully. ID = " + obj.ToString();

                    // Read the employee and return
                    string query = "SELECT * from employee WHERE id=" + obj.ToString();
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(ds);

                }
                catch (SqlException err) {
                    message = "Error inserting record:";
                    message += err.Message;
                    throw new Exception(message);
                } finally {
                    conn.Close();
                }
            }

            return ds;
        }

        [WebMethod]
        public void Delete(string employeeID)
        {
            string sqlStat = "DELETE FROM Employee WHERE ID = @employeeID";
            try {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStat, conn);
                cmd.Parameters.AddWithValue("@employeeID", employeeID);
                cmd.ExecuteNonQuery();
            } catch (SqlException err) {
                string message = "Deletion Error:";
                message += err.Message;
                throw new Exception(message);
            } finally {
                conn.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;


public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void button1Clicked(object sender, EventArgs args)
    {


        Boolean auth = false;


        string username = textbox1.Text;
        string password = textbox2.Text;


        //MySqlConnection connection;
       

        //connection = new MySqlConnection(connectionString);

        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = @"Data Source=(localDB)\MSSQLlocalDB;Initial Catalog=portal;Integrated Security=true;";
        connection.Open();
        string query = "SELECT * FROM login where password=@pass and username=@user";

        using (SqlCommand cmd = new SqlCommand(query, connection))
        {
            cmd.Parameters.Add("pass", password);
            cmd.Parameters.Add("user", username);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    auth = true;
                }
            }

            Session["username"] = username;
        }
        connection.Close();





        if (auth == true)
        {

            Response.Redirect("student.aspx");

        }


    }
}




